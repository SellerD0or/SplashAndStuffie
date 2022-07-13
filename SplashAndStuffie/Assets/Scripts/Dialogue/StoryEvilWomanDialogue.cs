using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StoryEvilWomanDialogue : Dialogue, ICreatableArrow
{
  [SerializeField] private CameraFilterPack_NewGlitch3 _glitch;
  [SerializeField] private TextMessage _textMessage;
  [SerializeField] private AudioSource[] _audioSoures;
  [SerializeField] private GameObject _panel;
  [SerializeField] private SpriteRenderer _backGround;
  [SerializeField] private Sprite _brokenLabrothorySprite;
    [SerializeField] private ChangerOfMessages _changer;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _person;
    [SerializeField] private CameraFilterPack_3D_Fog_Smoke _forsmoke;
        [SerializeField] private CameraFilterPack_Real_VHS _cameraVhs;
   private void Start() {
      _changer.gameObject.SetActive(false);
     _glitch.enabled = true;
     _cameraVhs.enabled = true;
     _textMessage.gameObject.SetActive(true);
     _audioSoures[1].gameObject.SetActive(true);
     //_audioSoures[0].volume = 0;
      _audioSoures[0].gameObject.SetActive(false);
     _person.gameObject.SetActive(false);
    // _changer.gameObject.SetActive(false);
       _camera =Camera.main;
       _camera.backgroundColor = Color.black;
       StartCoroutine(AppearArrow());
       _backGround.gameObject.SetActive(false);
   }
   private void OnDisable() {
     _glitch.enabled = false;
     _cameraVhs.enabled = false;
     _forsmoke.enabled = true;
     _camera.GetComponent<Animator>().SetBool("Shake", false);
      _textMessage.gameObject.SetActive(false);
     _person.SetActive(true);
     _panel.SetActive(true);
     _backGround.gameObject.SetActive(true);
     _backGround.sprite = _brokenLabrothorySprite;
     _changer.gameObject.SetActive(false);
   }
    public IEnumerator AppearArrow()
    {
       yield return new WaitForSeconds(5);
       _changer.gameObject.SetActive(true);
       _changer.Appear(this);
    }
}
