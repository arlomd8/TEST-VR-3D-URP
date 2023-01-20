using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    public List<GameObject> Spawns = new List<GameObject>();
    public GameObject spawnedPlayer;
    int randomAvatar;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        randomAvatar = Random.Range(0, Spawns.Count);
        //spawnedPlayer = PhotonNetwork.Instantiate(Spawns[randomAvatar].name, transform.position, transform.rotation);
        spawnedPlayer = PhotonNetwork.Instantiate("Avatar", transform.position, transform.rotation);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayer);

    }
}
