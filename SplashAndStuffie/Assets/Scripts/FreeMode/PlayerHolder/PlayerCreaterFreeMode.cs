using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreaterFreeMode : MonoBehaviour
{
    [SerializeField] private DisplayerSelectedPlayerFreeMode _displayer;
    private Camera _camera;
    [SerializeField] private float _distanceForCreating = 6;
    private void Start() {
        _camera = _displayer.CameraFreeMode.GetComponent<Camera>();
    }
    private void Update() {
        if(Input.GetMouseButtonDown(0) && _displayer.HavePlayer && _displayer.CameraFreeMode.CurrentOrthograthicSize < _distanceForCreating)
        {
            Vector2 position = _camera.ScreenToWorldPoint(Input.mousePosition);
         RaycastHit2D  hit = Physics2D.Raycast(position,Vector2.zero);
          if (hit.collider != null)
          {
           
               if (hit.collider.TryGetComponent<PlaceFreeMode>(out PlaceFreeMode place) && _displayer.CameraFreeMode.Camera.orthographicSize < 7)
               {
                   Debug.LogError(place + " YOU CAN PUT!!!");
                   place.CreatePlayer(_displayer.Player, _displayer.LastPlayerIcon);
                   _displayer.Disappear();
               }
         }
    }
    }
}
