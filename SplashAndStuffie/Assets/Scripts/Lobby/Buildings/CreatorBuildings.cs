using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreatorBuildings : MonoBehaviour
{
    [SerializeField] private List<Building> _allTheBuilding;
    [SerializeField] ChangerBuilding _changerBuildings;
   [SerializeField] private LobbyCamera _lobbyCamera;
   [SerializeField] private Redactor _redactor;
   private bool _isActive;
   private Camera _camera;
   private bool _isMoving;
   private Place _currentPlace;
   [SerializeField] private GameObject _button;
   private static bool _selectBuilding;

    public static bool SelectBuilding { get => _selectBuilding; set => _selectBuilding = value; }
    public static bool ChangedState { get => _changedState; set => _changedState = value; }

    private static bool _changedState = true;
    private Place _lastPlace;
    [SerializeField] private bool _canCreate;
    private int _numberOfPlace;
    private  List<Place> _places = new List<Place>();
    private void OnEnable() {
         SelectBuilding = false;
         ChangedState = true;
    }
    private void Start() {
       
       _camera  =_lobbyCamera.GetComponent<Camera>();
       //Check();
   }
   private void Update() {
       if (Input.GetMouseButtonDown(0) && !SelectBuilding)
       {
           RaycastHit  hit;
           Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
          
           if (Physics.Raycast(ray, out hit))
           {
               if (hit.collider.TryGetComponent<Place>(out Place place))
               {
                   _currentPlace = place;
                   Debug.Log(place.IsFull);
                    if(place.IsFull == false)
                    {
                        if (!ChangedState)
                        {
                            if(_changerBuildings.HaveItem)
                            {
                                Debug.Log("Rechange");
                            //     if(_changerBuildings.IsFromInventory == false)
                            //  {
                              place.CreateBuilding(_changerBuildings.Building,!_changerBuildings.IsFromInventory);
                            //  }
                              
                              _changerBuildings.RemoveChoosenBuilding();
                               if(_changerBuildings.IsFromInventory == false)
                              {
                             _lastPlace.RemoveBuilding();
                              }
                              else
                              {
                                  Debug.Log(_changerBuildings.BuildingFromInvenory.Name);
                                Check();
                                //  _changerBuildings.LastPlace.RemoveBuilding();// _allTheBuilding.Find(e=> e.Name==_changerBuildings.BuildingFromInvenory.Name );
                                 //  _lastPlace.RemoveBuilding();
                                  _changerBuildings.IsFromInventory = false;
                              }
                            }
                          //  else if(!_changerBuildings.HaveItem && _canCreate)
                           // {
                            //        int random = Random.Range(0,_changerBuildings.Buildings.Count);
                 //   place.CreateBuilding(_changerBuildings.Buildings[random]);
                   //         }
                        }
                    }
                    else
                    {
                        if(_changerBuildings.HaveItem)
                         {
                             if(place.CurrentBuilding == null)
                             {
                              place.CreateBuilding(_changerBuildings.Building,true);
                              _changerBuildings.RemoveChoosenBuilding();
                             _lastPlace.RemoveBuilding();
                             
                             }
                             else
                             {
                              _lastPlace.RemoveBuilding();   
                              place.RemoveBuilding();   
                              Building building = _lastPlace.CurrentBuilding; 
                              Building building1 = place.CurrentBuilding;           
                                 Place tempPlace = place;
                                 place = _lastPlace;
                                 _lastPlace = tempPlace; 
                                 place.CreateBuilding(building1,false);
                             _lastPlace.CreateBuilding(building,false);    
                             _changerBuildings.HaveItem = true;
                          _changerBuildings.RemoveChoosenBuilding(); 
                                  }
                        }

                        if(!ChangedState)
                    {
                        _changerBuildings.ChooseBuildng(place.CurrentBuilding, place);
                        _lastPlace =place;
                              Debug.Log("Rechange");
                       // Debug.Log(_lastPlace.CurrentBuilding + _lastPlace.name);
                      //  _lastPlace.CurrentBuilding.Checker.Disappear();
                    }
                     else
                     {
                         _isActive =! _isActive;
                         Debug.Log(_isActive  + "|asasdes");
                            _redactor.Close(_isActive);
                        //    place.CurrentBuilding.Checker.Appear();
                        _numberOfPlace = _currentPlace.Road.Places.IndexOf(_currentPlace);
                        
                        if(_numberOfPlace + 1 < _currentPlace.Road.Places.Count && _currentPlace.Road.Places[_numberOfPlace +1].CurrentBuilding != null)
                        {
                            
                        _currentPlace.Road.Places[_numberOfPlace +1].CurrentBuilding.gameObject.SetActive(false);
                        }
                         if(_numberOfPlace + 2 < _currentPlace.Road.Places.Count && _currentPlace.Road.Places[_numberOfPlace +2].CurrentBuilding != null)
                        {
                            
                        _currentPlace.Road.Places[_numberOfPlace +2].CurrentBuilding.gameObject.SetActive(false);
                        }
                       ChangeState(0,false,_currentPlace.CurrentBuilding.BuildingInformation.NameOfMovementAnimation);
                       _isMoving =true;
                       SelectBuilding = true;
                         
                         place.CurrentBuilding.Open();
                     }
                    }
               }
           }
       }
       if (_isMoving)
       {
           if (Vector3.Distance(new Vector3(_camera.gameObject.transform.position.x, _camera.gameObject.transform.position.y,_camera.gameObject.transform.position.z), new Vector3(_currentPlace.CameraPosition.position.x + 1, _currentPlace.CameraPosition.position.y, _currentPlace.CameraPosition.position.z)) > 0.2f)
           {
           _camera.transform.position = Vector3.Lerp(_camera.gameObject.transform.position,_currentPlace.CameraPosition.position + new Vector3(1,0,0), 5 * Time.deltaTime);
           }
           else
           {
               _button.SetActive(true);
               _isMoving = false;
           }
       }
   }
   public void Check()
   {
         foreach (var item in _redactor.Places)
        {
               if(!_places.Contains(item))
           {
             if(item.CurrentBuilding != null)
             {
             _places.Add(item);
             }
            }
                else
            {
                   if(item.CurrentBuilding == null)
                  {
                       _places.Remove(item);
                 }
                        
            }
         }
        Place place1  = _places.Find(e=> e.CurrentBuilding.Name == _changerBuildings.BuildingFromInvenory.Name);
        Debug.Log(place1.name + " UKRAINE IS THE BEST COUNTRY!!!");
        place1.RemoveBuilding();

   }
   public void Exit()
   {
      if(ChangedState)
      {
          _isActive =! _isActive;
       _redactor.Close(_isActive);
      }
        if(_numberOfPlace + 1 < _currentPlace.Road.Places.Count && _currentPlace.Road.Places[_numberOfPlace +1].CurrentBuilding != null)
            {              
             _currentPlace.Road.Places[_numberOfPlace +1].CurrentBuilding.gameObject.SetActive(true);
             }
             if(_numberOfPlace + 2 < _currentPlace.Road.Places.Count && _currentPlace.Road.Places[_numberOfPlace +2].CurrentBuilding != null)
            {              
             _currentPlace.Road.Places[_numberOfPlace +2].CurrentBuilding.gameObject.SetActive(true);
             }
       ChangeState(60,true,_currentPlace.CurrentBuilding.BuildingInformation.NameOfIdleAnimation);
       _camera.transform.position = _lobbyCamera.TargetPosition;
       _button.SetActive(false);
       _currentPlace.CurrentBuilding.Close();
       
       SelectBuilding = false;
   }
   public void ChangeState(float _rotation, bool _enabled, string _animation)
   {
       _currentPlace.CurrentBuilding.BuildingInformation.UnityArmatureComponent.animation.Play(_animation);
        _camera.transform.rotation = Quaternion.Euler(_rotation,0,0);
        _lobbyCamera.enabled = _enabled;
   }
}
