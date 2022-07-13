using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;
[RequireComponent(typeof(UnityArmatureComponent))]
public class PlayerDd1Animator : MonoBehaviour, IPlayerAnimator
{
      public float TimeForShoot { get => _timeForShoot; set => _timeForShoot = value; }

    [SerializeField] private float _timeForShoot = 1.5f;
    [SerializeField] private float _timeForIdle = 3f;
    [SerializeField] private float _timeForRun = 3f;
        [SerializeField] private PlayerAudioSourse _playerAudioSourse;

   public UnityArmatureComponent EnemyAnimator { get ; set; }
    public TypeOfAnimation TypeOfAnimation { get ; set ; }
    public bool IsAnimationEnded { get ; set ; } = false;
    

    private Player _player;
    private bool _canShoot;
        [SerializeField] private List< AudioClip> _audioClips;
    [SerializeField] private AudioSource _audioSourse;
    public List< AudioClip> AudioClips { get => _audioClips; set => _audioClips = value; }
    public AudioSource AudioSource { get => _audioSourse; set => _audioSourse = value; }
    public PlayerAudioSourse PlayerAudioSourse { get => _playerAudioSourse; set => _playerAudioSourse = value; }

    private void Start() {
        _player =GetComponent<Player>();
        EnemyAnimator = GetComponent<UnityArmatureComponent>();
    }
    private void Update() {
       // SwitchStates();
    }
    public void SwitchStates()
    {
     //  if(!IsAnimationEnded)
     //   {
         /*
         Debug.Log(TypeOfAnimation + " Choose");
        switch (TypeOfAnimation)
        {
            
            case TypeOfAnimation.Shoot:
                 // if(!_canShoot)
                //  {
            Debug.LogError("Shoot rabbit");
            
            EnemyAnimator.animation.FadeIn("shoot",0);
            StartCoroutine(CoolDown(_timeForShoot));
             //     }
            break;
            case TypeOfAnimation.Idle:
            Debug.LogError("Idle rabbit");
          //  EnemyAnimator.animation.Play("idle");
            //StartCoroutine(CoolDown(_timeForIdle));
            break;
      
            case TypeOfAnimation.Run:
            Debug.LogError("Run rabbit");
            if(!IsAnimationEnded)
            {
            EnemyAnimator.animation.Play("run",0);
            StartCoroutine(CoolDown(_timeForRun)); // time of animation run
            }
            break;
            default:
          //  EnemyAnimator.animation.Play("idle");
         //   StartCoroutine(CoolDown(_timeForIdle));
            break;
        }
        */
      //  }
    }
    public void PlayAttack()
    {  
     //   TypeOfAnimation = TypeOfAnimation.Shoot;
       // Debug.Log(TypeOfAnimation + " SHoot");
    }

    public void PlayMovement()
    {
        //TypeOfAnimation = TypeOfAnimation.Run;
    }

    public void PlayStay()
    {
      // TypeOfAnimation = TypeOfAnimation.Idle;
       //  Debug.Log(TypeOfAnimation + " Stay");
    }

    public IEnumerator CoolDown(float waitTime, string name)
    {
       // IsAnimationEnded = true;
       yield return new WaitForSeconds(waitTime);
      // if (name == "shoot")
    //   {
      //     _canShoot = true;
    //   }
    ///   else
     //  {
     //      _canShoot = false;
     //  }
     //   IsAnimationEnded = false;
    }

    public IEnumerator CoolDown(float waitTime)
    {
   //      IsAnimationEnded = true;
      yield return new WaitForSeconds(waitTime);
     // IsAnimationEnded = false;
     //   EnemyAnimator.animation.Play("idle");
    }
    
}
