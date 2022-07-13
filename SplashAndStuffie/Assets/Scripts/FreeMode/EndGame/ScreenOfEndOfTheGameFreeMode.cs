using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DragonBones;
public class ScreenOfEndOfTheGameFreeMode : MonoBehaviour
{
    [SerializeField] private UnityArmatureComponent _generator;
    [SerializeField] private Animator _endScreen;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField ] private Image _icon;
        [SerializeField] private Canvas _canvas;
       [SerializeField]  private Settings _settings;
       [SerializeField] private Canvas _mainCanvas;
        [SerializeField] private Text _text;
        [SerializeField] private GameObject _screen;
private PlayerInformationFreeMode[] _players;
        private EnemyInformationFreeMode[] _enemies;
    public GameObject Screen { get => _screen; set => _screen = value; }
    [SerializeField] private GameObject _effects;
    private void Start() {
         
            _settings = FindObjectOfType<Settings>();
        }
        public void Exit()
        {
            _settings.LoadLobby();
        }
    public void Win()
    {  
                _generator.animation.FadeIn("successful");

        _icon.gameObject.SetActive(true);
        _icon.sprite = _sprites[0];
      _text.gameObject.SetActive(true);
     Load();
    }
    public void Lose()
    {
        _generator.animation.FadeIn("error");
                _icon.gameObject.SetActive(true);

        _icon.sprite = _sprites[1];
        Load();
    }
    private void Load()
    {
        _effects.SetActive(false);
        Screen.SetActive(true);
        _players= FindObjectsOfType<PlayerInformationFreeMode>();
        _enemies = FindObjectsOfType<EnemyInformationFreeMode>();
        foreach (var player in _players)
        {
            Destroy(player.gameObject);
        } 
          foreach (var player in _enemies)
        {
            Destroy(player.gameObject);
        } 
      //  Time.timeScale = 0;
      _mainCanvas.gameObject.SetActive(false);
        _canvas.gameObject.SetActive(true);
    }
}
