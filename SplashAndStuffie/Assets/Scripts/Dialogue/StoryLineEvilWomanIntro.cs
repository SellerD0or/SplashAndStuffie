using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;

public class StoryLineEvilWomanIntro : Dialogue
{
    [SerializeField] private UnityArmatureComponent _unityArmature;
    [SerializeField] private StoryEvilWomanDialogue _storyEvil;
    [SerializeField] private AudioSource _audioSourse;
    [SerializeField] private float _stopTime = 3;
        [SerializeField] private AudioSource _previousAudioSourse;

  private void OnEnable() {
      
  }
  private void Start() {
      string name = "";
      // _name.text = _charactersOfDialogue.Name;
    name =     PlayerPrefs.GetString("Language");
       Debug.Log(name);
       if(name == "ru_RU")
       {
         _unityArmature.animation.Play("str_evildama_intro_ru",1);
        // Invoke(nameof(StopAnimation),_stopTime);
       }
       else
       {
              _unityArmature.animation.Play("str_evildama_intro_eng",1);
      //  Invoke(nameof(StopAnimation),_stopTime);


       }
       _previousAudioSourse.gameObject.SetActive(false);
       _audioSourse.gameObject.SetActive(true);
       _audioSourse.Play();
  }
  private void StopAnimation() => _unityArmature.animation.Stop();
  
}
