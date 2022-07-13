using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftScreen : MonoBehaviour
{
   [SerializeField] private GameObject _screen;
   private void Start() {
       //Invoke(nameof(Destroy), 0.5f);
   }
   public void Destroy()
   {
       _screen.SetActive(true);
   }
}
