using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBotzAbilityFreeMode : AbilityFreeMode
{
        [SerializeField] private int _percentOfAdditionDamage = 3;

     [SerializeField] private float _percentOfAdditionShield = 0.25f;
    public override void RemoveAbility()
    {
        Player.Damage = Player.Damage / _percentOfAdditionDamage;
    }

    public override void UseAbility()
    {
        Player.Damage = Player.Damage * _percentOfAdditionDamage;
    }
}
