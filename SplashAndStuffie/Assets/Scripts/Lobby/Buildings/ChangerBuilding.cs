using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangerBuilding : MonoBehaviour
{
    private Building _buildingFromInvenory;
    private Place _placeFromInventory;
    private bool _haveBuildng;
    private Building _building;
    private bool _isFromInventory = false;
    [SerializeField] private List<Building> _buildings;

    public List<Building> Buildings { get => _buildings; set => _buildings = value; }
    [SerializeField] private Image _icon;
    [SerializeField] private CanvasGroup _canvasGroup;
    public Image Icon { get => _icon; set => _icon = value; }
    public bool HaveItem { get => _haveBuildng; set => _haveBuildng = value; }
    public Building Building { get => _building; set => _building = value; }
    public Place LastPlace { get => _lastPlace; set => _lastPlace = value; }
    public bool IsFromInventory { get => _isFromInventory; set => _isFromInventory = value; }
    public Building BuildingFromInvenory { get => _buildingFromInvenory; set => _buildingFromInvenory = value; }
    public Place PlaceFromInventory { get => _placeFromInventory; set => _placeFromInventory = value; }

    private Place _lastPlace;
    private void Start() {
        Disactive();
    }
    private void Update() {
        _icon.transform.position =Input.mousePosition;
    }
       public void ChooseBuildng(Building building, Place place)
   {
       if(HaveItem == false)
       {
       Building = building;
       _haveBuildng = true;
       _canvasGroup.alpha = 1;
       _icon.sprite = building.BuildingInformation.Sprite;
       LastPlace = place;
       }
   }
   public void RemoveChoosenBuilding()
   {
              Debug.Log("BEfore " + HaveItem);

       if (HaveItem)
       {
           Building = null;
           _haveBuildng = false;
           Disactive();
           _icon.sprite =null;
                  
            Debug.Log("REMOVE "+ HaveItem);

       }
   }
    private void Disactive() => _canvasGroup.alpha = 0;
}
