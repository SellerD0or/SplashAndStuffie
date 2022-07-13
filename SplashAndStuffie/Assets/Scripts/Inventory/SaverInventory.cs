using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaverInventory : MonoBehaviour
{
   [SerializeField] List<Player> _allPlayer;
       private readonly string _filePath = Application.streamingAssetsPath + "/Save.json";
      private SaveableSlotOfCharacter _saveableInventory;
    private SaveableSlotOfCharacter _currentSaveableSlotOfCharacter;

    public SaveableSlotOfCharacter CurrentSaveableSlotOfCharacter { get => _currentSaveableSlotOfCharacter; set => _currentSaveableSlotOfCharacter = value; }
    public List<Player> AllPlayer { get => _allPlayer; set => _allPlayer = value; }
 
    private void Awake() 
      {
        Load();
    CurrentSaveableSlotOfCharacter.CurrentPlayerNames.RemoveAll(item => item == "");
   // CurrentSaveableSlotOfCharacter.CurrentSlotsOfCharacters.RemoveAll(item => item == null);

    SaveSaveableCurrentInventory(CurrentSaveableSlotOfCharacter);
      }
   private void Update() {
     if (Input.GetKeyDown(KeyCode.A))
     {
       //  Destroy();
     }
   }
      public void Destroy()
      {
        CurrentSaveableSlotOfCharacter = null;
        _saveableInventory = null;
        
        SaveSaveableCurrentInventory(new SaveableSlotOfCharacter(){SlotOfCharacter = null, CurrentSlotsOfCharacters = null, Player = null , CurrentPlayers = null});
      }
    public void Save(SaveableSlotOfCharacter saveableCurrentInventory)
    {
        if (CurrentSaveableSlotOfCharacter != null)
        {
            _saveableInventory = CurrentSaveableSlotOfCharacter;
        }
        else
        {
            _saveableInventory = saveableCurrentInventory;
        }
        if(saveableCurrentInventory.SlotOfCharacter != null)
        {
       _saveableInventory.CurrentSlotsOfCharacters.Add(saveableCurrentInventory.SlotOfCharacter);
       
        }
      // if ( saveableCurrentInventory.Player != null) // return if doesn't work
      //  {
      //    Debug.Log("we can  player");
       //   _saveableInventory.CurrentPlayers.Add(saveableCurrentInventory.Player);
      //  }
        if ( saveableCurrentInventory.PlayerName != "")
        {
          Debug.Log("we can  player");
           _saveableInventory.CurrentPlayerNames.Add(saveableCurrentInventory.PlayerName);
        }
           if ( saveableCurrentInventory.ItemName != "")
        {
          Debug.Log("we can  player");
           _saveableInventory.CurrentItemNames.Add(saveableCurrentInventory.ItemName);
        }
      //  if (saveableCurrentInventory.Item != null)
      //  {
        //    _saveableInventory.CurrentItems.Add(saveableCurrentInventory.Item);
       // }
      int value =0;
      value= PlayerPrefs.GetInt("GameSlot",value);

    File.WriteAllText(Application.streamingAssetsPath + $"/SaveableSlotOfCharacter{value}.json", JsonUtility.ToJson(_saveableInventory));
    }
    public void SaveSaveableCurrentInventory(SaveableSlotOfCharacter reSaveableCurrentInventory)
    {
      int value =0;
      value= PlayerPrefs.GetInt("GameSlot",value);
      File.WriteAllText(Application.streamingAssetsPath + $"/SaveableSlotOfCharacter{value}.json", JsonUtility.ToJson(reSaveableCurrentInventory));
      Load();
    }
    public void Load()
    {
      int value =0;
      value= PlayerPrefs.GetInt("GameSlot",value);
    CurrentSaveableSlotOfCharacter  =  JsonUtility.FromJson<SaveableSlotOfCharacter>(File.ReadAllText(Application.streamingAssetsPath + $"/SaveableSlotOfCharacter{value}.json"));
  //  CurrentSaveableSlotOfCharacter.CurrentSlotsOfCharacters.ForEach(e=> Debug.Log(e + " ok - is saveable"));
    }

}
