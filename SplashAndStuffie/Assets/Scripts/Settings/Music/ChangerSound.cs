using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChangerSound : MonoBehaviour
{
    // [SerializeField] private AudioSource _audioSourse;
    public event UnityAction OnPlay;
  [SerializeField] private Sprite[] _spritesIconOfSound;
  [SerializeField] private Image _iconOfSound;
  [SerializeField] private Slider _slider;
  
  private static float _musicVolome = 1f;
  [SerializeField] private bool _canHearSounds = true;

    public static float SoundVolome { get => _musicVolome; set => _musicVolome = value; }
    public bool CanHearSounds { get => _canHearSounds; set => _canHearSounds = value; }

    private void Start() {
      if(PlayerPrefs.HasKey("SoundVolume"))
      {
      SoundVolome = PlayerPrefs.GetFloat("SoundVolume");
      _slider.value = SoundVolome;
     // _slider.handleRect.x = 
     }
      else
      {
        _slider.value = 0.2f;
        SoundVolome = 0.2f;
        Save();
      }
      ChangeSprite();
      Debug.Log(SoundVolome);
  }
  //private void Update() {
    //  _audioSourse.volume = SoundVolome;
   public void ChangeVolume(float currentVolume) 
  {
     SoundVolome = currentVolume;
     ChangeSprite();
  }
  private void OnDisable() {
    Save();
  }
  private void Save() =>   PlayerPrefs.SetFloat("SoundVolume", SoundVolome);
  private void ChangeSprite()
  {
      
    _iconOfSound.sprite = SoundVolome == 0 ? _spritesIconOfSound[1] : _spritesIconOfSound[0];
  //  OnPlay?.Invoke();
  }
}
