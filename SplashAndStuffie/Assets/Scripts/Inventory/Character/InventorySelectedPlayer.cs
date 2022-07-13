using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
public class InventorySelectedPlayer : MonoBehaviour
{
    private Animator _animator;
   private UnityArmatureComponent _unityArmatureComponent;
    private float _timeForRemovingAnimation = 3;
     private string _nameOfAnimation = "idle";
    public string NameOfAnimation { get => _nameOfAnimation; set => _nameOfAnimation = value; }
    public Animator Animator { get => _animator; set => _animator = value; }
    public UnityArmatureComponent UnityArmatureComponent { get => _unityArmatureComponent; set => _unityArmatureComponent = value; }

    private void Start() {
        UnityArmatureComponent = GetComponent<UnityArmatureComponent>();
    }

    public void PlayAnimation()
    {
        Debug.Log("PLAY VIEW ANIMATION " + NameOfAnimation);
        UnityArmatureComponent.animation.FadeIn(NameOfAnimation,0,1);
    }
}
