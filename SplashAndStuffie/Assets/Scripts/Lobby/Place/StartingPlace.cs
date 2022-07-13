using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPlace : Place
{
    [SerializeField] private Building _startingBuilding;
    private void Start() {
     //  CreateBuilding(_startingBuilding,true);
    }
}
