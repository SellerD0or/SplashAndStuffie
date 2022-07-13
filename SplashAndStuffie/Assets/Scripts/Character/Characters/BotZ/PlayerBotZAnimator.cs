using System.Timers;
using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;

public class PlayerBotZAnimator : MonoBehaviour, IPlayerAnimator
{
        public float TimeForShoot { get => _timeForShoot; set => _timeForShoot = value; }

    [SerializeField] private float _timeForShoot ;
    [SerializeField] private float _timeForIdle ;
    [SerializeField] private float _timeForRun ;
   public UnityArmatureComponent EnemyAnimator { get ; set; }
    public TypeOfAnimation TypeOfAnimation { get ; set ; }
    public bool IsAnimationEnded { get ; set ; } = false;
    public bool CanMove { get => _canMove; set => _canMove = value; }

    private Player _player;
    private bool _canShoot = true;
    private bool _canMove = true;
    private bool _canStay  = true;
    private bool _isAttack;
     [SerializeField] private PlayerAudioSourse _playerAudioSourse;
    [SerializeField] private List< AudioClip> _audioClips;
    [SerializeField] private AudioSource _audioSourse;
    public List< AudioClip> AudioClips { get => _audioClips; set => _audioClips = value; }
    public AudioSource AudioSource { get => _audioSourse; set => _audioSourse = value; }
    public PlayerAudioSourse PlayerAudioSourse { get => _playerAudioSourse; set => _playerAudioSourse = value; }
    private float _time =0;
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
        
        _time += Time.deltaTime;
        if(_time > 2)
        {
             PlayerAudioSourse playerAudioSourse1 = Instantiate(_playerAudioSourse,transform.position,Quaternion.identity);
         //    playerAudioSourse1.AudioSource.volume = 0.1f;
          playerAudioSourse1.AudioSource.clip = _audioClips[2];
           playerAudioSourse1.AudioSource.Play();
            _time = 0;
        }

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
       {
            Debug.Log("CanMove");
        EnemyAnimator.animation.Play("idle");
       }
        else
        {
            EnemyAnimator.animation.Play("run");
        }
    }

    public void SwitchStates()
    {
        Debug.Log(_player.IsAttack() + "- is attack botz " + _canShoot + " - can shoot!");
       if (_player.IsAttack() && _canShoot)
       {
           _isAttack = true;
           Debug.Log("ATTACK BOTZ");
           EnemyAnimator.animation.FadeIn("shoot", 0,1);
             PlayerAudioSourse playerAudioSourse1 = Instantiate(_playerAudioSourse,transform.position,Quaternion.identity);
          playerAudioSourse1.AudioSource.clip = _audioClips[1];
        //  playerAudioSourse1.AudioSource.volume = 0.3f;
           playerAudioSourse1.AudioSource.Play();
           StartCoroutine(CoolDown(_timeForShoot));
           Invoke(nameof(Attack),_timeForShoot);
           _canShoot = false;
       }
       else if (_player.IsMove() && !_isAttack && CanMove)
       {
           
           EnemyAnimator.animation.FadeIn("run",0);
           Debug.LogError("RUUN");
         //  StartCoroutine(CoolDown(_timeForRun));
           CanMove = false;
           Invoke(nameof(Move), _timeForRun);
       }
          else if(!_player.IsMove() && !_isAttack && _canStay && CanMove)
       {
           EnemyAnimator.animation.Play("idle");
           Debug.LogError("Idle");
          // StartCoroutine(CoolDown(_timeForRun, "Idle"));
          _canStay = false;
           Invoke(nameof(Stay), _timeForIdle);
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
       _canShoot = true;
       _isAttack = false;
   }
}
