using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCameraMovement : MonoBehaviour
{
      private float _scrolling;
    private int _sceenWidth;
     private int _sceenHeight;
  [SerializeField] private Camera _mainCamera;
 [SerializeField] private float speed;
 private Vector3 startPos;
    private Vector3 targetPos;
   private void Start() {
        _sceenHeight = Screen.height;
        _sceenWidth = Screen.width;
     
    }
    private void Update() {
        Vector3 cameraPos = transform.position;
         if (Input.GetMouseButtonDown(0))
      {
          startPos = _mainCamera.ScreenToViewportPoint(Input.mousePosition);
      }
      else if(Input.GetMouseButton(0))
      {
          if (Input.mousePosition.x < 30)
      {
           float pos = _mainCamera.ScreenToViewportPoint(Input.mousePosition).x -startPos.x;
           targetPos = new Vector3(transform.position.x - pos, transform.position.y, transform.position.z);
      }
      else  if (Input.mousePosition.y < 30)
      {
           float pos = _mainCamera.ScreenToViewportPoint(Input.mousePosition).z -startPos.z;
       targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - pos);
      }
       else  if (Input.mousePosition.x > _sceenWidth - 30)
      {
       float pos = _mainCamera.ScreenToViewportPoint(Input.mousePosition).x -startPos.x;
       targetPos = new Vector3(transform.position.x - pos, transform.position.y, transform.position.z);
      }
             else  if (Input.mousePosition.y > _sceenHeight - 30)
      {
          float pos = _mainCamera.ScreenToViewportPoint(Input.mousePosition).z -startPos.z;
       targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - pos);
      }
         
          
      }
      else
      {
       if (Input.mousePosition.x < 20)
      {
          cameraPos.x -= speed * Time.deltaTime;
      }
      else  if (Input.mousePosition.y < 20)
      {
          cameraPos.z -= speed * Time.deltaTime;
      }
       else  if (Input.mousePosition.x > _sceenWidth - 20)
      {
          cameraPos.x += speed * Time.deltaTime;
      }
             else  if (Input.mousePosition.y > _sceenHeight - 20)
      {
          cameraPos.z += speed * Time.deltaTime;
      }
      }
      transform.position = cameraPos;
      _scrolling = Input.GetAxis("Mouse ScrollWheel");
      if (_scrolling > 0 &&  _mainCamera.orthographicSize <= 6)
      {
         //  _mainCamera.orthographicSize ++;
      }
      if (_scrolling < 0 &&  _mainCamera.orthographicSize >= 3)
      {
           // _mainCamera.orthographicSize --;
      }
      
    }
}
