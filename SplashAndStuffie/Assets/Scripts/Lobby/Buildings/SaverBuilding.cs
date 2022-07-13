using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaverBuilding : MonoBehaviour
{
      [SerializeField] private List<Building> _allTheBuilding;
      private readonly string _filePath = Application.streamingAssetsPath + "/Save.json";
      private SaveableBuilding _saveableBuilding;
    private SaveableBuilding _currentSaveableBuidling;
      public List<Building> AllTheBuilding { get => _allTheBuilding; set => _allTheBuilding = value; }
    public SaveableBuilding CurrentSaveableBuidling { get => _currentSaveableBuidling; set => _currentSaveableBuidling = value; }
     private void Awake() 
      {
       Load();
      }
      public void Save(SaveableBuilding saveableCurrentInventory)
    {
        if (CurrentSaveableBuidling != null)
        {
            _saveableBuilding = CurrentSaveableBuidling;
        }
        else
        {
            _saveableBuilding = saveableCurrentInventory;
        }
        if(saveableCurrentInventory.BuildingName != "" && saveableCurrentInventory.NumberOfPlace >=0)
        {
          Debug.Log(saveableCurrentInventory.BuildingName);
       _saveableBuilding.CurrentBuildingNames.Add(saveableCurrentInventory.BuildingName);
       
        }
        if (saveableCurrentInventory.LastBuildingName != "")
        {
     //     _saveableBuilding.LastBuildingName = saveableCurrentInventory.LastBuildingName;
        }
              int value =0;
      value= PlayerPrefs.GetInt("GameSlot",value);
    File.WriteAllText(Application.streamingAssetsPath + $"/SaveableBuilding{value}.json", JsonUtility.ToJson(_saveableBuilding));
    }
    public void Destroy()
    {
      CurrentSaveableBuidling.CurrentBuildingNames = new List<string>();
      CurrentSaveableBuidling.LastBuildingName = "";
      SaveSaveableCurrentBuilding(CurrentSaveableBuidling);
    }
    public void SaveSaveableCurrentBuilding(SaveableBuilding reSaveableCurrentBuilding)
    {
      int value =0;
      value= PlayerPrefs.GetInt("GameSlot",value);
      File.WriteAllText(Application.streamingAssetsPath + $"/SaveableBuilding{value}.json", JsonUtility.ToJson(reSaveableCurrentBuilding));
      Load();
    }
    private void Load()
    {
       int value =0;
      value= PlayerPrefs.GetInt("GameSlot",value);
    CurrentSaveableBuidling  =  JsonUtility.FromJson<SaveableBuilding>(File.ReadAllText(Application.streamingAssetsPath + $"/SaveableBuilding{value}.json"));
    }
}
