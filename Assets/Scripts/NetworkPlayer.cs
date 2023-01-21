using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
using Unity.XR.CoreUtils;

public class NetworkPlayer : MonoBehaviour
{
    private PhotonView photonView;

    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    public Animator rightHandAnimator;
    public Animator leftHandAnimator;

    public List<GameObject> ava;
    int randomAva;

    public Transform headRig;
    public Transform leftHandRig;
    public Transform rightHandRig;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        RandomAvatar(); //PER CLIENT BEDA
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
            ava[randomAva].SetActive(false);

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

        //if (inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float pointValue))
        //{
        //    animator.SetFloat("Point", pointValue);
        //}
        //else
        //{
        //    animator.SetFloat("Point", 0);
        //}

        //if (inputDevice.TryGetFeatureValue(CommonUsages.grip, out float grabValue))
        //{
        //    animator.SetFloat("Grab", grabValue);
        //}
        //else
        //{
        //    animator.SetFloat("Grab", 0);
        //}
    }

    private void MapPosition(Transform target, Transform rigTransform)
    {
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }

    void RandomAvatar()
    {
        randomAva = Random.Range(0, ava.Count);
        ava[randomAva].SetActive(true);
        print(randomAva);
    }

    void SetupRig()
    {
        XROrigin rig = FindObjectOfType<XROrigin>();
        headRig = rig.transform.Find("Camera Offset/Main Camera");
        leftHandRig = rig.transform.Find("Camera Offset/LeftHand Controller");
        rightHandRig = rig.transform.Find("Camera Offset/RightHand Controller");
    }
}
