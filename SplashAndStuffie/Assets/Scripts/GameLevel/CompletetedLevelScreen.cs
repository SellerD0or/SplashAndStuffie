using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompletetedLevelScreen : MonoBehaviour
{
  [SerializeField] private int _count;
   [SerializeField] private GetterPlayer _getterPlayer;
    [SerializeField] private Canvas _canvas;
    [SerializeField]private GetterPlayer _getter;

    public int Count { get => _count; set => _count = value; }
   [SerializeField]  private float _additionCount;
   [SerializeField] private Canvas _additionCanvas;
    [SerializeField] private float _result;
    private Player _player;
    [SerializeField] private Text _text;
    [SerializeField] private MummyHat _mummyHat;
    [SerializeField] private Animator _animator;
    [SerializeField] private Image[] _images;
    private bool _isAppear;
   [SerializeField] private Color[] _colors;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _icon;
    [SerializeField] private Transform _playerPosition;
    private MoveableCamera _camera;
    private Settings _settings;
    private bool _isTurnedEffect;
    private void OnEnable() {
          //  EnemyWarriorMovement.CanMove = false;
            Enemy[] enemies = FindObjectsOfType<Enemy>();
      foreach (var enemy in enemies)
      {
          enemy.GetComponent<ChangerState>().IsTimeStopped = false;
      }
      _settings = FindObjectOfType<Settings>();
      _camera = Camera.main.GetComponent<MoveableCamera>();
      _additionCount = Count;
      _result = Count;
      _additionCanvas.gameObject.SetActive(true);
      _canvas.gameObject.SetActive(false);
      //  _getter.
      //Player mummyHat = _getterPlayer.Players.Find(e=> e.Name ==_mummyHat.Name );
     
    }
    private void FixedUpdate() {
      
       //   foreach (var item in _images)
       //   {
         //    _isAppear = true;
           //       if (_isAppear)
          //        {
            //      item.color = Color.Lerp(_colors[0], _colors[1], 0.1f);
            //      if (item.color == _colors[1])
            //      {
            //          _isAppear = false;
            //      }
          //        }
         // }//
      
    }
    public void Leave()
    {
      _settings.LoadSelectLevel();
    }
    public void Lose(Player player)
    {
      _player =player;
      _player.Ability.enabled = false;
      _player.IPlayerAttackable.WaitTime = 100000;
      _player.IPlayerAttackable. IsCoolDown = false;
                  _icon.gameObject.SetActive(true);

      _icon.sprite = _sprites[1];
      StopTime();
    }
    public void Win(Player player)
    {
      _icon.sprite = _sprites[0];
      _text.gameObject.SetActive(true);
       foreach(var checkedPlayer in _getterPlayer.Players)
      {
        if (checkedPlayer is MummyHat)
        {
          Debug.LogError("WIIIN");
            _additionCount *= 115 /100;
            _result += _additionCount;
        }
      }
        
        //Count = 4 
          Count =(int) _result;
     // _result = Count + _additionCount;
      _text.text = "НАГРАДА: " + Count.ToString();
      
      _player = player;
            _icon.gameObject.SetActive(true);

      _icon.sprite = _sprites[0];
      StopTime();
    }
    private void StopTime()
    {
      Enemy[] enemies = FindObjectsOfType<Enemy>();
      foreach (var enemy in enemies)
      {
          enemy.IEnemyAnimator.EnemyAnimator.animation.timeScale = 0;
          enemy.enabled = false;
          enemy.IEnemyMovement.CanNormalMove = true;
          enemy.GetComponent<ChangerState>().IsTimeStopped = true;
      }
      _player.transform.position = _playerPosition.position;
      if(_player is Dd1)
      {
          _player.GetComponent<Test>().EnemyAnimator.animation.FadeIn("idle",0);
      }
      else
      {
              _player.IPlayerAnimator.EnemyAnimator.animation.FadeIn("idle",0);
      }
      if (_player is Tatti tatti)
      {
        tatti.GetComponent<PlayerTattiAbility>().HealEffect.gameObject.SetActive(false);
      }
      _player.Rigidbody2D.bodyType = RigidbodyType2D.Static;
      _player.IPlayerAnimator.EnemyAnimator.sortingOrder = 1003;
            _player.Ability.enabled = false;
      _player.IPlayerAttackable.WaitTime = 100000;
      _player.IPlayerAttackable. IsCoolDown = false;
         _player.IPlayerAnimator.EnemyAnimator =null;
      _player.IPlayerMovement.AbleToMove = true;
       _player.enabled = false;
       _isTurnedEffect = true;
      Destroy(_camera);
      
     // enemies.
    }
    private void Update() {
      if (_isTurnedEffect)
      {
        PlayerAudioSourse[] sourses = FindObjectsOfType<PlayerAudioSourse>();
        foreach (var item in sourses)
        {
          item.AudioSource.volume = ChangerSound.SoundVolome;
        }
      }
    }
}