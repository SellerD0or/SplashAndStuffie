using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSignboard : Signboard
{
    public override void Open()
    {          
        if(CanPress)
        {      
       Icon.SetActive(false);
         Redactor.CloseScene();
       Settings.LoadSelectLevel();
     CanPress = false;        
     }
    }
}
