using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChecker : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed = 5;
    private void Update() {
        transform.position = new Vector3( _camera.transform.position.x, transform.position.y);
    }
   private void OnTriggerEnter2D(Collider2D other) {
         if (other.TryGetComponent<BackgroundPartOfForest>(out BackgroundPartOfForest backgroundPartOfForest))
         {
             Debug.Log("WE TRIGGER BACHROUND!!!");
             backgroundPartOfForest.TurnOn();
         }
     }
    private void OnTriggerExit2D(Collider2D other) {
          if (other.TryGetComponent<BackgroundPartOfForest>(out BackgroundPartOfForest backgroundPartOfForest))
         {
             backgroundPartOfForest.TurnOff();
         }
     }
}
