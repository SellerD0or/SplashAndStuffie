using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;

public class PlayerAxelAnimator : MonoBehaviour, IPlayerAnimator
{
        public float TimeForShoot { get => _timeForShoot; set => _timeForShoot = value; }

     [SerializeField] private float _timeForShoot ;
    [SerializeField] private float _timeForIdle ;
    [SerializeField] private float _timeForRun ;
    [SerializeField] private float _timeForUltimate;
   public UnityArmatureComponent EnemyAnimator { get ; set; }
    public TypeOfAnimation TypeOfAnimation { get ; set ; }
    public bool IsAnimationEnded { get ; set ; } = false;
    public bool CanMove { get => _canMove; set => _canMove = value; }
    public bool IsUsingUltimate { get => _isUsingUltimate; set => _isUsingUltimate = value; }

    private Player _player;
    private bool _canShoot = true;
    private bool _canMove = true;
     private bool _canUse  = false;
    private bool _canStay  = true;
    private bool _isAttack;
     private bool _isUsingUltimate;
    [SerializeField] private List< AudioClip> _audioClips;
    [SerializeField] private PlayerAudioSourse _playerAudioSourse;
    public List< AudioClip> AudioClips { get => _audioClips; set => _audioClips = value; }
    public PlayerAudioSourse PlayerAudioSourse { get => _playerAudioSourse; set => _playerAudioSourse = value; }
    [SerializeField] private AudioSource _goSound;
    private bool _isGogoSoundEnded;
    private void Start() {
      //  _goSound.AudioSource.Stop();
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
        // IsAnimationEnded = true;
       yield return new WaitForSeconds(waitTime);
       //IsAnimationEnded = false;
       if(!_player.IsMove())
        EnemyAnimator.animation.Play("idle");
        else
        {
              PlayerAudioSourse playerAudioSourse = Instantiate(_playerAudioSourse,transform.position,Quaternion.identity);
          playerAudioSourse.AudioSource.clip = _audioClips[2];
                 //   playerAudioSourse.AudioSource.volume = 0.2f;

           playerAudioSourse.AudioSource.Play();
            EnemyAnimator.animation.Play("run_fast");
        }
    }

    public void SwitchStates()
    {
       if (_player.IsAttack() && _canShoot && !IsUsingUltimate)
       {
           _isAttack = true;
           EnemyAnimator.animation.FadeIn("shoot", 0);
           StartCoroutine(CoolDown(_timeForShoot));
           Invoke(nameof(MakeAttackSound),1);
           _canShoot = false;
           Invoke(nameof(Attack),_timeForShoot);
       }
       else if (_player.IsMove() && !_isAttack && CanMove && !IsUsingUltimate)
       {
           
           EnemyAnimator.animation.FadeIn("run_fast",0);
           if (_isGogoSoundEnded == false)
           {
             StartCoroutine(MakeGoSound());
           }
           Debug.Log("RUUN");
         //  StartCoroutine(CoolDown(_timeForRun));
           CanMove = false;
           Invoke(nameof(Move), _timeForRun);
       }
        else if (IsUsingUltimate && !_canUse)
       {
           _canUse = true;
           Debug.Log("USING ULTIMATE");
           EnemyAnimator.animation.FadeIn("ult", 0);
             PlayerAudioSourse playerAudioSourse = Instantiate(_playerAudioSourse,transform.position,Quaternion.identity);
          playerAudioSourse.AudioSource.clip = _audioClips[3];
         // playerAudioSourse.AudioSource.volume = 0.2f;
           playerAudioSourse.AudioSource.Play();
           Invoke(nameof(UseUltimate),_timeForUltimate );
       }
          else if(!_player.IsMove() && !_isAttack && _canStay && CanMove && !IsUsingUltimate)
       {
           EnemyAnimator.animation.Play("idle");
          // Debug.Log("RUUN");
          // StartCoroutine(CoolDown(_timeForRun, "Idle"));
          _canStay = false;
           Invoke(nameof(Stay), _timeForIdle);
       }
    }
    private void MakeAttackSound()
    {
                     PlayerAudioSourse playerAudioSourse = Instantiate(_playerAudioSourse,transform.position,Quaternion.identity);
          playerAudioSourse.AudioSource.clip = _audioClips[1];
               //     playerAudioSourse.AudioSource.volume = 0.2f;

           playerAudioSourse.AudioSource.Play();

    }
    private IEnumerator MakeGoSound()
    {
        if(_player.IsMove() )
        {
            Debug.LogError("GOGO!!! ");
          // _goSound.AudioSource.clip = _audioClips[2];
         PlayerAudioSourse playerAudioSourse = Instantiate(_playerAudioSourse,transform.position,Quaternion.identity);
          playerAudioSourse.AudioSource.clip = _audioClips[2];
       playerAudioSourse.DestroySound(2);
              playerAudioSourse.AudioSource.volume = 0.2f;
                        playerAudioSourse.AudioSource.Play();

    //   _goSound.Play();      
       _isGogoSoundEnded = true;
        }
        yield return new WaitForSeconds(0.1f);
        _isGogoSoundEnded = false;
        //if(_player.IsMove())
       // StartCoroutine(MakeGoSound());
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
       _canShoot = true;
       _isAttack = false;
   }
     private void UseUltimate()
   {
       _canUse = false;
       IsUsingUltimate = false;
   }
}
