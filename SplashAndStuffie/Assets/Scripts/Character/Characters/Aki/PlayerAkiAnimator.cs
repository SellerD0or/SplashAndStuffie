using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;

public class PlayerAkiAnimator : MonoBehaviour , IPlayerAnimator
{
      [SerializeField] private float _timeForShoot ;
    [SerializeField] private float _timeForIdle ;
    [SerializeField] private float _timeForAbility;
    [SerializeField] private float _timeForRun ;
   public UnityArmatureComponent EnemyAnimator { get ; set; }
    public TypeOfAnimation TypeOfAnimation { get ; set ; }
    public bool IsAnimationEnded { get ; set ; } = false;
    public bool CanMove { get => _canMove; set => _canMove = value; }
    public bool IsUsingAbility { get => _isUsingAbility; set => _isUsingAbility = value; }

    private Player _player;
    private bool _canUseAbility = true;
    private bool _canShoot = true;
    private bool _canMove = true;
    private bool _canStay  = true;
    private bool _isAttack;
    private bool _isUsingAbility;
    [SerializeField] private List< AudioClip> _audioClips;
    [SerializeField] private PlayerAudioSourse _playerAudioSourse;
    public List< AudioClip> AudioClips { get => _audioClips; set => _audioClips = value; }
    public PlayerAudioSourse PlayerAudioSourse { get => _playerAudioSourse; set => _playerAudioSourse = value; }
    public float TimeForShoot { get => _timeForShoot; set => _timeForShoot = value; }

    private void Start() {
        _player =GetComponent<Player>();
        EnemyAnimator = GetComponent<UnityArmatureComponent>();
        EnemyAnimator.animation.Play("idle");
        _player.PlayerHealth.OnDead += MakeDeathSound;

    }
         public void MakeDeathSound()
   {
         PlayerAudioSourse playerAudioSourse1 = Instantiate(_playerAudioSourse,transform.position,Quaternion.identity);
          playerAudioSourse1.AudioSource.clip = _audioClips[0];
           playerAudioSourse1.AudioSource.Play();
   }
    private void Update() {
        SwitchStates();
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
            EnemyAnimator.animation.Play("run");
        }
    }

    public void SwitchStates()
    {
       if (_player.IsAttack() && _canShoot && CanMove == false)
       {
           _isAttack = true;
           EnemyAnimator.animation.FadeIn("shoot", 0);
           Debug.Log("ATTACK AKI!!! ");
            StartCoroutine(CoolDown(_timeForShoot));
           _canShoot = false;
           PlayerAudioSourse playerAudioSourse1 = Instantiate(_playerAudioSourse,transform.position,Quaternion.identity);
          playerAudioSourse1.AudioSource.clip = _audioClips[1];
           playerAudioSourse1.AudioSource.Play();
            Invoke(nameof(UseUltimateSound),1);
          
           Invoke(nameof(Attack),_timeForShoot);
       }
       else if (_player.IsMove() && !_isAttack && CanMove)
       {
           
           EnemyAnimator.animation.FadeIn("run",0);
           Debug.Log("RUUN");
         //  StartCoroutine(CoolDown(_timeForRun));
           CanMove = false;
           Invoke(nameof(Move), _timeForRun);
       }
          else if(!_player.IsMove() && !_isAttack && _canStay && CanMove)
       {
           EnemyAnimator.animation.Play("idle");
          // Debug.Log("RUUN");
          // StartCoroutine(CoolDown(_timeForRun, "Idle"));
          _canStay = false;
           Invoke(nameof(Stay), _timeForIdle);
       }
         else if (_isUsingAbility && !_canUseAbility)
       {
           _canUseAbility = true;
           EnemyAnimator.animation.FadeIn("shoot", 0);
            
           Invoke(nameof(UseUltimate),_timeForAbility );
       }
    }
    private void UseUltimateSound()
    {
         PlayerAudioSourse playerAudioSourse1 = Instantiate(_playerAudioSourse,transform.position,Quaternion.identity);
          playerAudioSourse1.AudioSource.clip = _audioClips[2];
           playerAudioSourse1.AudioSource.Play();
    }
    private void UseUltimate()
    {
        _isUsingAbility = false;
        _canUseAbility = false;
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
}
