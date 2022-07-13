using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class LoaderCharacter : MonoBehaviour
{
  public event UnityAction OnLoad;
      private SaveableSelectOfCharacter _saveableInventory;
    private SaveableSelectOfCharacter _currentSaveableSelectOfCharacter;

    public SaveableSelectOfCharacter CurrentSaveableSelectOfCharacter { get => _currentSaveableSelectOfCharacter; set => _currentSaveableSelectOfCharacter = value; }

    private void Awake() 
      {
        Load();
      }
   private void Update() {
     if (Input.GetKeyDown(KeyCode.A))
     {
         Destroy();
     }
   }
      public void Destroy()
      {
        CurrentSaveableSelectOfCharacter = null;
        _saveableInventory = null;
        
        Save(new SaveableSelectOfCharacter{Player = null, CurrentPlayers = null});
      }
    public void Save(SaveableSelectOfCharacter saveableCurrentInventory)
    {
        if (CurrentSaveableSelectOfCharacter != null)
        {
            _saveableInventory = CurrentSaveableSelectOfCharacter;
        }
        else
        {
            _saveableInventory = saveableCurrentInventory;
        }
       // if(saveableCurrentInventory.Player != null)
      //  {
      // _saveableInventory.CurrentPlayers.Add(saveableCurrentInventory.Player);
       // }
    File.WriteAllText(Application.streamingAssetsPath + "/SaveableSelectOfCharacter.json", JsonUtility.ToJson(_saveableInventory));
    }
    public void SaveSaveableCurrentInventory(SaveableSelectOfCharacter reSaveableCurrentInventory)
    {
      File.WriteAllText(Application.streamingAssetsPath + "/SaveableSelectOfCharacter.json", JsonUtility.ToJson(reSaveableCurrentInventory));
      Load();
    }
    private void Load()
    {
    CurrentSaveableSelectOfCharacter  =  JsonUtility.FromJson<SaveableSelectOfCharacter>(File.ReadAllText(Application.streamingAssetsPath + "/SaveableSelectOfCharacter.json"));
    OnLoad?.Invoke();
    }
}
