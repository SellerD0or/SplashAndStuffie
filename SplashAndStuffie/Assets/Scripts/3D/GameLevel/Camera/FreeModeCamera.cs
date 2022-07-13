using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeModeCamera : MonoBehaviour
{
    [SerializeField] private List< Transform> _positions;
   [SerializeField] private int _numberOfCurrentPosition;
    [SerializeField] private Transform _rightPosition;
    [SerializeField] private Transform _leftPosition;
    [SerializeField] private Transform _topPosition;
    private bool _isPressedW;
    private bool _isRightSide;
    private bool _isPressedS;
    private bool _isRechedPoint;
     private Transform _lastPosition;
     [SerializeField] private float _speed;
     [SerializeField] private float _coolDown =1 ;
     private bool _isCoolDown = true;
     private IChangedMovementEntity[] _iChangedMovementEnities;
     private void Start() {
         foreach (var item in CollectionOfChangedMovementEntities.IChangedMovementEntities)
           {
               item.SetNormal();
               item.TurnLeft();
           }
     }
   private void Update() {
       if (!_isPressedW)
       {
            Move(_positions[_numberOfCurrentPosition]);  
       }
       else 
       {
           Move(_topPosition);
       }
       if(_isCoolDown)
       {
       
       if (Input.GetKey(KeyCode.A))
       {
           foreach (var item in CollectionOfChangedMovementEntities.IChangedMovementEntities)
           {
               item.SetNormal();
               item.TurnLeft();
           }
           Turn(_positions[_numberOfCurrentPosition],false);
         _numberOfCurrentPosition++;
           if (_numberOfCurrentPosition >= _positions.Count)
           {
               _numberOfCurrentPosition = 0;
           }
           
           
       }
       else if (Input.GetKey(KeyCode.D))
       {
           foreach (var item in CollectionOfChangedMovementEntities.IChangedMovementEntities)
           {
               item.SetNormal();
               item.TurnRight();
           }
           Turn(_positions[_numberOfCurrentPosition], false);
           
             _numberOfCurrentPosition--;
           if (_numberOfCurrentPosition < 0)
           {
               _numberOfCurrentPosition = _positions.Count -1;
           }
             
       }
       else if (Input.GetKeyDown(KeyCode.W))
       {
           foreach (var item in CollectionOfChangedMovementEntities.IChangedMovementEntities)
           {
               item.SetNormal();
               item.TurnTop();
           }
             SetCameraPosition(false, true);
       }
       else if (Input.GetKey(KeyCode.S))
       {
            foreach (var item in CollectionOfChangedMovementEntities.IChangedMovementEntities)
           {
               item.SetNormal();
               item.TurnLeft();
           }
           if (_isPressedW)
           {
               _isPressedW= false;
               
           }
           else
           {
               _isPressedS = true;
             _isRightSide =   _numberOfCurrentPosition % 2 == 0 ? false : true;
                _numberOfCurrentPosition+= 2;
               if (_numberOfCurrentPosition >= _positions.Count)
              {
                  _numberOfCurrentPosition = _isRightSide ? 1:0;
               }
               _lastPosition = _positions[_numberOfCurrentPosition];
           SetCameraPosition(false, false);
           }
       }
       }
   } 
   private void Move(Transform reachedPoint)
   {

       if(_isRechedPoint == false)
       {
        transform.position = Vector3.Lerp(transform.position, reachedPoint.position, _speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, reachedPoint.rotation, _speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, reachedPoint.position) <= 0 )
        {
            _isRechedPoint = true;
        }
       }
   }
   private IEnumerator CoolDown()
   {
       _isCoolDown = false;
       yield return new WaitForSeconds(_coolDown);
       _isCoolDown = true;
   }
   private void SetCameraPosition(bool isReached,bool isPressed)
   {
       _isRechedPoint = isReached;
       _isPressedW = isPressed;
       StartCoroutine(CoolDown());
   }
   private void Turn(Transform position, bool isChoosenSide)
   {
       _isPressedS = false;
        _lastPosition = position;
          // _isRightSide = isChoosenSide;
           SetCameraPosition(false, false);
   }
}
