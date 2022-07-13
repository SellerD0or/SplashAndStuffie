using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBuildingButton : MonoBehaviour
{
    [SerializeField] private Image _icon;
    private Building _building;
    private ChangerBuilding _changerBuilding;
    public void ChangeIcon(Building building, ChangerBuilding changer)
    {
        _icon.sprite = building.BuildingInformation.Sprite;
        _building = building;
        _changerBuilding  = changer;
    }
    public void OnClick()
    {
        _changerBuilding.IsFromInventory = true;
        _changerBuilding.BuildingFromInvenory = _building;
        _changerBuilding.ChooseBuildng(_building, _changerBuilding.LastPlace);
    }
}
