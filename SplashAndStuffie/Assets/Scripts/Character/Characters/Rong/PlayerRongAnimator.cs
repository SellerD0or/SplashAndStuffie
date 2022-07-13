using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;

public class PlayerRongAnimator : MonoBehaviour, IPlayerAnimator
{
        public float TimeForShoot { get => _timeForShoot; set => _timeForShoot = value; }

    [SerializeField] private float _timeForAlternativeIdle;
    [SerializeField] private float _timeForAlternativeRun;
       [SerializeField] private float _timeForShoot ;
    [SerializeField] private float _timeForIdle ;
    [SerializeField] private float _timeForRun ;
   public UnityArmatureComponent EnemyAnimator { get ; set; }
    public TypeOfAnimation TypeOfAnimation { get ; set ; }
    public bool IsAnimationEnded { get ; set ; } = false;
    public bool CanMove { get => _canMove; set => _canMove = value; }
    public bool IsAlternativeMovevent { get => _isAlternativeMovevent; set => _isAlternativeMovevent = value; }

    private bool _isAlternativeMovevent;
    private Player _player;
    private bool _canShoot = true;
    private bool _canMove = true;
    private bool _canStay  = true;
    private bool _isAttack;
     [SerializeField] private List< AudioClip> _audioClips;
         [SerializeField] private PlayerAudioSourse _playerAudioSourse;

    public List< AudioClip> AudioClips { get => _audioClips; set => _audioClips = value; }
    public PlayerAudioSourse PlayerAudioSourse { get => _playerAudioSourse; set => _playerAudioSourse = value; }

    private void Start() {
        _player =GetComponent<Player>();
        EnemyAnimator = GetComponent<UnityArmatureComponent>();
        EnemyAnimator.animation.Play("idle");
                 _player.PlayerHealth.OnDead += MakeDeathSound;

    }
    private void Update() {
        SwitchStates();
    }
        public void MakeDeathSound()
   {
         PlayerAudioSourse playerAudioSourse1 = Instantiate(_playerAudioSourse,transform.position,Quaternion.identity);
          playerAudioSourse1.AudioSource.clip = _audioClips[0];
           playerAudioSourse1.AudioSource.Play();
   }
   public void PlayAttack()
    {
        
        TypeOfAnimation = TypeOfAnimation.Shoot;
        Debug.Log(TypeOfAnimation + " SHoot");
    }

    public void PlayMovement()
    {
        TypeOfAnimation = TypeOfAnimation.Run;
    }

    public void PlayStay()
    {
       TypeOfAnimation = TypeOfAnimation.Idle;
         Debug.Log(TypeOfAnimation + " Stay");
    }

    public IEnumerator CoolDown(float waitTime, string name)
    {
        IsAnimationEnded = true;
       yield return new WaitForSeconds(waitTime);
      
       if (name == "shoot")
       {
          // _canShoot = true;
       }
       else
       {
          // _canShoot = false;
       }
        IsAnimationEnded = false;
    }

    public IEnumerator CoolDown(float waitTime)
    {
       yield return new WaitForSeconds(waitTime);
       IsAlternativeMovevent = true;
       if(!_player.IsMove() )
        EnemyAnimator.animation.Play("alt_idle");
        else
        {
            EnemyAnimator.animation.Play("alt_run");
        }
    }

    public void SwitchStates()
    {
        Debug.Log(_player.IsAttack() + " CHANCE TO SHOOT");
       if (_player.IsAttack())
       {
           _isAttack = true;
           Debug.LogError("SHOOT RONG");
           PlayerAudioSourse playerAudioSourse1 = Instantiate(_playerAudioSourse,transform.position,Quaternion.identity);
          playerAudioSourse1.AudioSource.clip = _audioClips[1];
           playerAudioSourse1.AudioSource.Play();
           EnemyAnimator.animation.FadeIn("shoot",0);
           StartCoroutine(CoolDown(_timeForShoot));
           _canShoot = false;
           CanMove = false;
           Invoke(nameof(Attack),_timeForShoot);
       }
       else
       {
        if (_player.IsMove() && !_isAttack && CanMove )
       {
            string name = _isAlternativeMovevent == true ? "alt_run": "run";
           EnemyAnimator.animation.FadeIn(name,0);
           Debug.Log("RUUN");
         //  StartCoroutine(CoolDown(_timeForRun));
           CanMove = false;
           Invoke(nameof(Move), _timeForRun);
       }
          else if(!_player.IsMove() && !_isAttack && _canStay && CanMove)
       {
           string name = _isAlternativeMovevent == true? "alt_idle": "idle";
           Debug.Log(name + " HOW ARE YOU? ");
           EnemyAnimator.animation.Play(name);
          // Debug.Log("RUUN");
          // StartCoroutine(CoolDown(_timeForRun, "Idle"));
          _canStay = false;
           Invoke(nameof(Stay), _timeForIdle);
       }
       }
    }
     private void Stay()
   {
       _canStay = true;
   }
      private void Move()
   {
       CanMove = true;
   }
   private void Attack()
   {
       CanMove = true;
       _canShoot = true;
       _isAttack = false;
   }
}
