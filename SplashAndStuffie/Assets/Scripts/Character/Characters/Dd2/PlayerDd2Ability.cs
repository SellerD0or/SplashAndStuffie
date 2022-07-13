using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDd2Ability : Ability
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
    [SerializeField] private float _percentOfAdditionShield = 0.25f;
    private float _timer = 0;
    [SerializeField] private int _currentTime;
    public override int CurrentTime { get => _currentTime; set => _currentTime = value; }
    private float _startShield;
    private void Start() {
         _playerInterface = FindObjectOfType<PlayerInterface>();
             Player = GetComponent<Player>();
             _startShield  = Player.PlayerHealth.AdditionShield;
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
        Player.PlayerHealth.AdditionShield = Player.PlayerHealth.AdditionShield * _percentOfAdditionShield;
                    Player.Ability.DestroyAbility();

         Debug.LogError("USE" + Player.Speed);
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
    }

    public override void RemoveAbility()
    {
        Player.PlayerHealth.AdditionShield = _startShield;
        IsAbilityRemoved = true;
    }
}
