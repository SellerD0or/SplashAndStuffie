using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxelUltimate : Ultimate
{
   [SerializeField] private float _coolDown;
    public override float CoolDown { get => _coolDown; set => _coolDown = value; }
    public override Player Player { get; set ; }
    public override bool IsCoolDown { get ; set ; } = true;
    [SerializeField] private float _lastedTime;
    public override float LastedTime { get => _lastedTime; set => _lastedTime = value; }
    [SerializeField]  private int _currentTime;
    public override int CurrentTime { get => _currentTime; set => _currentTime = value; }

    private PlayerInterface _playerInterface;
    [SerializeField] private float _percentOfAdditionSpeed = 1.35f;
     private float _timer = 0;
     [SerializeField] private PlayerAxelField _playerAxelField;
     private PlayerAxelField _currentPlayerAxelField;
     [SerializeField] private PlayerAxelRocket _rocket;
     private bool _isSetTarget;
     private Camera _camera;
     private PlayerAxelAnimator _animator;
     private float _fullTime; 
     private float _countOfRockets;
     private float _currentCountOfRockets;
     [SerializeField] private float _additionX = -30;
     private void Start() {
          _fullTime = _coolDown;
         _camera = Camera.main;
         _currentPlayerAxelField = Instantiate(_playerAxelField);
         _currentPlayerAxelField.gameObject.SetActive(false); 
         _playerInterface = FindObjectOfType<PlayerInterface>();
             Player = GetComponent<Player>();
             _animator = GetComponent<PlayerAxelAnimator>();
    }
    private void CanselUnilimate()
    {

        if (Input.GetMouseButtonDown(1) && _isSetTarget)
        {
             _coolDown = _fullTime / 6;
            IsCoolDown = false;
            _currentPlayerAxelField.gameObject.SetActive(false); 
            
        _isSetTarget = false;
         UseUltimate();
        }
    }
    private void ContinieToMove()
    {
          Player.IPlayerMovement.AbleToMove = false;   
     }
     private void CreateRocket()
    {
        Vector2 pos =_playerAxelField.ReturnPosition();
      PlayerAxelRocket rocket = Instantiate(_rocket,new Vector2(transform.position.x + pos.x + _additionX, transform.position.y + pos.y + 30),Quaternion.identity);
      rocket.Speed *= 1.5f;
      rocket.transform.rotation = Quaternion.Euler(0,0,50.85f);
     // rocket.PositionYForStop =_currentPlayerAxelTarget.transform.position.y; 
      rocket.SetDistance(pos.y);
        _isSetTarget = false;
        _coolDown = _fullTime;
        IsCoolDown = false;
        
    }
    private void DisactiveField()
    {
        _currentPlayerAxelField.gameObject.SetActive(false); 
    }
         private void ActiveUltimate()
    {
        if (Input.GetMouseButtonDown(0) && _isSetTarget)
        {
         _currentCountOfRockets = 0;
        _countOfRockets = Random.Range(6,15);
        StartCoroutine(StartToCreateRocket(0.2f));
         UseUltimate();
    
        }
    }

    private void Update() {
           if(IsStoppeUsingUltimate == false)
        {
        if (Input.GetKeyDown(KeyCode.R) && Player.Ultimate.AmountOfReloadig == Player.Ultimate.MaxAmountOfReloading)
        {
          
          SetTarget();
        }
                ActiveUltimate();
        CanselUnilimate();
          MoveTarget();

        if (!IsCoolDown)
        {
        /*    _timer = _timer + Time.deltaTime;
         LastedTime = CoolDown - CurrentTime;
          if (_timer > 1)
          {
              CurrentTime ++;
              LastedTime = CoolDown - CurrentTime;
            if(CurrentTime > CoolDown)
            {
                 DisactiveAbility();
                IsCoolDown = true;
                CurrentTime = 0;
            }
           _timer = 0;
          }*/
        }
        }
    }
    private void MoveTarget()
    {
        if(_isSetTarget)
        {
        Vector3 pos = _camera.ScreenToWorldPoint(Input.mousePosition);
        _currentPlayerAxelField.transform.position = new Vector3(pos.x,pos.y,_currentPlayerAxelField.transform.position.z);
        }
        
    }
    private void SetTarget()
    {
        _currentPlayerAxelField.gameObject.SetActive(true);
        _isSetTarget = true;

    }

    public override void UseUltimate()
    {
        DisactiveField();
       _playerInterface.ActiveAbility();
                 IsAbilityRemoved = false;
       _playerInterface.PlayerAbilityInterface.Text.text = $"0 : {Player.Ability.CoolDown}"; 
        Player.Ultimate.DestroyAbility();
    }
    private IEnumerator StartToCreateRocket(float time)
    {

            CreateRocket();
            _currentCountOfRockets++;
         yield return new WaitForSeconds(time);
        if (_countOfRockets > _currentCountOfRockets)
        {
            StartCoroutine(StartToCreateRocket(time));
        }
    }
    private void OnDisable() {
        DisactiveField();
    }
    public override void DisactiveUltimate()
    {

        _playerInterface.DisactiveAbility();
       
    }

    public override void RemoveUltimate()
    {
//        throw new System.NotImplementedException();
    }
}
