using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;
using Photon.Realtime;
using Photon.Pun;

public class MyLauncher : MonoBehaviourPunCallbacks
{
    public Button btn;
    public Text feedbackText;

    private byte maxPlayersPerRoom = 4;

    bool isConnecting;


    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

    }

    public void Connect ()
    {
        feedbackText.text = "";

        isConnecting = true;

        btn.interactable = false;



        if (PhotonNetwork.IsConnected)
        {
            LogFeedback("Joining Room ...");
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            LogFeedback("Connecting ...");

            PhotonNetwork.ConnectUsingSettings();
        }  
    }

    void LogFeedback(string message)
    {
        if (feedbackText != null)
        {
            feedbackText.text += System.Environment.NewLine + message;
        }

    }

    public override void OnConnectedToMaster()
    {
        if (isConnecting)
        {
            LogFeedback("Try to join any random room");
            Debug.Log("Il s'est connecté");

            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnJoinRandomFailed(short  returnCode, string message)
    {
        LogFeedback("Create new room");
        Debug.Log("Il crée une nouvelle room");

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = this.maxPlayersPerRoom });
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        LogFeedback(cause.ToString());
        Debug.LogError("Il s'est déconnecté");

        isConnecting = false;
        btn.interactable = true;
    }

    public override void OnJoinedRoom()
    {
        LogFeedback(((int)PhotonNetwork.CurrentRoom.PlayerCount).ToString());
        Debug.Log("Le client est dans la room");

        if(PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Debug.Log("Room pour 1 personne");

            PhotonNetwork.LoadLevel("map");
        }
    }
}
