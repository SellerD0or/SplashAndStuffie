using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtisShopItemBoard : OtisShopBoard
{
   [SerializeField] private StorySeller _seller;
   private void OnEnable() {
    _seller.IsBuilding = true;
    _seller.IsWornHelmet = true;
     //  _seller.BlinkNumber = 3;
    //_seller.IdleNumber = 2;
    _seller.OnPutHelmetOn += PutHelmet;
    //Invoke(nameof(PlayHelmetAnimation),2f);
   }
   private void PutHelmet ()=> Invoke(nameof(PlayHelmetAnimation),1.95f);
   private void PlayHelmetAnimation()
   {
       _seller.IsWornHelmet = false;
      // _seller.StartCoolDown();
   }
   private void OnDisable() {
       _seller.IsBuilding = false;
       _seller.OnPutHelmetOn -= PutHelmet;
    //       _seller.BlinkNumber = 1;
   // _seller.IdleNumber = 0;
   // _seller.StopCoolDown();
    //_seller.StartCoolDown();
   }
}
