using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAkiAbility : Ability
{
       [SerializeField] private float _coolDown;
    [SerializeField] private ParticleSystem _particleSystem;
    public override float CoolDown { get => _coolDown; set => _coolDown = value; }
    public override Player Player { get; set ; }
    public override bool IsCoolDown { get ; set ; } = true;
    public override ParticleSystem ParticleSystem { get => _particleSystem; set => _particleSystem = value; }
    
    [SerializeField] private float _lastedTime;
    public override float LastedTime { get => _lastedTime; set => _lastedTime = value; }

    private PlayerInterface _playerInterface;
    [SerializeField] private PlayerAkiTotem _playerAkiTotem;
    [SerializeField] private int _percentOfAdditionDamage = 3;
    private float _timer = 0;
    [SerializeField] private int _currentTime;
    public override int CurrentTime { get => _currentTime; set => _currentTime = value; }
    private PlayerAkiAnimator _animator;
    private void Start() {
         _playerInterface = FindObjectOfType<PlayerInterface>();
             Player = GetComponent<Player>();
             _animator = GetComponent<PlayerAkiAnimator>();
    }
    private void OnEnable() {
       
        ParticleSystem.Stop();
    
    }

    private void Update() {
        if(IsStoppeUsingAbility == false)
        {
        if (Input.GetKeyDown(KeyCode.Q) && IsCoolDown)
        {
          IsCoolDown = false;
         ParticleSystem.Play();
         UseAbilitiy();
        }
        if (!IsCoolDown)
        {
            ParticleSystem.transform.localScale = new Vector3(Player.IPlayerMovement.IsTurned ? -4.6f : 4.6f,ParticleSystem.transform.localScale.y, ParticleSystem.transform.localScale.z); 
       /*     _timer = _timer + Time.deltaTime;
         LastedTime = CoolDown - CurrentTime;
          if (_timer > 1)
          {
              CurrentTime ++;
              LastedTime = CoolDown - CurrentTime;
                if (CurrentTime > Player.Ability.TimeForRemovingAbility && IsAbilityRemoved == false)
             {
                 RemoveAbility();
             }
            if(CurrentTime > CoolDown)
            {
                 DisactiveAbility();
                IsCoolDown = true;
                CurrentTime = 0;
            }
           _timer = 0;
          }*/
        }
       // if (Input.GetKeyDown(KeyCode.Q) && IsCoolDown)
       // {
       //    UseAbilitiy();
       //     StartCoroutine(Reload());
       // }
        }
    }

    public override void UseAbilitiy()
    {
       _playerInterface.ActiveAbility();
                       IsAbilityRemoved = false;
       _playerInterface.PlayerAbilityInterface.Text.text = $"0 : {Player.Ability.CoolDown}";
       _animator.IsUsingAbility = true;
       Invoke(nameof(CreateTotem),0.5f);
        Player.Ability.DestroyAbility();
    }

    public override IEnumerator Reload()
    {
        IsCoolDown = false;
        ParticleSystem.Play();
        UseAbilitiy();
        yield return new WaitForSeconds(CoolDown);
        DisactiveAbility();
        IsCoolDown = true;
    }

    public override void DisactiveAbility()
    {
       _playerInterface.DisactiveAbility();
     // RemoveAbility();
    }
    private void CreateTotem()
    {
    Instantiate(_playerAkiTotem,transform.position,Quaternion.identity);
    }

    public override void RemoveAbility()
    {
        IsAbilityRemoved = true;
    }
}
