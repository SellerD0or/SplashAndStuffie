using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using UnityEngine.Events;
public class GoGoScreen : MonoBehaviour
{
    private UnityArmatureComponent _unityArmatureComponent;
    public UnityAction OnLoadScene;
    public UnityAction OnCloseScene;

    private void Awake() {
      OnLoadScene += Open;
      OnCloseScene += Close;  
    _unityArmatureComponent = GetComponent<UnityArmatureComponent>();

    }
    private void Open()
    {
        _unityArmatureComponent.animation.Play("out",1);
      // Invoke(nameof(Exit),1);
    }
  //  private void Exit() => _unityArmatureComponent.animation.Stop();
    private void Close()
    {
        _unityArmatureComponent.animation.FadeIn("in");
        Invoke(nameof(AfterWait),1f);
    }
    private void AfterWait()
    {
        _unityArmatureComponent.animation.Play("wait");
    }
    
}
