using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;

[RequireComponent(typeof(UnityArmatureComponent))]
public class PlayerMummyHatAnimator : MonoBehaviour , IPlayerAnimator
{
      public float TimeForShoot { get => _timeForShoot; set => _timeForShoot = value; }
      
   //  [SerializeField] private float _timeForShoot = 1.5f;
      private bool _canShoot = true;
    private bool _canMove = true;
    private bool _canStay  = true;
    private bool _isAttack;
    [SerializeField] private float _timeForShoot = 3f;
    [SerializeField] private float _timeForIdle = 1.5f;
    [SerializeField] private float _timeForRun = 3f;
   public UnityArmatureComponent EnemyAnimator { get ; set; }
    public TypeOfAnimation TypeOfAnimation { get ; set ; }
    public bool IsAnimationEnded { get ; set ; } = false;
    [SerializeField] private List< AudioClip> _audioClips;
    [SerializeField] private PlayerAudioSourse _playerAudioSourse;
    public List< AudioClip> AudioClips { get => _audioClips; set => _audioClips = value; }
    public PlayerAudioSourse PlayerAudioSourse { get => _playerAudioSourse; set => _playerAudioSourse = value; }
    public bool CanMove { get => _canMove; set => _canMove = value; }
    public bool IsUsingUltimate { get => _isUsingUltimate; set => _isUsingUltimate = value; }
    private PlayerHealth _playerHealth;
    private bool _isUsingUltimate;
        private Player _player;
    private void Start() {
      _player = GetComponent<Player>();
        EnemyAnimator = GetComponent<UnityArmatureComponent>();
      _playerHealth =  GetComponent<PlayerHealth>();
      _playerHealth.OnDead += MakeDeathSound;
    }
      public void MakeDeathSound()
   {
         PlayerAudioSourse playerAudioSourse1 = Instantiate(_playerAudioSourse,transform.position,Quaternion.identity);
          playerAudioSourse1.AudioSource.clip = _audioClips[0];
           playerAudioSourse1.AudioSource.Play();

   }
    private void Update() {
        SwitchStates();
        Debug.LogError(IsUsingUltimate + " S_Sjfsahfhfhdhshshhdhdshdf");
    }
    public void SwitchStates()
    {
       // if(!IsAnimationEnded)
      //  {
       // switch (TypeOfAnimation)
       // {
           //       case TypeOfAnimation.Shoot:
           // Debug.LogError("Shoot");
          //  EnemyAnimator.animation.Play("shoot");
          //  StartCoroutine(CoolDown(_timeForShoot));
          //  break;
            //case TypeOfAnimation.Idle:
            if(IsUsingUltimate && _canShoot)
            {

                EnemyAnimator.animation.FadeIn("shoot");
            StartCoroutine(CoolDown(_timeForIdle));
             PlayerAudioSourse playerAudioSourse1 = Instantiate(_playerAudioSourse,transform.position,Quaternion.identity);
          playerAudioSourse1.AudioSource.clip = _audioClips[1];
        //  playerAudioSourse1.AudioSource.volume = 0.1f;
        _isAttack = true;
           playerAudioSourse1.AudioSource.Play();
           _canShoot = false;
                 Invoke(nameof(Attack),_timeForShoot);
            }
            else if (_isAttack == false  && _player.IsMove() && CanMove)
       {
           
           EnemyAnimator.animation.FadeIn("run",0);
           Debug.Log("RUUN");
         //  StartCoroutine(CoolDown(_timeForRun));
           CanMove = false;
           Invoke(nameof(Move), _timeForRun);
       }
            else if(_isAttack == false && _canStay && !_player.IsMove() && CanMove)
            {
            EnemyAnimator.animation.Play("idle");
            _canStay = false;
            Invoke(nameof(Stay),_timeForIdle);
            }
           // break;
      
         //   case TypeOfAnimation.Run:
           // EnemyAnimator.animation.Play("run");
          //  StartCoroutine(CoolDown(_timeForRun)); // time of animation run
          //  break;
          //  default:
          //  EnemyAnimator.animation.Play("idle");
           // StartCoroutine(CoolDown(_timeForIdle));
           // break;
     //   }
      //  }
    }
    public void PlayAttack()
    {
        TypeOfAnimation = TypeOfAnimation.Shoot;
    }

    public void PlayMovement()
    {
        TypeOfAnimation = TypeOfAnimation.Run;
    }

    public void PlayStay()
    {
       TypeOfAnimation = TypeOfAnimation.Idle;
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
       IsUsingUltimate = false;
        _canShoot = true;
        _isAttack = false;
     //  _isAttack = false;
   }

    public IEnumerator CoolDown(float waitTime)
    {
        IsAnimationEnded = true;
       yield return new WaitForSeconds(waitTime);
       if (true)
       {
           
       }
       IsAnimationEnded = false;
    }
}
