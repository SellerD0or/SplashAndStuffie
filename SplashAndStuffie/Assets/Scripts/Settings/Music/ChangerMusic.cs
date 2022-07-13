using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangerMusic : MonoBehaviour
{
      [SerializeField] private AudioSource _audioSourse;
  [SerializeField] private Sprite[] _spritesIconOfMusic;
  [SerializeField] private Image _iconOfMusic;
  [SerializeField] private Slider _slider;
  [SerializeField] private CanvasGroup _canvasGroup;
  private static float _musicVolome = 1f;

    public static float MusicVolome { get => _musicVolome; set => _musicVolome = value; }
    public AudioSource AudioSourse { get => _audioSourse; set => _audioSourse = value; }

    private void Start() {
      if(PlayerPrefs.HasKey("MusicVolume"))
      {
      MusicVolome = PlayerPrefs.GetFloat("MusicVolume");
      _slider.value = MusicVolome;
     // _slider.handleRect.x = 
     }
      else
      {
        _slider.value = 0.2f;
        MusicVolome = 0.2f;
        Save();
      }
     
      ChangeSprite();
      Debug.Log(MusicVolome);
  }
  private void Update() {
      AudioSourse.volume = MusicVolome;
  }
  public void ChangeVolume(float currentVolume) 
  {
    Debug.Log("WE CHANGE VOLUME!!! " + currentVolume);
    if(_canvasGroup.alpha == 1)
    {
     MusicVolome = currentVolume;
     ChangeSprite();
    }
  }
  private void OnDisable() {
    Save();
  }
  private void Save() =>   PlayerPrefs.SetFloat("MusicVolume", MusicVolome);
  private void ChangeSprite()
  {
    _iconOfMusic.sprite = MusicVolome == 0 ? _spritesIconOfMusic[1] : _spritesIconOfMusic[0];
  }
}
