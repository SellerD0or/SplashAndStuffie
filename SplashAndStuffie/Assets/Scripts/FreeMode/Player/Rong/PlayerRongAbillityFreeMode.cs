using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRongAbillityFreeMode : AbilityFreeMode
{
    [SerializeField] private PlayerRongFinderFreeMode _finder;
    public override void RemoveAbility()
    {
        _finder.Collider.enabled = true;
    }

    public override void UseAbility()
    {
        _finder.Collider.enabled = false;
        foreach (var player in _finder.Players)
        {
              if (player.MaxHealth * 0.85f >= player.Health)
            {
                player.Health = player.Health * 115 / 100;
            }
        }
    }
}
