using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryWishShopButton : MonoBehaviour
{
   [SerializeField] private Settings _settings;
   [SerializeField] private string _name;
   public void Open() 
   {
       PlayerPrefs.SetString("OtisShop",_name);
       Debug.Log(_name + " LOAD ");
       _settings.LoadOtisShop();
       
   }
}
