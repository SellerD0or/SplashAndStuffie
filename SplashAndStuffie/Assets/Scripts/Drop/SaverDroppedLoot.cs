using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaverDroppedLoot : MonoBehaviour
{
      private readonly string _filePath = Application.streamingAssetsPath + "/Save.json";
      private SaveableCurrentInventory _saveableInventory;
    private SaveableCurrentInventory _currentSaveableCurrentInventory;

    public SaveableCurrentInventory CurrentSaveableCurrentInventory { get => _currentSaveableCurrentInventory; set => _currentSaveableCurrentInventory = value; }
    public List<Item> AllTheItems { get => _allTheItems; set => _allTheItems = value; }

    [SerializeField] private List<Player> _players;
    [SerializeField] private List<Item> _allTheItems;
    private void Awake() 
      {
       
        //if (CurrentSaveableCurrentInventory == null)
       // {
          //  Destroy();
       // }
        Load();
  //       if(CurrentSaveableCurrentInventory.CurrentPlayers == null)
  //  {
   //     Destroy();
   // }
        CurrentSaveableCurrentInventory.CurrentItemNames.RemoveAll(item => item == "");
  //  CurrentSaveableCurrentInventory.CurrentPlayers.RemoveAll(item => item == null);
 //    CurrentSaveableCurrentInventory.CurrentItems.RemoveAll(item => item == null);
//     CurrentSaveableCurrentInventory.CurrentItems.ForEach(e => Debug.Log(e));
    SaveSaveableCurrentInventory(CurrentSaveableCurrentInventory);
      }
   private void Update() {
     if (Input.GetKeyDown(KeyCode.A))
     {
         //Destroy();
     }
      if (Input.GetKeyDown(KeyCode.Q))
     {
        // Save(new SaveableCurrentInventory(){CurrentPlayers = _players} );
     }
   }
      public void Destroy()
      {
        CurrentSaveableCurrentInventory = null;
        _saveableInventory = null;
        SaveSaveableCurrentInventory(new SaveableCurrentInventory(){Player = null, Item = null,CurrentItems = null, CurrentPlayers = null});
      }
    public void Save(SaveableCurrentInventory saveableCurrentInventory)
    {
        if (CurrentSaveableCurrentInventory != null)
        {
            _saveableInventory = CurrentSaveableCurrentInventory;
        }
        else
        {
            _saveableInventory = saveableCurrentInventory;
        }
        if(saveableCurrentInventory.Player != null)
    _saveableInventory.CurrentPlayers.Add(saveableCurrentInventory.Player);
         if(saveableCurrentInventory.ItemName !="")
         {
        _saveableInventory.CurrentItemNames.Add(saveableCurrentInventory.ItemName);
         }
                     int value =0;
      value= PlayerPrefs.GetInt("GameSlot",value);
    File.WriteAllText(Application.streamingAssetsPath +  $"/SaveableCurrentInventory{value}.json", JsonUtility.ToJson(_saveableInventory));
    }
    public void SaveSaveableCurrentInventory(SaveableCurrentInventory reSaveableCurrentInventory)
    {
      Debug.Log("cool save");
            int value =0;
      value= PlayerPrefs.GetInt("GameSlot",value);

      File.WriteAllText(Application.streamingAssetsPath + $"/SaveableCurrentInventory{value}.json", JsonUtility.ToJson(reSaveableCurrentInventory));
      Load();
    }
    public void Load()
    {
            int value =0;
      value= PlayerPrefs.GetInt("GameSlot",value);

    CurrentSaveableCurrentInventory  =  JsonUtility.FromJson<SaveableCurrentInventory>(File.ReadAllText(Application.streamingAssetsPath + $"/SaveableCurrentInventory{value}.json"));
   // Debug.Log(_currentSaveableCurrentInventory);
    //foreach (var item in _currentSaveableCurrentInventory.CurrentPlayers)
    //{
     //   Debug.Log(item + " yeah");
    //}
     // _currentSaveableCurrentInventory =  JsonUtility.FromJson<SaveableCurrentInventory>(File.ReadAllText(Application.streamingAssetsPath + "/SaveableCollectionOfEntities.json"));
    }
}
