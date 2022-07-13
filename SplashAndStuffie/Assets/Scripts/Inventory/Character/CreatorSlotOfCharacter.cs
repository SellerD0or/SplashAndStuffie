using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreatorSlotOfCharacter : MonoBehaviour
{
   [SerializeField] private SaverDroppedLoot _saverDroppedLoot;
  
  [SerializeField] private SlotOfCharacter _slotOfCharacter;
  [SerializeField] private Transform _spawnPosition;
 // private SaveableSlotOfCharacter _saveableSlotOfCharacter;
  //private SaveableSlotOfCharacter _currentSaveableSlotOfCharacter;
  [SerializeField] private CreatorSlotOfItem _creatorOfSlot;
  //  public SaveableSlotOfCharacter CurrentSaveableSlotOfCharacter { get => _currentSaveableSlotOfCharacter; set => _currentSaveableSlotOfCharacter = value; }
    public SaverInventory SaverInventory { get => _saverInventory; set => _saverInventory = value; }

    [SerializeField] private bool _isActive;
[SerializeField] private List<SlotOfCharacter> _slotOfCharacters =new List<SlotOfCharacter>();
[SerializeField] private SaverInventory _saverInventory;
private Player _loadedPlayer;
 private SaveableEducation _saveableEducation;
[SerializeField] private Saver _saver;
[SerializeField] private Loader loader;
    private void Awake() {
    
    //_saverInventory.Load();
  }
  private void Start() {
      //   _saveableEducation =  loader.Load();
       // if(! _saveableEducation.IsCreated)
      //  {
      //      _loadedPlayer = _saveableEducation.Player;
      //       _saverDroppedLoot.CurrentSaveableCurrentInventory.CurrentPlayers.Add(_loadedPlayer);
        //     _saverDroppedLoot.SaveSaveableCurrentInventory(_saverDroppedLoot.CurrentSaveableCurrentInventory);
      //      _saver.Save(new SaveableEducation() {Player =_loadedPlayer,IsCreated = true, IsEducationEnd =false});
      //      _saveableEducation.IsCreated = true;
     //   }

  //  SaveableCurrentInventory saveableCurrentInventory = _saverDroppedLoot.CurrentSaveableCurrentInventory; //= new SaveableCurrentInventory(new SaveableCurrentInventory() {CurrentPlayers = _saverDroppedLoot.CurrentSaveableCurrentInventory.CurrentPlayers
   // ,CurrentItems = _saverDroppedLoot.CurrentSaveableCurrentInventory.CurrentItems }); //= ;
    //_saverDroppedLoot.CurrentSaveableCurrentInventory.CurrentPlayers.ForEach(e => Debug.Log(e));
  //  saveableCurrentInventory.CurrentPlayers.Clear();
  //  Debug.LogError("After");
 
/* if(_saverDroppedLoot.CurrentSaveableCurrentInventory.CurrentPlayers == null) // if doesn't work turn it on!!!!
    {
        _saverDroppedLoot.Destroy();
    }
    
    _saverDroppedLoot.CurrentSaveableCurrentInventory.CurrentPlayers.RemoveAll(item => item == null);
     _saverDroppedLoot.CurrentSaveableCurrentInventory.CurrentItems.RemoveAll(item => item == null);
     _saverDroppedLoot.CurrentSaveableCurrentInventory.CurrentItems.ForEach(e => Debug.Log(e));
    _saverDroppedLoot.SaveSaveableCurrentInventory(_saverDroppedLoot.CurrentSaveableCurrentInventory);

//    _currentSaveableSlotOfCharacter.CurrentSlotsOfCharacters.ForEach(e=> Debug.Log(e + " yeyey"));
_saverInventory.CurrentSaveableSlotOfCharacter.CurrentPlayers.RemoveAll(item => item == null);
    _saverInventory.CurrentSaveableSlotOfCharacter.CurrentSlotsOfCharacters.RemoveAll(item => item == null);

    _saverInventory.SaveSaveableCurrentInventory(_saverInventory.CurrentSaveableSlotOfCharacter);
   //  if (_saverInventory.CurrentSaveableSlotOfCharacter.CurrentSlotsOfCharacters == null)
    {
     //   Destroy();
    }
    SaverInventory. SaveSaveableCurrentInventory(_saverInventory.CurrentSaveableSlotOfCharacter);
   //  _currentSaveableSlotOfCharacter.CurrentSlotsOfCharacters.ForEach(e=> Debug.Log(e + " yeyey"));
    // if(_currentSaveableSlotOfCharacter.CurrentSlotsOfCharacters != null)
     //{
        // Destroy()
 */        
     SimpleCreate();

     //}
   //  else if(_currentSaveableSlotOfCharacter.CurrentSlotsOfCharacters != null)
    // {
     //  Debug.LogError("cool");
      // _currentSaveableSlotOfCharacter.CurrentSlotsOfCharacters.ForEach(e=> Debug.Log(e + " it isnot empty"));
       /*
         foreach (var item in _currentSaveableSlotOfCharacter.CurrentSlotsOfCharacters)
      { 
         SlotOfCharacter slotOfCharacter = Instantiate(item, transform.position, Quaternion.identity);
         slotOfCharacter.Player = item.Player;
         slotOfCharacter.gameObject.transform.SetParent(_spawnPosition,false);
          if(CurrentSaveableSlotOfCharacter != null)
         {
         if(CurrentSaveableSlotOfCharacter.CurrentSlotsOfCharacters.Contains(slotOfCharacter))
         {
           slotOfCharacter = CurrentSaveableSlotOfCharacter.SlotOfCharacter;
         }
         else
         {
             Save(new SaveableSlotOfCharacter() {SlotOfCharacter = slotOfCharacter});
         }
         }
         else
         {
             Save(new SaveableSlotOfCharacter() {SlotOfCharacter = slotOfCharacter});
         }
      }
      */
    // }
     
      _creatorOfSlot.Create();
   
  }
  public void DestoryAll()
  {
    _slotOfCharacters.ForEach(e=> Destroy(e));
  }
  private void Update() {
    if (Input.GetKeyDown(KeyCode.A))
    {
     //   Destroy();
    }
  }
   public void Destroy()
     {
        _saverInventory.CurrentSaveableSlotOfCharacter = null;
      // _saverInventory._saveableSlotOfCharacter = null;
       // SimpleCreate();
      // SaverInventory.Save(new SaveableSlotOfCharacter{CurrentSlotsOfCharacters = null, SlotOfCharacter = null, Player = null, CurrentPlayers = null});
    }
    private void SimpleCreate()
    {
    //  foreach (var playerName in _saverInventory.CurrentSaveableSlotOfCharacter.CurrentPlayerNames)
      //{
     //            CreateSlotOfPlayer(playerName,true);
      //}
       CreateStartedSlotOfPlayer("Splash");
     CreateStartedSlotOfPlayer("Stuffie");
     foreach (var player in _saverInventory.AllPlayer)
     {
       if (player.Name == "Splash" || player.Name == "Stuffie")
       {
         continue;
       }
       if (_saverInventory.CurrentSaveableSlotOfCharacter.CurrentPlayerNames.Contains(player.Name))
       {
         CreateSlotOfPlayer(player.Name,true);
       }
       else
       {
         CreateSlotOfPlayer(player.Name,false);
       }
     }
    /*   foreach (var item in SaverInventory.CurrentSaveableSlotOfCharacter.CurrentPlayerNames)
      { 
         SlotOfCharacter slotOfCharacter = Instantiate(_slotOfCharacter, transform.position, Quaternion.identity);
         Player player = _saverInventory.AllPlayer.Find(e=> e.Name == item);
         slotOfCharacter.Player = player;
         Debug.LogError(item);
         slotOfCharacter.gameObject.transform.SetParent(_spawnPosition,false);
         if(_saverInventory.CurrentSaveableSlotOfCharacter != null)
         {
         if(_saverInventory.CurrentSaveableSlotOfCharacter.CurrentSlotsOfCharacters.Contains(slotOfCharacter))
         {
        //  slotOfCharacter = _saverInventory.CurrentSaveableSlotOfCharacter.SlotOfCharacter;
         }
         else
         {
           
           //  SaverInventory.Save(new SaveableSlotOfCharacter() {SlotOfCharacter = slotOfCharacter, Player = slotOfCharacter.Player});
         }
         }
         else
         {
           //  SaverInventory.Save(new SaveableSlotOfCharacter() {SlotOfCharacter = slotOfCharacter, Player = slotOfCharacter.Player});
         }*/
     // }
    }
    private void CreateStartedSlotOfPlayer(string nameOfCharacter)
    {
      string player ="";
      player = _saverInventory.CurrentSaveableSlotOfCharacter.CurrentPlayerNames.Find(e=> e == nameOfCharacter);
      if (player == null)
      {
        return;
      }
    else if (player != "")
     {
       CreateSlotOfPlayer(player,true);
     }
    }
        private void CreateSlotOfPlayer(string player,bool isAvailable)
    {
        SlotOfCharacter slotOfCharacter = Instantiate(_slotOfCharacter, transform.position, Quaternion.identity);
            slotOfCharacter.Player = _saverInventory.AllPlayer.Find(e=> e.Name == player);
           slotOfCharacter.gameObject.transform.SetParent(_spawnPosition,false);
           slotOfCharacter.SetBackground(isAvailable);
   }

    /*
   public void SaveSaveableSlotOfCharacter(SaveableSlotOfCharacter reSaveableSlotOfCharacter)
    {
      File.WriteAllText(Application.streamingAssetsPath + "/SaveableSlotOfCharacter.json", JsonUtility.ToJson(reSaveableSlotOfCharacter));
      Load();
    }
  public void Save(SaveableSlotOfCharacter saveableSlotOfCharacter)
  {
    
      if (CurrentSaveableSlotOfCharacter != null)
        {
            _saveableSlotOfCharacter = CurrentSaveableSlotOfCharacter;
        }
        else
        {
            _saveableSlotOfCharacter  = saveableSlotOfCharacter;
        }
      //  _saveableSlotOfCharacter.CurrentSlotsOfCharacters.Add(saveableSlotOfCharacter.SlotOfCharacter);
      if(saveableSlotOfCharacter.SlotOfCharacter != null)
      {
        if(_saveableSlotOfCharacter.CurrentSlotsOfCharacters.Contains(saveableSlotOfCharacter.SlotOfCharacter))
        {
          _saveableSlotOfCharacter.CurrentSlotsOfCharacters.Remove(saveableSlotOfCharacter.SlotOfCharacter);
         _saveableSlotOfCharacter.CurrentSlotsOfCharacters.Add(saveableSlotOfCharacter.SlotOfCharacter);
         Debug.LogError("cool + save");
        }
        else
        {
            _saveableSlotOfCharacter.CurrentSlotsOfCharacters.Add(saveableSlotOfCharacter.SlotOfCharacter);
        }
      }
        File.WriteAllText(Application.streamingAssetsPath + "/SaveableSlotOfCharacter.json", JsonUtility.ToJson(_saveableSlotOfCharacter));
  }
    private void Load()
    {
    CurrentSaveableSlotOfCharacter  =  JsonUtility.FromJson<SaveableSlotOfCharacter>(File.ReadAllText(Application.streamingAssetsPath + "/SaveableSlotOfCharacter.json"));
//    CurrentSaveableSlotOfCharacter.CurrentSlotsOfCharacters.ForEach(e => Debug.LogError(e + " - ok"));
    }

    */
}
