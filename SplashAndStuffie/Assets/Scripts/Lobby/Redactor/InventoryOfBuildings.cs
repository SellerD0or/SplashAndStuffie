using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryOfBuildings : MonoBehaviour
{
 [SerializeField] private List<Building> _buildings = new List<Building>();
  public event UnityAction OnAdd;
  public event UnityAction OnRemove;
  public Building LastBuilding { get; set; }
  public void Add(Building building)
  {
      LastBuilding = building;
      _buildings.Add(building);
      OnAdd?.Invoke();
  }
  public void Remove(Building building)
  {
      if(_buildings.Contains(building))
      {
      _buildings.Remove(building);
      OnRemove?.Invoke();
      }
  }
}
