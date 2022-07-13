using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAttackFreeMode : MonoBehaviour
{
      [SerializeField] private PlayerHealthFreeMode _playerHealth;
      [SerializeField] private AbilityFreeMode _ability;
  public bool AbleToAttck{get;set;}
  [SerializeField] private float _waitTime = 1; 
  public bool IsEndedCoolDown {get;set;}
        public abstract IEnumerator CoolDown();
      [SerializeField] private PlayerInformationFreeMode _playerInformationFreeMode;
      public bool CanAttack { get; set; }
    public PlayerInformationFreeMode PlayerInformationFreeMode { get => _playerInformationFreeMode; set => _playerInformationFreeMode = value; }
    public float WaitTime { get => _waitTime; set => _waitTime = value; }
    public PlayerHealthFreeMode PlayerHealth { get => _playerHealth; set => _playerHealth = value; }
    public AbilityFreeMode Ability { get => _ability; set => _ability = value; }

    public abstract void Stop();
    public abstract void ContinieToMove();
    public void ShowAbiliy()
    {
      //Debug.LogError("SHOW ABILTIY" + _ability.CanUseAbility + " UKRAINE " + name);
       if (_ability.CanUseAbility)
       {

           _ability.StartCoolDown();
       }
    }
}
