using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Place : MonoBehaviour
{
  [SerializeField] private int _numberOfPlace;
  [SerializeField] private float _waitTime = 3f;
  [SerializeField] private MeshRenderer _meshRenderer;
  [SerializeField] private Material _selectedMaterial;
  [SerializeField] private Material _unselectedMaterial;
  [SerializeField] private Material _fullMaterial;
  private Building _currentBuilding;
  [SerializeField] private Transform _spawnPosition;
  private bool _isFull = false;
  [SerializeField] private Transform _cameraPosition;
    public Building CurrentBuilding { get => _currentBuilding; set => _currentBuilding = value; }
    public bool IsFull { get => _isFull; set => _isFull = value; }
    public Transform CameraPosition { get => _cameraPosition; set => _cameraPosition = value; }
    public Redactor Redactor { get => _redactor; set => _redactor = value; }
    public MeshRenderer Mesh { get => _mesh; set => _mesh = value; }
    public int NumberOfPlace { get => _numberOfPlace; set => _numberOfPlace = value; }
    public RoadOfPlaces Road { get => _road; set => _road = value; }

    [SerializeField] private MeshRenderer _mesh;
   [SerializeField]   private Redactor _redactor;
 [SerializeField]  private RoadOfPlaces _road;
   // private void OnEnable() {
     //Road = GetComponentInParent<RoadOfPlaces>();
  //   Redactor = FindObjectOfType<Redactor>();
     // this.AddPlace();

    //}
  //  private void OnEnable() {
    //  if(!CreatorBuildings.SelectBuilding)
   //   {
    //    Mesh.enabled =false;
     // }
      // Redactor = FindObjectOfType<Redactor>();
   // }
   private void Start() {
     if(_redactor.SaverBuidling.CurrentSaveableBuidling.CurrentBuildingNames.Count > 0)
     {
      foreach (var item in _redactor.SaverBuidling.CurrentSaveableBuidling.CurrentBuildingNames)
      {
       int indexOfPosition = item.IndexOf(',');
       int lastLetter = item.Length - 1;
       string pos = item.Remove(0, indexOfPosition +1);
       string nameOfBuilding = item.Substring(0, indexOfPosition);
       Debug.LogError(nameOfBuilding);
        //Debug.Log(item + " : " + text.Length + " " + lastLetter.ToString());
      // string pos = item.Remove(text.Length,lastLetter );
       int currentNumberOfPlace =Convert.ToInt32(pos);
     //  Debug.Log("cyrrentPosition: " + _numberOfPlace+ ", position which needs: "+ currentNumberOfPlace);
       if (_numberOfPlace == currentNumberOfPlace)
       {
         Building building = _redactor.SaverBuidling.AllTheBuilding.Find(e=>e.Name == nameOfBuilding);
            CreateBuilding(building,true);
         _redactor.Save(building,this);
       //  Debug.LogError("WE NEED TO CrEAETE HERE!!");
       }
       }
     } 
   }
   public void Save()
   {
         _redactor.Save(_currentBuilding,this);
   }
    public void CreateBuilding(Building building, bool isChangePosition)
  {
    if(IsFull == false)
    {
   Building selectedBuilding = Instantiate(building,_spawnPosition.position, Quaternion.identity);
   _redactor.Save(selectedBuilding, this);
   if(isChangePosition)
   {
     _redactor.InventoryOfBuildings.Add(building);
   }
  CurrentBuilding = selectedBuilding;
  IsFull = true;

    }
  }
  public void RemoveBuilding()
  {
     _redactor.InventoryOfBuildings.Remove(CurrentBuilding);
    Destroy(CurrentBuilding.gameObject);
    IsFull =false;
    
  }
  public void OnClick()
  {
  }
  public void OnEnter()
  {
    Debug.Log("UYEEEEEEEEEESasdsas");
    if(!CreatorBuildings.SelectBuilding && Redactor.IsClicked)
    _meshRenderer.material = IsFull ? _fullMaterial : _selectedMaterial;
  }
  public void OnExit()
  {
   StartCoroutine(CoolDown());
  }
  private IEnumerator CoolDown()
  {
    yield return new WaitForSeconds(_waitTime);
    _meshRenderer.material = _unselectedMaterial;
  }


}
