using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BuildingInformation))]

public abstract class Building : MonoBehaviour
{
   [SerializeField] private string _name;   
    public abstract BuildingInformation BuildingInformation { get ; set ; }
     public abstract Signboard Signboard {get;set;}
    public CheckerOtherBuilding Checker { get => _checker; set => _checker = value; }
    public string Name { get => _name; set => _name = value; }

    //public abstract Sprite Sprite { get ; set; }
    public void Disappear() => gameObject.SetActive(false);
    public void Appear() => gameObject.SetActive(true);
    [SerializeField] private CheckerOtherBuilding _checker;
    public abstract void Open();
    public abstract void Close();
}
