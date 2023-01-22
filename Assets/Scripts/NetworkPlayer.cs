using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
using Unity.XR.CoreUtils;
using System.Linq;

public class NetworkPlayer : MonoBehaviour
{
    private PhotonView photonView;

    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    public Animator rightHandAnimator;
    public Animator leftHandAnimator;

    public List<GameObject> ava;
    public int randomAva;

    public Transform headRig;
    public Transform leftHandRig;
    public Transform rightHandRig;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        RandomAvatar();
        SetupRig();


        if (photonView.IsMine)
        {
            foreach (var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            head.gameObject.SetActive(false);
            //ava[randomAva].SetActive(false);

            MapPosition(head, headRig);
            MapPosition(leftHand, leftHandRig);
            MapPosition(rightHand, rightHandRig);
            AnimateHand(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), rightHandAnimator);
            AnimateHand(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), leftHandAnimator);

        }
    }

    void AnimateHand(InputDevice inputDevice, Animator animator)
    {
        inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float pointValue);
        inputDevice.TryGetFeatureValue(CommonUsages.grip, out float grabValue);

        animator.SetFloat("Point", pointValue);
        animator.SetFloat("Grab", grabValue);
    }

    private void MapPosition(Transform target, Transform rigTransform)
    {
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }

    void RandomAvatar()
    {
        if (photonView.IsMine)
        {
            photonView.RPC("RPC_SendRandomAvatar", RpcTarget.AllBuffered, Random.Range(0, ava.Count));
        }

    }

    void SetupRig()
    {
        XROrigin rig = FindObjectOfType<XROrigin>();
        headRig = rig.transform.Find("Camera Offset/Main Camera");
        leftHandRig = rig.transform.Find("Camera Offset/LeftHand Controller");
        rightHandRig = rig.transform.Find("Camera Offset/RightHand Controller");
    }

    [PunRPC]
    void RPC_SendRandomAvatar(int i)
    {
        gameObject.GetComponent<NetworkPlayer>().randomAva = i;
        gameObject.GetComponent<NetworkPlayer>().ava[i].SetActive(true);
    }

}
