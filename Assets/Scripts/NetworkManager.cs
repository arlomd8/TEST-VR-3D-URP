using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public List<WebinarRoom> rooms;
    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        print("Connecting");
    }

    public override void OnConnectedToMaster()
    {
        InitializeRoom(UIManager.instance.sceneIndex);
        print("Connected");
        base.OnConnectedToMaster();
        
    }

    public void InitializeRoom(int i)
    {

        WebinarRoom room = rooms[i - 1];
        PhotonNetwork.LoadLevel(room.roomIndex);


        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)room.maxRoom;
        roomOptions.IsVisible = room.isVisible;
        roomOptions.IsOpen = room.isOpen;
        PhotonNetwork.JoinOrCreateRoom(room.roomName, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        //print("Joined a Room");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
    }

}
