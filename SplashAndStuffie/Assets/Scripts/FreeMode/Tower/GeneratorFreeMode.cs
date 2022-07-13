using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
public class GeneratorFreeMode : MonoBehaviour
{
    [SerializeField] private Animator _animatorEffect;
   [SerializeField] private float _health = 100;
    private float _maxHealth;
    [SerializeField] private GameObject _flora;
    public float Health { get => _health; set => _health = value; }
    private ScreenOfEndOfTheGameFreeMode _screen;
        private bool _canAttack = true;
        [SerializeField] private int _damage = 2;
        [SerializeField] private GameObject _effectBoom;
        [SerializeField] private GameObject _halfDestoryEffect;
        private bool _isPlayedHalfDestroyEffect;
       private bool _isPlayedDestroyEffect;

        [SerializeField] private GameObject[] _destroyEffects;
      [SerializeField] private UnityArmatureComponent _generator;
          [SerializeField] private UnityEngine.Transform[] _generatorPositions;
          private bool _canChangePosition = true;
    private void Start() {
        _maxHealth = Health;
        _screen = FindObjectOfType<ScreenOfEndOfTheGameFreeMode>();
        StartCoroutine(PlayEffects());
    }
    private IEnumerator PlayEffects()
    {
        int random = Random.Range(2, 5);
        yield return new WaitForSeconds(random);
        _effectBoom.gameObject.SetActive(true);
        StartCoroutine(PlayEffects());
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.V))
        {
          //  TakeDamage(100000);
        }
    }
    public void TakeDamage(int damage, EnemyInformationFreeMode enemy)
    {
        Debug.Log(_canAttack + " take damage ");
        if(_canAttack == true)
        {
            enemy.EnemyAttack.EnemyHealth.TakeDamage(_damage);
        Health -= damage;
        if (Health <= (_maxHealth / 2) && _isPlayedHalfDestroyEffect == false)
        {
            Debug.Log("ACTVIE");
                        _halfDestoryEffect.SetActive(true);
            _isPlayedHalfDestroyEffect = true;
        }
        if(Health < 0 && _isPlayedDestroyEffect == false)
        {
         
            foreach (var item in _destroyEffects)
            {
                item.SetActive(true);
            }
            
          Invoke(nameof(Destory), 3);   
          _isPlayedDestroyEffect = true;
        }
        StartCoroutine(CoolDown());
        }
        
    }
    public void SetFirstPosition() => SetPosition(1);
    public void SetSecondPosition() => SetPosition(2);
    public void SetThirdPosition() => SetPosition(3);
    public void SetEndGamePosition() 
    {
        SetPosition(4);
        _animatorEffect.gameObject.SetActive(false);
        _canChangePosition = false;
        CameraFreeMode cameraFreeMode = new CameraFreeMode();
        cameraFreeMode = FindObjectOfType<CameraFreeMode>();
        cameraFreeMode.SetFullScreen();
        cameraFreeMode.CanUsed = false;
       _generator.transform.localScale = new Vector3(2.371145f,2.371145f,2.371145f);//-16.2 -16.23
       _generator.sortingLayerName = "Objects";
              _generator.sortingOrder = 98;

    }
    public void SetFullScreenPosition() => SetPosition(0);

    private void SetPosition(int numberOfPosition) 
    {
        if(numberOfPosition == 3 && _flora.activeInHierarchy)
        {
         _animatorEffect.SetTrigger("Appear");
            _flora.SetActive(false);
        }
        else if(numberOfPosition != 3 && _flora.activeInHierarchy == false)
        {
            _flora.SetActive(true);
            _animatorEffect.SetTrigger("Disappear");

        }
        if(_canChangePosition)
     {
         _generator.transform.position = _generatorPositions[numberOfPosition].position;
         //_flora.transform.position = _floraPositions[numberOfPosition].position;
     }
    }
    private void Destory()
    {
        SetEndGamePosition();
      //  _screen.Screen.SetActive(true);
            _screen.Lose();
    }
      private IEnumerator CoolDown()
    {
        _canAttack =false;
        Debug.Log("before" + _canAttack);
        yield return new WaitForSeconds(1);
        
        _canAttack =true;
                Debug.Log("after" + _canAttack);

    }
}
