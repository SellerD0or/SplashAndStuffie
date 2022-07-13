using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
public class TestAnimation : MonoBehaviour
{
    [SerializeField] private UnityArmatureComponent _armatureComponent;
    [SerializeField]private float _time;
     [SerializeField] private float _procent;
    private void Start() {
        _armatureComponent = GetComponent<UnityArmatureComponent>();
    }
  private void Update() {
      if (Input.GetKeyDown(KeyCode.Q))
      {
          _armatureComponent.animation.GotoAndPlayByProgress("shoot",_procent,1);
      }
      else if (Input.GetKeyDown(KeyCode.W))
      {
        // _armatureComponent.animation.GotoAndPlayByFrame("shoot",0.4f);  
      }
       else if (Input.GetKeyDown(KeyCode.E))
      {
         _armatureComponent.animation.GotoAndPlayByTime("shoot",_time,1);  
      }
  }
}
