using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedSlotsGetterComputer : MonoBehaviour
{
    [SerializeField] private CameraFilterPack_NewGlitch3 _glitchEffect;
   [SerializeField] private List<GameObject> _objects;
   [SerializeField] private float _timeForStopping = 3;
   private void Start() {
       Invoke(nameof(StopAnimation),_timeForStopping);
   }
   private void StopAnimation()
   {
       foreach (var item in _objects)
       {
           item.SetActive(true);
       }
       _glitchEffect.enabled = true;
       gameObject.SetActive(false);
   }
}
