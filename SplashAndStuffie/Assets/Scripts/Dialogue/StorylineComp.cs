using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DragonBones;
public class StorylineComp : Dialogue
{
    [SerializeField] private GameObject _brokenScreen;
     [SerializeField] private ChangerOfMessages _changer;
     [SerializeField] private Text _text;

     [SerializeField] private int _time = 15;
     [SerializeField] private UnityArmatureComponent _animator;
     [SerializeField] private GameObject _person;
     [SerializeField] private GameObject _additionScreen;
     [SerializeField] private GameObject _canselScreen;
     [SerializeField] private Animator _cameraAnimator;
     [SerializeField] private CameraFilterPack_Real_VHS _cameraVhs;
     [SerializeField] private CameraFilterPack_3D_Fog_Smoke _cameraFog;

   private void Start()
    {   
        _cameraFog.enabled = false;
        _cameraVhs.enabled = true;
        _cameraAnimator.SetBool("Shake", true);
        _brokenScreen.SetActive(false);
        _additionScreen.SetActive(true);
         _person.gameObject.SetActive(false);
        _changer.gameObject.SetActive(false);
        StartCoroutine(CoolDown());
   }
   private IEnumerator CoolDown()
   {
       _time --;
       _text.text = $"0 : {_time}";

       yield return new WaitForSeconds(1);
       if (_time > 0)
       {
           StartCoroutine(CoolDown());
       } 
       else
       {
         _cameraAnimator.SetTrigger("SlowShake");
        _additionScreen.SetActive(false);
           TurnOffVHS();
           _changer.OpenNextMessage();
        
         // Invoke(nameof(StartNewScene), 1);
       }
   }
   private void OnDisable() {
   }
   public void TurnOnSecretScene()
   {
      _canselScreen.SetActive(false);
       Debug.LogError("COol");
       _animator.animation.Play("effect_poyavl", 1);
       Invoke(nameof(DisplayMessage),1);
   }
   private void DisplayMessage()
   {
       _canselScreen.SetActive(true);
        _animator.animation.Play("with_no");
   }
   public void DisplayNormal()
   {
         _canselScreen.SetActive(false);
       _animator.animation.Play("first");
   }
   
  
   private void TurnOffVHS() => _cameraVhs.enabled = false;
}
