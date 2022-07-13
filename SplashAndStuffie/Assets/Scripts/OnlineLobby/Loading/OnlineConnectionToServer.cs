using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class OnlineConnectionToServer : MonoBehaviourPunCallbacks
{
    private void Start() 
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("OnlineMode");
    }
}
