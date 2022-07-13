using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDd2AbilityFreeMode : AbilityFreeMode
{
    [SerializeField] private float _percentOfAdditionShield = 0.25f;
    public override void RemoveAbility()
    {
        Player.PlayerMovementFreeMode.PlayerHealth.AdditionShield = Player.PlayerMovementFreeMode.PlayerHealth.AdditionShield / _percentOfAdditionShield;

    }

    public override void UseAbility()
    {
                Player.PlayerMovementFreeMode.PlayerHealth.AdditionShield = Player.PlayerMovementFreeMode.PlayerHealth.AdditionShield * _percentOfAdditionShield;

    }
}
