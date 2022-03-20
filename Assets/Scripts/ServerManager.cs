using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ServerManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Servere bağlanıldı");
        Debug.Log("Lobiye bağlanılıyor");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Lobiye bağlanıldı");
        Debug.Log("Odaya bağlanılıyor");
        PhotonNetwork.JoinOrCreateRoom("AliBerk", new RoomOptions { MaxPlayers = 16, IsOpen = true, IsVisible = true }, TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Odaya bağlanıldı");
        Debug.Log("Karakter oluşturuluyor...");
        PhotonNetwork.Instantiate("cube", new Vector3(0, 0, 0), Quaternion.identity, 0, null);
    }
}