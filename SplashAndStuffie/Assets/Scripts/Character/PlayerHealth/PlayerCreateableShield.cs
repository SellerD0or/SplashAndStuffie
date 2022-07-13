using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreateableShield : IPlayerTakeableDamage
{
    private Player _player;
    public PlayerCreateableShield(Player player)
    {
        _player = player;
    }
    public void HandleTakingDamage()
    {
        //PlayerHealth.Health -= (int) PlayerHealth.TakedDamage;
    }
}
