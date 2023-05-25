using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;


public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;

    void Start()
    {
        PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(150,1,170), Quaternion.identity, 0);
    }

    public void OnPlayerEnterRoom(Player other)
    {
        print(other.Username + " s'est connecté");
    }

    public void OnPlayerLeftRoom(Player other)
    {
        print(other.Username + " s'est déconnecté");
    }

    public void OnLeftRoom()
    {
        SceneManager.LoadScene("menu");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
