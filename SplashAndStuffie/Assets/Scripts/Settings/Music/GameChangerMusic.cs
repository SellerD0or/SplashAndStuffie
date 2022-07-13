using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameChangerMusic : MonoBehaviour
{
  [SerializeField] private ChangerMusic _changerMusic;
  [SerializeField] private AudioClip[] _audioSourses;
 [SerializeField]  private AudioClip _lastAudioSourse;
 [SerializeField] private List<int> _numbers;
 private int _lastNumber;
  private bool _isChoosenMusic;
  private void Start() {
     int random = Random.Range(0,_audioSourses.Length);
     _lastAudioSourse = _audioSourses[random];
    
  }
  private void Update() 
  {
      if (!_changerMusic.AudioSourse.isPlaying && !_isChoosenMusic)
      {
        GetRandomMusic();
      }
  }
  private void GetRandomMusic()
  {
      _isChoosenMusic = true;
        int random = Random.Range(0,_audioSourses.Length);
        if (random == _lastNumber)
        {
            GetRandomMusic();
        }
        else
        {
            _lastNumber = random;
            _changerMusic.AudioSourse.clip = _audioSourses[random];
          //  _changerMusic.AudioSourse.volume = PlayerPrefs.GetFloat("MusicVolume");
            Debug.LogError(PlayerPrefs.GetFloat("MusicVolume") + " VOLUMER!!!");
               _changerMusic.AudioSourse.Play();
               _isChoosenMusic = false;
        }
       // if (_audioSourses[random] = _lastAudioSourse)
       // {
        //    GetRandomMusic();
         //   return;
       // }
      // _changerMusic.AudioSourse.clip = _audioSourses[random];
       // _lastAudioSourse = _audioSourses[ random];
        //        _isChoosenMusic = false;

  }
}
