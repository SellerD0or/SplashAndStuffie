using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDd1Ability : Ability
{
    
    [SerializeField] private float _coolDown;
    [SerializeField] private ParticleSystem _particleSystem;
    public override float CoolDown { get => _coolDown; set => _coolDown = value; }
    public override Player Player { get; set ; }
    public override bool IsCoolDown { get ; set ; } = true;
    public override ParticleSystem ParticleSystem { get => _particleSystem; set => _particleSystem = value; }
    [SerializeField] private float _lastedTime;
    public override float LastedTime { get => _lastedTime; set => _lastedTime = value; }
       [SerializeField] private int _currentTime;
    public override int CurrentTime { get => _currentTime; set => _currentTime = value; }

    private PlayerInterface _playerInterface;
    [SerializeField] private float _percentOfAdditionSpeed = 1.35f;
     private float _timer = 0;
         private float _startSpeed;

     private void Start() {
         _playerInterface = FindObjectOfType<PlayerInterface>();
             Player = GetComponent<Player>();
                     _startSpeed = Player.Speed;

    }
    private void OnEnable() {
       
        ParticleSystem.Stop();
    
    }

    private void Update() {
           if(IsStoppeUsingAbility == false)
        {
        if (Input.GetKeyDown(KeyCode.Q)&& IsCoolDown)
        {
          IsCoolDown = false;
         ParticleSystem.Play();
         UseAbilitiy();
        }
        

        if (!IsCoolDown)
        {
            ParticleSystem.transform.localScale = new Vector3(Player.IPlayerMovement.IsTurned ? -4.6f : 4.6f,ParticleSystem.transform.localScale.y, ParticleSystem.transform.localScale.z); 
         /*   _timer = _timer + Time.deltaTime;
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
        }
    }

    public override void UseAbilitiy()
    {
       _playerInterface.ActiveAbility();
        IsAbilityRemoved = false;
       _playerInterface.PlayerAbilityInterface.Text.text = $"0 : {Player.Ability.CoolDown}";
        Player.Speed = Player.Speed * _percentOfAdditionSpeed;
                    Player.Ability.DestroyAbility();

         Debug.LogError("USE" + Player.Speed);
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
       // RemoveAbility();
    }

    public override void RemoveAbility()
    {
        Player.Speed =_startSpeed;
        IsAbilityRemoved = true;
    }
}
