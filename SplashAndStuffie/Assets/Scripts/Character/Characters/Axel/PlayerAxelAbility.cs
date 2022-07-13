using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxelAbility : Ability
{
     [SerializeField] private float _coolDown;
    [SerializeField] private ParticleSystem _particleSystem;
    public override float CoolDown { get => _coolDown; set => _coolDown = value; }
    public override Player Player { get; set ; }
    public override bool IsCoolDown { get ; set ; } = true;
    public override ParticleSystem ParticleSystem { get => _particleSystem; set => _particleSystem = value; }
    [SerializeField] private float _lastedTime;
    public override float LastedTime { get => _lastedTime; set => _lastedTime = value; }
    [SerializeField]  private int _currentTime;
    public override int CurrentTime { get => _currentTime; set => _currentTime = value; }

    private PlayerInterface _playerInterface;
    [SerializeField] private float _percentOfAdditionSpeed = 1.35f;
     private float _timer = 0;
     [SerializeField] private PlayerAxelTarget _playerAxelTarget;
     private PlayerAxelTarget _currentPlayerAxelTarget;
     [SerializeField] private PlayerAxelRocket _rocket;
     private bool _isSetTarget;
     private Camera _camera;
     private PlayerAxelAnimator _animator;
     private float _fullTime; 
     private void Start() {
          _fullTime = _coolDown;
         _camera = Camera.main;
         _currentPlayerAxelTarget = Instantiate(_playerAxelTarget);
         _currentPlayerAxelTarget.gameObject.SetActive(false); 
         _playerInterface = FindObjectOfType<PlayerInterface>();
             Player = GetComponent<Player>();
             _animator = GetComponent<PlayerAxelAnimator>();
    }
    private void OnEnable() {
       
        ParticleSystem.Stop();
    
    }
    private void CanselUnilimate()
    {
        if (Input.GetMouseButtonDown(1) && _isSetTarget)
        {
             _coolDown = _fullTime / 6;
            IsCoolDown = false;
            _currentPlayerAxelTarget.gameObject.SetActive(false); 
            
        _isSetTarget = false;
           ParticleSystem.Play();
         UseAbilitiy();
        }
    }
    private void ContinieToMove()
    {
          Player.IPlayerMovement.AbleToMove = false;   
     }
     private void ActiveUltimate()
    {
        if (Input.GetMouseButtonDown(0) && _isSetTarget)
        {
            CreateRocket();
            _animator.IsUsingUltimate = true;
                Player.IPlayerMovement.AbleToMove = true;
               Player.Rigidbody2D.velocity = Vector2.zero;
               Invoke(nameof(ContinieToMove), 2);
            ParticleSystem.Play();
         UseAbilitiy();
    
        }
    }
    private void CreateRocket()
    {
      PlayerAxelRocket rocket = Instantiate(_rocket,new Vector2(_currentPlayerAxelTarget.transform.position.x, _currentPlayerAxelTarget.transform.position.y + 30),Quaternion.identity);
     // rocket.PositionYForStop =_currentPlayerAxelTarget.transform.position.y; 
      rocket.SetDistance(_currentPlayerAxelTarget.transform.position.y);
        _currentPlayerAxelTarget.gameObject.SetActive(false); 
        _isSetTarget = false;
        _coolDown = _fullTime;
        IsCoolDown = false;
        
    }
    private void Update() {
           if(IsStoppeUsingAbility == false)
        {
        if (Input.GetKeyDown(KeyCode.Q) && IsCoolDown)
        {
          
         
         SetTarget();
        }
        ActiveUltimate();
        CanselUnilimate();
        MoveTarget();
        

        if (!IsCoolDown)
        {
            ParticleSystem.transform.localScale = new Vector3(Player.IPlayerMovement.IsTurned ? -4.6f : 4.6f,ParticleSystem.transform.localScale.y, ParticleSystem.transform.localScale.z); 
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
        _currentPlayerAxelTarget.transform.position = new Vector3(pos.x,pos.y,_currentPlayerAxelTarget.transform.position.z);
        }
        
    }
    private void SetTarget()
    {
        _currentPlayerAxelTarget.gameObject.SetActive(true);
        _isSetTarget = true;

    }

    public override void UseAbilitiy()
    {

       _playerInterface.ActiveAbility();
                 IsAbilityRemoved = false;
       _playerInterface.PlayerAbilityInterface.Text.text = $"0 : {Player.Ability.CoolDown}"; 
        Player.Ability.DestroyAbility();
    }

    public override IEnumerator Reload()
    {
        IsCoolDown = false;
        ParticleSystem.transform.localScale = new Vector3(Player.IPlayerMovement.IsTurned ? -10 : 10,ParticleSystem.transform.localScale.x, 0); 
        ParticleSystem.Play();
        UseAbilitiy();
        yield return new WaitForSeconds(CoolDown);
        DisactiveAbility();
        IsCoolDown = true;
    }

    public override void DisactiveAbility()
    {

        _playerInterface.DisactiveAbility();
       
    }

    public override void RemoveAbility()
    {
//        throw new System.NotImplementedException();
    }
}
