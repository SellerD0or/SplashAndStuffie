using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtisShopSignboard : Signboard
{
    [SerializeField] private LocalizationManager _localization;

    public LocalizationManager Localization { get => _localization; set => _localization = value; }

    public override void Open()
    {
        if(CanPress)
        {
        Icon.SetActive(false);
      Redactor.CloseScene();
        Settings.LoadOtisShop();
        CanPress = false;
        }
    }
   
}
