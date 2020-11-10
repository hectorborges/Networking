using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public byte maxPlayers = 8;
    public GameObject playerPrefab;

    TypedLobby mainLobby = new TypedLobby("MainLobby", LobbyType.SqlLobby);

    public void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        RoomOptions roomOptions = new RoomOptions();

        roomOptions.MaxPlayers = maxPlayers;
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;

        PhotonNetwork.JoinOrCreateRoom("Main", roomOptions, mainLobby);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
    }
}
