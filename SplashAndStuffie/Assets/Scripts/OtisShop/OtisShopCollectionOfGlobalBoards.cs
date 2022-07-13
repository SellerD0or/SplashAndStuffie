using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtisShopCollectionOfGlobalBoards : MonoBehaviour
{
[SerializeField] private List<OtisShopGlobalBoard> _boards;

private void Start() {
    if(PlayerPrefs.HasKey("OtisShop"))
    {
    string name = PlayerPrefs.GetString("OtisShop");
      if (name ==_boards[1].Name  || name =="DROP")
    {
        Debug.Log(name);
       Click(1);
    }
   else if (name ==_boards[0].Name)
    {
                Debug.Log(name);

        Click(0);
    }
    else
    {
        Debug.Log("SOMETHING'S GONE WRONG");
    }
    }
    else
    {
        Debug.Log("JUST ENTER");
        Click(1);
    }
  
 }
 private void OnDisable() {
     PlayerPrefs.DeleteKey("OtisShop");
 }
 private void Click(int number)
 {
     
        _boards[number].IsStart =true;
        _boards[number].OnPointerClick();
        Debug.Log("COOL");
 }
}
