using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerHealth : MonoBehaviour
{
    public event UnityAction OnDead;
    private SelecterCharacter _selecterCharacter;
    public float TakedDamage { get; set; }
   private IPlayerTakeableDamage _playerTakeableDamage;
    private Color _color;
    [SerializeField] private SpriteRenderer _playerSpriteRenderer;
    [SerializeField] private int _health;
    private bool _isCoolDown;
    public event UnityAction ApplyDamage;
    public int Health 
    {
         get => _health; 
    set
    {
         _health = value; 
    }
    }
    private int _maxHealth;
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public IPlayerTakeableDamage PlayerTakeableDamage { get => _playerTakeableDamage; set => _playerTakeableDamage = value; }
    public IPlayerTakeableDamage FirstPlayerTakeableDamage { get => _firstPlayerTakeableDamage; private set => _firstPlayerTakeableDamage = value; }

    private IPlayerTakeableDamage _firstPlayerTakeableDamage;
    private ShakerCamera _shakerCamera;
    public float AdditionShield { get; set; } =1;
    public SelecterCharacter SelecterCharacter { get => _selecterCharacter; set => _selecterCharacter = value; }
    public bool IsCoolDown { get => _isCoolDown; set => _isCoolDown = value; }

    [SerializeField] private Animator _cameraHealthEffect;
    private GetterPlayer _getterPlayer;
    private Player _player;
    private void OnEnable() 
    {
        IsCoolDown = false;
      //  ApplyDamage?.Invoke();
    }
    public bool HaveEventsOnApplyDamage(Delegate action)
    {
        if(ApplyDamage != null)
        {
       Delegate[] delegates = ApplyDamage.GetInvocationList();
        return delegates.Contains(action);
        }
        else
      return false;
    }
    private void Awake() {
         _getterPlayer = FindObjectOfType<GetterPlayer>();
    }
    private void Start() {
        _player = GetComponent<Player>();
         Debug.LogError(MaxHealth + " MAX HEALTH " + _player.Name);
        FirstPlayerTakeableDamage = new PlayerDecreaseableHealth(this);
        PlayerTakeableDamage = FirstPlayerTakeableDamage;
        _cameraHealthEffect = Camera.main.GetComponent<Animator>();

       // _shakerCamera = FindObjectOfType<ShakerCamera>();
        //ApplyDamage += _shakerCamera.ShakeCamera;
        if (IsLowHealth())
        {
            _cameraHealthEffect.SetBool("IsLow",false);
        }
//        _color = _playerSpriteRenderer.color;
    }
 
    public void TakeDamage(float _damage)
    {
        _damage = _damage * AdditionShield;
        TakedDamage = _damage;
        Debug.Log(_damage + " COOL " + IsCoolDown);
        if (IsLowHealth())
        {
            //_cameraHealthEffect.SetBool("IsLow",false);
        }
        if(_health > 0)
        {
         if (!IsCoolDown)
         {
             if(_getterPlayer.HealthsOutputs[0].gameObject.activeInHierarchy == true)
        {
             HealthOutput healthOutput =  _getterPlayer.HealthsOutputs.Find(e=>e.StartedPlayer.Name == _player.Name);
        healthOutput?.UpdateHealth();
        }
             //_player.IHealthOutPut.HealthOutput.UpdateHealth();
           //  Debug.LogError("Take damage");
             PlayerTakeableDamage.HandleTakingDamage();
             //Health -= _damage;
            // ApplyDamage?.Invoke();
            ShowHealth();
             StartCoroutine(CoolDown());
         }
        
        }
        else
        {
           DestroyPlayer();
           
        }
    }
    public void DestroyPlayer()
    {
         OnDead?.Invoke();
            Debug.Log("Dead");
             _selecterCharacter.LoadLastChanger(_player);
            _player.IsDead = true;
    }
    public void ShowHealth() 
    {
        Debug.LogError("Show health" + _player.IHealthOutPut.HealthOutput.gameObject.name);
        foreach (var item in _getterPlayer.HealthsOutputs)
        {
            Debug.LogError(item.StartedPlayer.Name + ". your player is: " + _player.Name);
        }
        if(_getterPlayer.HealthsOutputs[0].gameObject.activeInHierarchy == true)
        {
         HealthOutput healthOutput =  _getterPlayer.HealthsOutputs.Find(e=>e.StartedPlayer.Name == _player.Name);
        healthOutput?.TakeDamage();
        }
        ApplyDamage?.Invoke();
        // _player.IHealthOutPut.HealthOutput.TakeDamage();
    }
    private bool IsLowHealth()
    {
      return _health < MaxHealth / 2;
    }
    private IEnumerator CoolDown()
    {
        IsCoolDown = true;
//        _playerSpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(1);
      //  _playerSpriteRenderer.color = _color;
        IsCoolDown = false;
    }
  private void OnDisable() {
      ApplyDamage =null;
       if (IsLowHealth())
        {
            _cameraHealthEffect.SetBool("IsLow", true);
        }
  }
    public object Clone()
    {
       return new PlayerHealth{Health = this.Health};
    }

}
