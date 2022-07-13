using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MoveableCamera : MonoBehaviour
{
    [SerializeField] private GetterPlayer _getterPlayer;
   [SerializeField] private Player _player;
    [SerializeField] private float _speed = 5;
    [SerializeField] private Vector3 _offset;
   
     private Vector2 _velocity;
     [SerializeField] private float _leftLimit;
    [SerializeField] private float _rightLimit;
     [SerializeField] private float _bottomLimit;
     [SerializeField] private float _upperLimit;
     private Player _currentPlayer;
     private bool _isShaked;

    public bool IsShaked { get => _isShaked; set => _isShaked = value; }
    public Player CurrentPlayer { get => _currentPlayer; set => _currentPlayer = value; }

    private Vector3 _cameraPosition;
    private bool _isMovingBack;
    private Vector3 _startPosition;

    private void Start() 
    {
        _player = _getterPlayer.CreatedPlayer;
        _getterPlayer.OnDestroy += GetPlayer;
    }
   private void Update()
    {
          if (IsShaked == false)
          {
              transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, _leftLimit, _rightLimit), 
             Mathf.Clamp(transform.position.y, _bottomLimit, _upperLimit), 
             transform.position.z
        );
          }
          else
          {
              if(_isMovingBack == false)
              {
              transform.position = Vector3.Lerp(transform.position, _cameraPosition,10 * Time.deltaTime);
              if (Vector2.Distance(transform.position, _cameraPosition) < 1)
              {
                  _isMovingBack = true;
              }
              }
              else
              {
                     transform.position = Vector3.Lerp(transform.position, _startPosition,10 * Time.deltaTime);
                       if (Vector2.Distance(transform.position, _startPosition) < 0.1)
              {
                  _isMovingBack = false;
                  IsShaked = false;
              }
              }
          }
    }
   private void FixedUpdate()
    {
        if(IsShaked == false)
        {
        transform.position = new Vector3
        (GetPlayerPosiotion(transform.position.x, CurrentPlayer.transform.position.x,_velocity.x),
         GetPlayerPosiotion(transform.position.x, CurrentPlayer.transform.position.x,_velocity.x),
        transform.position.z);
        }
    }
    private float GetPlayerPosiotion(float position,float playerPositon, float velocity) =>  Mathf.SmoothDamp(position, playerPositon, ref velocity, _speed); 
            public void GetPlayer()
    {
        CurrentPlayer = _getterPlayer.CreatedPlayer;
        if (CurrentPlayer is Dd2)
        {
            CurrentPlayer.GetComponent<PlayerDd2Jump>().OnJump += TryShakeCamera;
        }
    }
    private void TryShakeCamera()
    {
        _startPosition = transform.position;
        IsShaked = true;
        _cameraPosition = new Vector3(transform.position.x + Random.Range(-3,3), transform.position.y + Random.Range(-1.5f,1.5f), -10);
    }
    private void EndShaking()
    {
        IsShaked = false;
    }
}
