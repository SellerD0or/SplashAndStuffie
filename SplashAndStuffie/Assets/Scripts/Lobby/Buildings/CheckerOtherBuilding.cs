using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerOtherBuilding : MonoBehaviour
{
   [SerializeField] private BoxCollider _collider;
   private bool _isDisactived;
   [SerializeField] private List<Building> _buildings = new List<Building>();
   public void Disappear()
   {
       _collider.enabled =false;
       _isDisactived = true;
       Debug.Log(_collider.enabled + " sss disappear");
   }
    public void Appear()
   {
       _collider.enabled =true;
       _isDisactived = false;
       foreach (var item in _buildings)
       {
           item.Appear();
       }
              Debug.Log(_collider.name + " sss appear");

   }
   private void OnTriggerExit(Collider other)
   {
        if (other.TryGetComponent<Place>(out Place place) && _isDisactived)
       {
           _buildings.Remove(place.CurrentBuilding);
       }
   }
   private void OnTriggerEnter(Collider other) {
       if (other.TryGetComponent<Place>(out Place place) && _isDisactived)
       {
           _buildings.Add(place.CurrentBuilding);
       }
   }
   private void OnTriggerStay(Collider other) {
    if (other.TryGetComponent<Place>(out Place place) && _isDisactived)
       {
        place.CurrentBuilding.Disappear();
       }
   }

}
