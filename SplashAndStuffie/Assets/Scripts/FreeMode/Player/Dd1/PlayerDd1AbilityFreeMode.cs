using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDd1AbilityFreeMode : AbilityFreeMode
{
    [SerializeField] private float _percentOfAdditionFireRate = 0.5f;
    [SerializeField] private PlayerAttackFreeMode _playerAttack;
    public override void RemoveAbility()
    {
        _playerAttack.WaitTime = _playerAttack.WaitTime / _percentOfAdditionFireRate;

    }

    public override void UseAbility()
    {
        _playerAttack.WaitTime = _playerAttack.WaitTime * _percentOfAdditionFireRate;

    }
}
