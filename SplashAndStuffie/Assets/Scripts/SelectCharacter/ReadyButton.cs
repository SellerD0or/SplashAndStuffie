using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyButton : MonoBehaviour
{
   [SerializeField] private CreatorAdderCharacter _creatorAdderCharacter;
       [SerializeField] private LoaderCharacter _loaderCharacter;
       [SerializeField] private SaverInventory _saverInventory;
       private LoaderSaveableSlotOfCharacter _loaderSaveableSlotOfCharacter;
       private Settings _settings;
       private void Start() {
           _loaderSaveableSlotOfCharacter = FindObjectOfType<LoaderSaveableSlotOfCharacter>();
           _settings = FindObjectOfType<Settings>();
       }
   public void Click()
   {
       if (_loaderSaveableSlotOfCharacter.NumberOfSelectedCharacter >= _creatorAdderCharacter.CountOfAdderCharacters)
       {
          // List<Player> players = new List<Player>();
          // List<Player> selectedPlayers =new List<Player>();
           //foreach (var item in _saverInventory.CurrentSaveableSlotOfCharacter.CurrentPlayerNames)
           //{  
           //    Debug.Log(item);
          //    selectedPlayers.Add(    _saverInventory.AllPlayer.Find(e=> e.Name == item ));
           //}
           //foreach (var item in _creatorAdderCharacter.AdderCharacters)
           //{
           //    item.enabled = true;
             //  Player player = selectedPlayers.Find(e => e.Name== item.CurrentPlayer.Name);
            //   players.Add(player);
               
           //}
           _loaderCharacter.SaveSaveableCurrentInventory(new SaveableSelectOfCharacter() {CurrentPlayers = _loaderSaveableSlotOfCharacter.CurrentPlayers});
           string _nameOfLevel = PlayerPrefs.GetString("NameOfLevel");
          //SceneManager.LoadScene(_nameOfLevel);
          _settings.LoadGame();
       }
       
   }
}
