using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDecreaseableHealth :  IPlayerTakeableDamage
{
    private PlayerHealth _playerHealth;

    public PlayerHealth PlayerHealth { get => _playerHealth; set => _playerHealth = value; }
    public PlayerDecreaseableHealth(PlayerHealth playerHealth)
    {
        PlayerHealth = playerHealth;
    }

    public void HandleTakingDamage()
    {
        Debug.Log(PlayerHealth.TakedDamage + " Damage");
       PlayerHealth.Health -= (int) PlayerHealth.TakedDamage;
       if (PlayerHealth.Health <= 0)
       {
           PlayerHealth.DestroyPlayer();
       }
    }
}
