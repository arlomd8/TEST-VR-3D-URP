using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetNickname : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        photonView.Owner.NickName = "PLAYER " + photonView.Owner.ActorNumber;
        GetComponent<TextMeshProUGUI>().text = photonView.Owner.NickName;
    }
}
