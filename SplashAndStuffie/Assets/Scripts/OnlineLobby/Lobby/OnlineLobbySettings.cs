using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
public class OnlineLobbySettings : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField _joinInput;
    [SerializeField] private InputField _createInput;
    [SerializeField] private InputField _textName;
    [SerializeField] private Text _logText;
   private void Start() {
       _textName.text = PlayerPrefs.GetString("name");
       PhotonNetwork.NickName =  _textName.text + " " + Random.Range(1000, 9999);
       Log("Player's name is set to " + PhotonNetwork.NickName);
       PhotonNetwork.AutomaticallySyncScene = true;
       PhotonNetwork.GameVersion = "1";
       PhotonNetwork.ConnectUsingSettings();
   }
   public void SaveName()
   {
       PlayerPrefs.SetString("name", _textName.text);
   }
   private void ChangeName(string message)
   {
       _textName.text = message;
   }
   private void Log(string message) {
       Debug.Log(message);
       _logText.text += "\n";
       _logText.text += message;

   }

   public void CreateRoom()
   {
       RoomOptions roomOptions = new RoomOptions();
       roomOptions.MaxPlayers = 8;
       PhotonNetwork.CreateRoom(_createInput.text, roomOptions);
   }
   public void JoinRoom()
   {
       PhotonNetwork.JoinRoom(_joinInput.text);
   }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("OnlineMode");
    }
      public override void OnConnectedToMaster()
    {
        Log("Connected to Master");
    }
}
