using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;

public class PlayerTattiAnimator : MonoBehaviour, IPlayerAnimator
{
        public float TimeForShoot { get => _timeForShoot; set => _timeForShoot = value; }

    [SerializeField] private float _timeForShoot ;
    [SerializeField] private float _timeForIdle ;
    [SerializeField] private float _timeForFood ;
   public UnityArmatureComponent EnemyAnimator { get ; set; }
    public TypeOfAnimation TypeOfAnimation { get ; set ; }
    public bool IsAnimationEnded { get ; set ; } = false;
    public bool CanMove { get => _canMove; set => _canMove = value; }
    public bool IsEating { get => _isEating; set => _isEating = value; }

    private Player _player;
    private bool _canShoot = true;
    private bool _canMove = true;
    private bool _canEat  = false;
    private bool _isAttack;
    private bool _isEating;
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
        // IsAnimationEnded = true;
       yield return new WaitForSeconds(waitTime);
        EnemyAnimator.animation.Play("idle");
    }

    public void SwitchStates()
    {
        if (IsEating && !_canEat)
       {
           _canEat = true;
           EnemyAnimator.animation.FadeIn("eating", 0);
             PlayerAudioSourse playerAudioSourse1 = Instantiate(_playerAudioSourse,transform.position,Quaternion.identity);
          playerAudioSourse1.AudioSource.clip = _audioClips[2];
          //playerAudioSourse1.AudioSource.volume = 0.2f;
           playerAudioSourse1.AudioSource.Play();
           Invoke(nameof(Eat),_timeForFood );
       }
       else if (_player.IsAttack() && _canShoot && !IsEating)
       {
           _isAttack = true;
           EnemyAnimator.animation.FadeIn("shoot", 0);
             PlayerAudioSourse playerAudioSourse1 = Instantiate(_playerAudioSourse,transform.position,Quaternion.identity);
          playerAudioSourse1.AudioSource.clip = _audioClips[1];
       //   playerAudioSourse1.AudioSource.volume = 0.2f;
           playerAudioSourse1.AudioSource.Play();
           StartCoroutine(CoolDown(_timeForShoot));
           _canShoot = false;
           Invoke(nameof(Attack),_timeForShoot);
       }
     
       /*
       else if (_player.IsMove() && !_isAttack && CanMove)
       {
           
           EnemyAnimator.animation.FadeIn("run",0);
           Debug.Log("RUUN");
         //  StartCoroutine(CoolDown(_timeForRun));
           CanMove = false;
           Invoke(nameof(Move), _timeForRun);
       }
       */
          else if(!_isAttack && CanMove && !IsEating)
       {
           EnemyAnimator.animation.Play("idle");
          CanMove = false;
           Invoke(nameof(Move), _timeForIdle);
       }
    }
     private void Eat()
   {
       _canEat = false;
       IsEating = false;
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
