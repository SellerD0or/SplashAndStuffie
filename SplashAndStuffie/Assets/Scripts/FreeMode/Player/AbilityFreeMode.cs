using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityFreeMode : MonoBehaviour
{
    [SerializeField] private PlayerInformationFreeMode _player;
    [SerializeField] private float _timeForRemove = 1;
    [SerializeField] private float _waitTime =2;
    public PlayerInformationFreeMode Player { get => _player; set => _player = value; }
    public bool CanUseAbility { get => _canUseAbility; set => _canUseAbility = value; }
    public float WaitTime { get => _waitTime; set => _waitTime = value; }

    private bool _canUseAbility = true;
    public void StartCoolDown()
    {
        if(_canUseAbility)
        {
         StartCoroutine(GetEffect());
        StartCoroutine(CoolDown());
        }
    } 
    private IEnumerator GetEffect()
    {
        Debug.LogError("EFFECT");
        UseAbility();
        yield return new WaitForSeconds(_timeForRemove);
        RemoveAbility();
    }
    public abstract void UseAbility();
    public abstract void RemoveAbility();
    private IEnumerator CoolDown()
    {
        _canUseAbility = false;
        yield return new WaitForSeconds(_waitTime);
        _canUseAbility =true;
    }
}
