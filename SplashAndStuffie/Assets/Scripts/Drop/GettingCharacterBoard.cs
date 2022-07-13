using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
public class GettingCharacterBoard : MonoBehaviour
{
   private UnityArmatureComponent _unityAmrature;
   private bool _isOver;
   private void Start() {
       _unityAmrature = GetComponent<UnityArmatureComponent>();
       _unityAmrature.animation.Play("idle");
       _unityAmrature._sortingOrder = 100;
       Invoke(nameof(Show),1f);
   }
  
   private void Show()
   {
        _unityAmrature.animation.Stop();
        _unityAmrature.animation.FadeIn("run");
   }
}
