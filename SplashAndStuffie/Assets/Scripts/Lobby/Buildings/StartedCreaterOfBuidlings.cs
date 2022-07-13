using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartedCreaterOfBuidlings : MonoBehaviour
{
    [SerializeField] private SaverBuilding _saverBuidling;
    private List<Building> _currentBuildings;
    [SerializeField] private Redactor _redactor;
    [SerializeField] private List<Building> _baseBuidling;


    private void Start() 
    {
        if(_redactor.SaverBuidling.CurrentSaveableBuidling.CurrentBuildingNames.Count > 0)
        {
        // foreach (var item in _saverBuidling.CurrentSaveableBuidling.CurrentBuildingNames)
        // {
           /*  int number= item.IndexOf(',');
             Debug.Log(item.Length -1 + " " + item);
             string areaOfName = item.Remove(number,item.Length -1);
             
             string nameOfBuilding = areaOfName;
             string areaOfPlace = item.Remove(0,number + 1);
             areaOfName.Replace(" ", "");
             int numberOfPlace =Convert.ToInt32(areaOfPlace);
            Building building = _allTheBuilding.Find(e=> e.Name == nameOfBuilding);
            Place place = _redactor.Places.Find(e=> e.NumberOfPlace == numberOfPlace); 
           place.CreateBuilding(building,true);
         }
         */
         
        } 
        else
        {
            _redactor.Places[2].CreateBuilding(_baseBuidling[0],true);
           _redactor.Places[6].CreateBuilding(_baseBuidling[1],true);
            _redactor.Places[11].CreateBuilding(_baseBuidling[2],true);
            _redactor.Places[20].CreateBuilding(_baseBuidling[3],true);

        }   
    }
}
