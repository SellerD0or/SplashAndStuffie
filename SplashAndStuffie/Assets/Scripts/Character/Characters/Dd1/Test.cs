using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;

public class Test : MonoBehaviour, IPlayerAnimator
{
   [SerializeField]  private UnityArmatureComponent _playerComponent;
  private PlayerDd1Attack _imovement;
  private PlayerHealth _playerHealth;
   [SerializeField] private float _timeForShoot = 1.5f;
    [SerializeField] private float _timeForRun = 3f;
    [SerializeField] private float _timeForIdle = 3f;
    private bool _canShoot = true;
    private bool _isAttack;
    private bool _canMove = true;
    private bool _canStay = true;
            [SerializeField] private List< AudioClip> _audioClips;
    public List< AudioClip> AudioClips { get => _audioClips; set => _audioClips = value; }
    public PlayerAudioSourse PlayerAudioSourse { get => _playerAudioSourse; set => _playerAudioSourse = value; }
    public UnityArmatureComponent PlayerAnimator { get => _playerComponent; set => _playerComponent = value; }
    public float TimeForShoot { get => _timeForShoot; set => _timeForShoot = value; }
    public bool IsStopped { get => _isStopped; set => _isStopped = value; }
    public bool IsAnimationEnded { get; set ; }
    public UnityArmatureComponent EnemyAnimator { get; set; }
    public TypeOfAnimation TypeOfAnimation { get; set ; }

    [SerializeField] private PlayerAudioSourse _playerAudioSourse;
    private bool _isStopped;
   private void Start() {
       _playerHealth =GetComponent<PlayerHealth>();
       _imovement= GetComponent<PlayerDd1Attack>();
     //  PlayerAnimator.animation.Play("idle");
        EnemyAnimator = GetComponent<UnityArmatureComponent>();
        EnemyAnimator.animation.Play("idle");
       _playerHealth.OnDead += MakeDeathSound;
   }
   public void MakeDeathSound()
   {
              int random = Random.Range(2, _audioClips.Count);
       PlayerAudioSourse playerAudioSourse = Instantiate(PlayerAudioSourse,transform.position,Quaternion.identity);
          playerAudioSourse.AudioSource.clip = _audioClips[random];
           playerAudioSourse.AudioSource.Play();
       PlayerAudioSourse playerAudioSourse1 = Instantiate(PlayerAudioSourse,transform.position,Quaternion.identity);
          playerAudioSourse1.AudioSource.clip = _audioClips[0];
           playerAudioSourse1.AudioSource.Play();

   }
   private void Update() {
       if(IsStopped==false)
       {
       float x = Input.GetAxis("Horizontal");
       if (Input.GetKeyDown(KeyCode.E) && _canShoot && _imovement.CountOfBullets >0 && _imovement.IsAttack)
       {
           _isAttack = true;
           EnemyAnimator.animation.FadeIn("shoot", 0);
        
           StartCoroutine(CoolDown(TimeForShoot, "Shoot"));
           _canShoot = false;
           Invoke(nameof(Move),TimeForShoot);
       }
       else if (x != 0 && !_isAttack && _canMove)
       {
           
           EnemyAnimator.animation.FadeIn("run",0);
           Debug.Log("RUUN");
           StartCoroutine(CoolDown(_timeForRun, "Run"));
           _canMove = false;
           Invoke(nameof(Sssda), _timeForRun);
       }
       else if(x == 0 && !_isAttack && _canStay)
       {

           EnemyAnimator.animation.Play("idle");
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
   private void Sssda()
   {
       _canMove = true;
   }
   private void Move()
   {
       _canShoot = true;
       _isAttack = false;
   }
   private IEnumerator CoolDown(float _time, string name )
   {
       yield return new WaitForSeconds(_time);
       if(name == "Shoot")
       {
           EnemyAnimator.animation.Play("idle");
       }
       
   }

    public void PlayAttack()
    {
    }

    public void PlayMovement()
    {
    }

    public void PlayStay()
    {
    }

    public IEnumerator CoolDown(float waitTime)
    {
        yield return new WaitForSeconds(1);
    }

    public void SwitchStates()
    {
    }
}
