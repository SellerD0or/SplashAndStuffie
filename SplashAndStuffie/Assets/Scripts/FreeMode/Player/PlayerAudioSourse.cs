using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioSourse : MonoBehaviour
{
      [SerializeField] private AudioSource _audioSourse;
     public AudioSource AudioSource { get => _audioSourse; set => _audioSourse = value; }
     [SerializeField] private float _waitTime = 5;
     private float _volume =1;
     [SerializeField] private bool _isAbleToDestory = true;
     private ChangerSound _changer;
     private void Start() {
         _changer =FindObjectOfType<ChangerSound>();
         if(_changer != null)
         {
         //_changer.OnPlay += ChangeVolume;
         }
        ChangeVolume();
        // AudioSource.volume = _volume;
        if(_isAbleToDestory)
        {
         DestroySound(_waitTime);
        }
     }
     public void DestroySound(float waitTime) => Destroy(gameObject, _waitTime);
     private void ChangeVolume()
     {
          if(_changer.CanHearSounds)
      {
       AudioSource.volume =  ChangerSound.SoundVolome;
      }
      else
      AudioSource.volume = 0;
     }
}
