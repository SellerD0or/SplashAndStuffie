using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorSignboard : Signboard
{
   public override void Open()
    {
        if(CanPress)
        {
        Icon.SetActive(false);
          Redactor.CloseScene();
        Settings.LoadFreeMode();
         CanPress = false;
        }
    }
}
