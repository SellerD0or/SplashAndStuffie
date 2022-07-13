using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Redactor : MonoBehaviour
{
   // [SerializeField] private List<Button> _buttons;
   private bool _isClicked;
   [SerializeField] private CanvasGroup _exitButton;
   [SerializeField] private CanvasGroup _settingButton;
   [SerializeField] private CanvasGroup _redactorButton;
    public bool IsClicked { get => _isClicked; set => _isClicked = value; }
    public InventoryOfBuildings InventoryOfBuildings { get => _inventoryOfBuildings; set => _inventoryOfBuildings = value; }
    public List< Place> Places { get => _places; set => _places = value; }
    public SaverBuilding SaverBuidling { get => _saverBuidling; set => _saverBuidling = value; }

    [SerializeField] private EditorButton _editorButton;
    [SerializeField] private CanvasGroup _canvasGroup;
      [SerializeField]  private InventoryOfBuildings _inventoryOfBuildings;
      [SerializeField] private Animator _superHexagon;
      [SerializeField] private InventoryOfBuildings _inventory;
      [SerializeField] private List<Place> _places;
      [SerializeField] private ChangerBuilding _changerBuilding;
      [SerializeField]private SaverBuilding _saverBuidling;
      [SerializeField] private List<RoadOfPlaces> _roadOfPlaces;
      [SerializeField] private RedactorChest _redactorChest;
      private string _lastBuilding;
    private void Awake() {
       _roadOfPlaces.ForEach(e=> e.Places.ForEach(e=>_places.Add(e)));
       _places.ForEach(e=>e.Redactor = this);
    }
    public void Save(Building building,Place place)
    {
       bool isOriginal = true;
       building.name = building.Name + "," + place.NumberOfPlace;
       int number= building.name.IndexOf(',');
       string text = building.name.Remove(0,number +1);
          int numberOfPlace =Convert.ToInt32(text);
      Debug.Log(building.name);
      List<int> numberOfPlaces = new List<int>();
      List<string> currentBuildingNames = new List<string>();
      foreach (var item in SaverBuidling.CurrentSaveableBuidling.CurrentBuildingNames)
      {
      int indexOfPosition = item.IndexOf(',');
      string pos = item.Remove(0,indexOfPosition +1);
        int currentNumberOfPlace =Convert.ToInt32(pos);
      string nameOfBuilding = item.Substring(0, indexOfPosition);
      Debug.LogError("Building: " + nameOfBuilding + ", Place: " + currentNumberOfPlace);
      numberOfPlaces.Add(currentNumberOfPlace);
      currentBuildingNames.Add(nameOfBuilding);
      } 
      if (currentBuildingNames.Contains(building.Name))
      {
        /* foreach (var name in SaverBuidling.CurrentSaveableBuidling.CurrentBuildingNames)
         {
            int indexOfName = name.IndexOf(',');
            string nameOfBuilding2 = name.Substring(0,indexOfName);
            string word = name;
            if (nameOfBuilding2 ==_lastBuilding )
            {
               SaverBuidling.CurrentSaveableBuidling.CurrentBuildingNames.Remove(word);
                  SaverBuidling.CurrentSaveableBuidling.CurrentBuildingNames.Add(building.name);
               _lastBuilding = nameOfBuilding2;
               break;
            }
         }*/
                 //  if(SaverBuidling.CurrentSaveableBuidling.CurrentBuildingNames.Contains(SaverBuidling.CurrentSaveableBuidling.LastBuildingName))
                  //{
                 // Debug.LogError("REMOVE ALL!!! LAst Building: "  + SaverBuidling.CurrentSaveableBuidling.LastBuildingName + ", Current building: " + building.name);
                 // SaverBuidling.CurrentSaveableBuidling.CurrentBuildingNames.Remove(SaverBuidling.CurrentSaveableBuidling.LastBuildingName);
                  // SaverBuidling.CurrentSaveableBuidling.CurrentBuildingNames.Add(building.name);
                 // }
                  //_lastBuilding = building.name;
                 isOriginal = false;
                  if(numberOfPlaces.Contains(numberOfPlace) == false)
                  {
         //SaverBuidling.CurrentSaveableBuidling.CurrentBuildingNames.Remove(building.name);
                 Debug.Log(building.name + " it's needed to remove!");
               //  SaverBuidling.CurrentSaveableBuidling.CurrentBuildingNames.Add(building.name);
               // SaverBuidling.CurrentSaveableBuidling.LastBuildingName = building.name;
                  }
                           //SaverBuidling.SaveSaveableCurrentBuilding(SaverBuidling.CurrentSaveableBuidling);

                // SaverBuidling.Save(new SaveableBuilding() {BuildingName = building.Name + ",", NumberOfPlace = place.NumberOfPlace, LastBuildingName =building.name});
      }
     /* if(SaverBuidling.CurrentSaveableBuidling.CurrentBuildingNames.Contains(building.name))
      {
         Debug.LogError("YES. It contains");
       foreach (var item in SaverBuidling.CurrentSaveableBuidling.CurrentBuildingNames)
         {
             int placeNumber= item.IndexOf(',');
           string pos = item.Remove(0, placeNumber +1);
             int currentNumberOfPlace =Convert.ToInt32(pos);
             if (numberOfPlace == currentNumberOfPlace)
             {
               if (!SaverBuidling.CurrentSaveableBuidling.CurrentBuildingNames.Contains(building.name))
              {
                 SaverBuidling.CurrentSaveableBuidling.CurrentBuildingNames.Remove(building.name);
                 Debug.Log(building.name + " it's needed to remove!");
                 SaverBuidling.SaveSaveableCurrentBuilding(SaverBuidling.CurrentSaveableBuidling);
               //  SaverBuidling.CurrentSaveableBuidling.CurrentBuildingNames.Add(building.name);
                SaverBuidling.CurrentSaveableBuidling.LastBuildingName = building.name;
                 SaverBuidling.Save(new SaveableBuilding() {BuildingName = building.Name + ",", NumberOfPlace = place.NumberOfPlace, LastBuildingName =building.name});
              }
              Debug.Log(isOriginal);
              isOriginal = false;
                break;
             }
         } 
      }*/
     // else
         if (isOriginal)
         {
            Debug.LogError("SAAAAAAAAVEEEEEEEEEEE");
           // SaverBuidling.CurrentSaveableBuidling.CurrentBuildingNames.Add(building.name);
            SaverBuidling.CurrentSaveableBuidling.LastBuildingName = building.name;
            SaverBuidling.Save(new SaveableBuilding() {BuildingName = building.name, LastBuildingName =building.name});
         }
    }
    public void ChangeStateOf()
   {
      CreatorBuildings.ChangedState =! CreatorBuildings.ChangedState;
       IsClicked =! IsClicked;
       _canvasGroup.blocksRaycasts = IsClicked;
       Close(IsClicked);
       _exitButton.blocksRaycasts = IsClicked;
       _superHexagon.SetBool("InRedactor",!IsClicked);
       _exitButton.alpha = _isClicked ? 1 : 0;
       _editorButton.ChangeStateOfEditorButton(IsClicked);
       if (IsClicked == false)
       {
          if(_redactorChest.IsMoving == true)
          {
          _redactorChest.ChangeStateOfRedactorButton();
          }
       }
      // if(!IsClicked)
      // {
          Debug.Log("Close inventory");
          foreach (var item in Places)
          {
              item.Mesh.enabled =_isClicked;
          }
           _inventory.GetComponent<Animator>().SetBool("IsMoving",false);
       //}
      // _buttons.ForEach
   }
   public void Close(bool _isChanged)
   {
      Debug.LogError(_isClicked + " dasas");
      
      _settingButton.blocksRaycasts = !_isChanged;
       _redactorButton.blocksRaycasts = !_isChanged;
       _redactorButton.alpha = _isChanged ? 0 : 1;
       _settingButton.alpha = _isChanged ? 0 : 1;
             _changerBuilding.RemoveChoosenBuilding();

   }
   private void OnDisable() {
      IsClicked = false;
    
   }
   public void CloseScene()
   {
        SaverBuidling.Destroy();
      foreach (var place in Places)
      {
         if (place.CurrentBuilding != null)
         {
            place.Save();
         }
      }
   }
   
}
