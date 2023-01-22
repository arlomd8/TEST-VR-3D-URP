using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class QuitRoom : MonoBehaviourPunCallbacks
{
    public InputActionProperty x,y,a,b;
   

    private void Update()
    {
        if (x.action.IsPressed() && y.action.IsPressed() && a.action.IsPressed() && b.action.IsPressed())
        {
            PhotonNetwork.LeaveRoom();
        }
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        //PhotonNetwork.LoadLevel(0);
        PhotonNetwork.Disconnect();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        SceneManager.LoadScene(0);
        base.OnDisconnected(cause);
    }

}
