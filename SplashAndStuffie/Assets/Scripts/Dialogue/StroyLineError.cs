using System;
using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;
using UnityEngine.Video;

public class StroyLineError : Dialogue, ICreatableArrow
{

    [SerializeField] private GameObject _glitch;
    [SerializeField] private GameObject _changerBackGround;
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private GameObject _backGround;
    [SerializeField] private GameObject _person;
    [SerializeField] private ChangerOfMessages _changer;
           [SerializeField] private UnityArmatureComponent _unityArmature;

    private void Start() {
        string name = "";
      // _name.text = _charactersOfDialogue.Name;
    name =     PlayerPrefs.GetString("Language");
       Debug.Log(name);
       if(name == "ru_RU")
       {
         _unityArmature.animation.FadeIn("str_error_3_ru");
       }
       else
       {
              _unityArmature.animation.FadeIn("str_error_3_eng");

       }
       // _cameraVhs.enabled = true;
        _backGround.SetActive(false);
        _person.SetActive(false);
        _changer.gameObject.SetActive(false);
        _changerBackGround.gameObject.SetActive(true);
       // _videoPlayer.Play();
        StartCoroutine(AppearArrow());
        Invoke(nameof(Move), 0.2f);
    }
    private void Move() => _glitch.SetActive(false);
    private void OnDisable() {
       // _cameraVhs.enabled = false;
        _backGround.SetActive(true);
        _person.SetActive(true);
        //_videoPlayer.Stop();
        _videoPlayer.gameObject.SetActive(false);
          _changerBackGround.gameObject.SetActive(false);
    }
       public IEnumerator AppearArrow()
    {
       yield return new WaitForSeconds(5);
       _changer.gameObject.SetActive(true);
       
       _changer.Appear(this);
    }
}
