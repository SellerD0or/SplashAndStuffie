using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Ultimate : MonoBehaviour
{
    [SerializeField] private float _proccentOfReloading;
  public event UnityAction OnRemove;
    public event UnityAction OnFull;

  public event UnityAction OnUploadAmount;
  public event UnityAction<float> OnReload;
  [SerializeField] private float _amountOfReloadig = 3;
  
  [SerializeField] private bool _isReloadByTime = true;
  private bool _isAbilityRemoved;
  [SerializeField] private float _timeForRemovingUltimate;
   public float TimeForRemovingUltimate { get => _timeForRemovingUltimate; set => _timeForRemovingUltimate = value; }
  public abstract int CurrentTime {get;set;}
  public abstract float CoolDown {get;set;}
  public abstract Player Player {get;set;}
  public abstract void UseUltimate();
  public abstract void DisactiveUltimate();
  public abstract bool IsCoolDown{get;set;}
  public bool IsStoppeUsingUltimate{get;set;}
  public abstract float LastedTime {get;set;}
    public bool IsAbilityRemoved { get => _isAbilityRemoved; set => _isAbilityRemoved = value; }
    public bool IsReloadByTime { get => _isReloadByTime; set => _isReloadByTime = value; }
    private float _maxAmountOfReloading;
    public float MaxAmountOfReloading { get => _maxAmountOfReloading; set => _maxAmountOfReloading = value; }
    public float AmountOfReloadig { get => _amountOfReloadig; set => _amountOfReloadig = value; }
    public float ProcentOfReloading { get => _proccentOfReloading; set => _proccentOfReloading = value; }

    private void Start() {
    }
    public abstract void RemoveUltimate();
    public void StartReload()
    {
      
       /*       CurrentTime ++;
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
          */
    }
    public void ReloadAmount(float amount)
    {
      OnReload?.Invoke(amount);
      if (AmountOfReloadig >= MaxAmountOfReloading)
      {
           OnFull?.Invoke();
      }
    }
    public void DestroyAbility()
    {
      AmountOfReloadig=0;
      OnRemove?.Invoke();     
    }
    public void UpdateAmount(float extarAmount)
    {
      
      if (AmountOfReloadig < MaxAmountOfReloading)
      {
        AmountOfReloadig+= extarAmount;
        OnUploadAmount?.Invoke();
      }
      else
      {
      //  OnFull?.Invoke();
      }
    }
}
