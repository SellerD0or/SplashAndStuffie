using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCamera : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private float _speed = 0.5f;
     [SerializeField] private float _leftLimit;
    [SerializeField] private float _rightLimit;
     [SerializeField] private float _bottomLimit;
     [SerializeField] private float _upperLimit;
     private bool _isMoving;
     private RaycastHit _hit;
    [SerializeField] private float _smoothSpeed = 5f;
    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private int _sceenWidth;
     private int _sceenHeight;

    public Vector3 TargetPosition { get => _targetPosition; set => _targetPosition = value; }

    //private List<TupleLobbyCameraInput>  _tupleLobbyCameraInputs= new List<TupleLobbyCameraInput>() {new TupleLobbyCameraInput(KeyCode.W),new TupleLobbyCameraInput(KeyCode.S), new TupleLobbyCameraInput(KeyCode.A),new TupleLobbyCameraInput(KeyCode.D) };
    private void Start() {
        _sceenHeight = Screen.height;
        _sceenWidth = Screen.width;
        _camera = Camera.main;
        TargetPosition = _camera.transform.position;
    }
   private void Update()
    {
        
       
     
    //  if (_isMoving)
   //   {
      //    transform.position = Vector3.MoveTowards(transform.position,new Vector3(_hit.transform.position.x, transform.position.y, _hit.transform.position.z), _smoothSpeed * Time.deltaTime);
         // if (Vector3.Distance(new Vector3(transform.position.x, 0,transform.position.y), new Vector3(_hit.transform.position.x, 0,_hit.transform.position.y)) < 0.5f)
       //   {
      //        _isMoving = false;
     //     }
    //  }
   // if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
    //{
           if (Input.GetKey(KeyCode.W))
       {
          Move(new Vector3(0,0,_speed));
       }
          if (Input.GetKey(KeyCode.S))
       {
          Move(new Vector3(0,0,-_speed));
       }
        if (Input.GetKey(KeyCode.A))
       {
           Move(new Vector3(-_speed,0,0));
       }
          if (Input.GetKey(KeyCode.D))
       {
           Move(new Vector3(_speed,0,0));
       }
         
    //}
  //  else
   // {
         transform.position = new Vector3(Mathf.Lerp(transform.position.x, TargetPosition.x, _smoothSpeed  *Time.deltaTime), transform.position.y, Mathf.Lerp(transform.position.z, TargetPosition.z, _smoothSpeed  *Time.deltaTime));
      if (Input.GetMouseButtonDown(1))
      {
          _startPosition = _camera.ScreenToViewportPoint(Input.mousePosition);
      }
      else if(Input.GetMouseButton(1))
      {
          Vector3 position = _camera.ScreenToViewportPoint(Input.mousePosition) -_startPosition;
          Debug.Log("cool");
          TargetPosition = new Vector3(transform.position.x - position.x, transform.position.y, transform.position.z - position.y);
      }
   //   else
  //    {
     //      if (Input.mousePosition.x < 20)
    //  {
       //   Move(new Vector3(-_speed,0,0));
     // }
     // else  if (Input.mousePosition.y < 20)
     // {
       //   Move(new Vector3(0,0,-_speed));
    //  }
     //  else  if (Input.mousePosition.x > _sceenWidth - 20)
    //  {
        //  Move(new Vector3(_speed,0,0));
    //  }
    //         else  if (Input.mousePosition.y > _sceenHeight - 20)
    //  {
         // Move(new Vector3(0,0,_speed));
     // }
     // }
  //  }
              transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, _leftLimit, _rightLimit), 
             transform.position.y,
             Mathf.Clamp(transform.position.z, _bottomLimit, _upperLimit)
        );
    }
    public void Move(Vector3 vector)
    {
       _camera.transform.position= new Vector3(_camera.transform.position.x + vector.x,_camera.transform.position.y, _camera.transform.position.z +vector.z );
       TargetPosition = _camera.gameObject.transform.position;
    }
}
public struct TupleLobbyCameraInput
{
    public TupleLobbyCameraInput(KeyCode keyCode)
    {
       KeyCode = keyCode;
    }
    public KeyCode KeyCode { get; set; }
}