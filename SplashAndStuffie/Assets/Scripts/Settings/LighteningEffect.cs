using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
public class LighteningEffect : MonoBehaviour
{
 [SerializeField] private Animator _runningPerson;
 [SerializeField] private UnityEngine.Animation _animation;
 private void Awake() {
  //   _animation["RunningPerson"].time = 0.0f;
 }
    private void Start() {
        
        StartCoroutine(CreateEffect());
    }
 [SerializeField] private GameObject  _blackScreen;
 [SerializeField] private AnimationClip _animationClip;
  public IEnumerator CreateEffect()
  {
      
      yield return new WaitForSeconds(2);
      
      _runningPerson.gameObject.SetActive(false);
      _blackScreen.gameObject.SetActive(false);
  } 

}
