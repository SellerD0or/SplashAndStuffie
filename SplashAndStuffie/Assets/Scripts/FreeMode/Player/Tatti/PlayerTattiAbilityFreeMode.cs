using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;

public class PlayerTattiAbilityFreeMode : AbilityFreeMode
{
        [SerializeField] private UnityArmatureComponent _healEffect;

     private void Start() {
                _healEffect.gameObject.SetActive(false);
         _healEffect.animation.Stop();
     }
    public override void RemoveAbility()
    {
        _healEffect.gameObject.SetActive(false);
        _healEffect.animation.Stop();
    }

    public override void UseAbility()
    {
        Debug.Log("COOOL USING TATTI ABILITY");
        Player.GetComponent<PlayerTattiAnimatorFreeMode>().IsEating = true;
        Player.PlayerAnimatorFreeMode.Idle();
         if (Player.MaxHealth * 98 / 100 >= Player.Health)
                {
                  _healEffect.gameObject.SetActive(true);
                    _healEffect.animation.Play("tatti_heal");
                     Player.Health += Player.MaxHealth * 2 / 100;
               }
    }
}
