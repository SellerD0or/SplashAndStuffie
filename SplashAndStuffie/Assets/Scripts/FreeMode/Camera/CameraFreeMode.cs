using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFreeMode : MonoBehaviour
{
  [SerializeField] private GeneratorFreeMode _generator;
    [SerializeField] private float _minDistance = 2, _maxDistance = 10;
    private Camera _camera;
       [SerializeField] private List< Transform> _positions;
   [SerializeField] private int _numberOfCurrentPosition;
    [SerializeField] private Transform _rightPosition;
    [SerializeField] private Transform _leftPosition;
    [SerializeField] private Transform _fullViewPosition;
    private Transform _lastPosition;
    [SerializeField] private Transform _topPosition;
    private bool _isPressedW;
    [SerializeField] private float _step = 2f;
    private bool _isPressedS;
    private bool _isRechedPoint;
     [SerializeField] private float _speed;
     [SerializeField] private float _coolDown =1 ;
     private bool _isCoolDown = true;
     private bool _isFullViewMode;
         [SerializeField] private float _smoothSpeed = 5f;
         [SerializeField] private float _size = 2f;
         private Vector3 _targetZoomPosition;

         private Vector3 _targetPosition;
             private Vector3 _startPosition;
         public Vector3 TargetPosition { get => _targetPosition; set => _targetPosition = value; }
         private bool _isZoomed;
         [SerializeField] private GameObject _childObject;
          [SerializeField] private float _leftLimit;
    [SerializeField] private float _rightLimit;
     [SerializeField] private float _bottomLimit;
     [SerializeField] private float _upperLimit;
     public float CurrentOrthograthicSize { get; set; }
    public bool CanUsed { get => _canUsed; set => _canUsed = value; }
    public Camera Camera { get => _camera; set => _camera = value; }

    [SerializeField] private float _additionPositionForChildObject = 1;
     [SerializeField] private BackgroundOfCardFreeMode _background;
     private bool _canUsed = true;
     private void Start() {
        Camera = Camera.main;
        TargetPosition = Camera.transform.position;
         _lastPosition = _topPosition;
     }
   private void Update() {
             transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, _leftLimit, _rightLimit), 
             Mathf.Clamp(transform.position.y, _bottomLimit, _upperLimit), 
             transform.position.z
        );
        if(CanUsed)
        {

        
       if (Input.GetKeyDown(KeyCode.Alpha1))
       {
          
            Turn(_rightPosition,false);
                        _generator.SetFirstPosition();

       }
       else  if (Input.GetKeyDown(KeyCode.Alpha2))
       {
           Turn(_leftPosition,false);
                       _generator.SetSecondPosition();

       }
         else  if (Input.GetKeyDown(KeyCode.Alpha3))
       {
            Turn(_topPosition,false);
            _childObject.transform.localScale = new Vector3(0.748153f,0.748153f,1);
                Camera.orthographicSize = 6;
                _background.Stop();
                            _generator.SetThirdPosition();


       }
         else  if (Input.GetKeyDown(KeyCode.Alpha4))
       {
           SetFullScreen();
       }
        }
   } 
   public void SetFullScreen()
   {
       Turn(_fullViewPosition,true);
            _childObject.transform.localScale = new Vector3(1.621f,1.621f,1);
            Camera.orthographicSize = 13;
            _background.Stop();
            _generator.SetFullScreenPosition();
   }
   private void Move(Transform reachedPoint)
   {

       if(_isRechedPoint == false)
       {
        Vector2 reacedPosition = Vector2.Lerp(transform.position, new Vector2(reachedPoint.position.x, reachedPoint.position.y), _speed * Time.deltaTime);
       transform.position = new Vector3(reacedPosition.x,reacedPosition.y,-10);
        if (Vector2.Distance(transform.position, reachedPoint.position) <= 0 )
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
     
       _childObject.transform.localScale = new Vector3(0.6237f, 0.6237f,1);
       _isFullViewMode = isChoosenSide;
       _isPressedS = false;
        Camera.orthographicSize = 5;
        transform.position = new Vector3( position.position.x ,position.position.y,-10);
        _lastPosition = position;
        _background.Stop();
          // _isRightSide = isChoosenSide;
           SetCameraPosition(false, false);
   }
}
