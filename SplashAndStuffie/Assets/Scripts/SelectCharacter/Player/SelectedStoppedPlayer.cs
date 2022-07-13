using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;

public class SelectedStoppedPlayer : MonoBehaviour
{
    [SerializeField] private float _timeForStopping = 1;
 [SerializeField] private UnityArmatureComponent _animator;
 [SerializeField] private string _nameOfAnimation = "idle";
 private void OnEnable() {
     _animator.animation.Play(_nameOfAnimation,1);
     Invoke(nameof(StopAnimation), _timeForStopping);
 }
 private void StopAnimation()
 {
     _animator.animation.Stop();
 }
}
