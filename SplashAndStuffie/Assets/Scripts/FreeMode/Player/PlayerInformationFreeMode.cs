using System.Linq;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(PlayerMovementFreeMode))]
[RequireComponent(typeof(PlayerHealthFreeMode))]

public class PlayerInformationFreeMode : MonoBehaviour
{
    [SerializeField] private float _extraDamage;
        [SerializeField] private float _extraHealth;
    [SerializeField] private int _levelOfPlayer;
    public int LevelOfPlayer { get => _levelOfPlayer; set => _levelOfPlayer = value; }
    [SerializeField] private string _name;
    [SerializeField] private int _countOfMoneyForBuying = 20;
    [SerializeField] private int _damage  =2;
    [SerializeField] private PlayerMovementFreeMode _playerMovementFreeMode;
    [SerializeField] private float _speed = 0.8f;
    public event UnityAction OnDeath;
    [SerializeField] private float _health  =20;
  
      [SerializeField] private PlayerAnimatorFreeMode _playerAnimatorFreeMode;
    public PlayerAnimatorFreeMode PlayerAnimatorFreeMode { get => _playerAnimatorFreeMode; set => _playerAnimatorFreeMode = value; }
    [SerializeField] private bool _isBig;
   private PlaceRowFreeMode _placeRow;
   public bool CanMove { get; set; } = true;
       public bool IsBig { get => _isBig; set => _isBig = value; }
       [SerializeField] private float _range = 4;
    public PlaceRowFreeMode PlaceRow { get => _placeRow; set => _placeRow = value; }
    [SerializeField] private EnemyInformationFreeMode _closestEnemy;
    public EnemyInformationFreeMode ClosestEnemy { get => _closestEnemy; set =>_closestEnemy = value; }
      public float MaxHealth { get; set; }
    public float Health { get => _health; set => _health = value; }
    public float StartSpeed { get; set; }
    public float Speed { get => _speed; set => _speed = value; }
    public Vector2 Direction { get; set; }
    public PlayerMovementFreeMode PlayerMovementFreeMode { get => _playerMovementFreeMode; set => _playerMovementFreeMode = value; }
    public int Damage { get => _damage; set => _damage = value; }
    public int CountOfMoneyForBuying { get => _countOfMoneyForBuying; set => _countOfMoneyForBuying = value; }
    public string Name { get => _name; set => _name = value; }
    public Vector2 Size { get => _size; set => _size = value; }
    public float ExtraHealth { get => _extraHealth; set => _extraHealth = value; }
    public float ExtraDamage { get => _extraDamage; set => _extraDamage = value; }

    private PlayerCollectionFreeMode _playerCollection;
    private Vector2 _size;
    private bool _isChoosenSize = false;
    private void OnEnable() {
//        _playerCollection.AddPlayer(this);
    }
    private void Start() {
        
       // LevelOfPlayer = PlayerMovementFreeMode.Player.LevelOfPlayer;
        _playerCollection = FindObjectOfType<PlayerCollectionFreeMode>();
        MaxHealth = Health;
        if(_isChoosenSize == false)
        {
         StartSpeed = Speed;
        if(PlaceRow.IsRight)
        {
             transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
        }
        Size = transform.localScale;
        _isChoosenSize = true;
        }
        StartCoroutine(LookForEnemy());
    }
    private void Update() {
           transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, -13.62f, 13.74f), 
             Mathf.Clamp(transform.position.y, -15.066f, 6.17f),
             transform.position.z
        ); 
    }
    private IEnumerator LookForEnemy()
    {
        if(PlaceRow.Enemies.Count >= 0)
        {
        FindClosestEnemy();
        }
        yield return new WaitForSeconds(0.5f);   
        StartCoroutine(LookForEnemy());
    }
    public  EnemyInformationFreeMode FindClosestEnemy() 
    {
       
        float distance = Mathf.Infinity;
       Vector3 position = transform.position;
       if(IsBig == false || PlaceRow.IsTheHighestPlaceRow)
       {
        foreach (EnemyInformationFreeMode enemy in PlaceRow.Enemies) 
       {
           Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
           if(curDistance< distance) 
           {
                ClosestEnemy = enemy;
                distance = curDistance;
           }
        }
       }
      /* else   if(IsBig  && PlaceRow.IsTheHighestPlaceRow == false)
       {
           Debug.LogError("THE BIGGEST + !!!");
           List<EnemyInformationFreeMode> enemies = PlaceRow.Enemies;
           foreach (var item in PlaceRow.HigherPlaceRow.Enemies)
           {
               enemies.Add(item);
           }
           foreach (EnemyInformationFreeMode enemy in enemies) 
       {
           Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
           if(curDistance< distance) 
           {
                ClosestEnemy = enemy;
                distance = curDistance;
           }
        }
       }*/

        return ClosestEnemy;
    }
    public bool CanAttack()
    {
        if((_placeRow.Enemies.Count > 0))// && PlaceRow.CanMoveBack(this,false)) || (_placeRow.Enemies.Count > 0 && PlaceRow.CanMoveLowPlace(this,false)))
        {
            if(_placeRow.IsLowPlace == false)
            {
                if(_placeRow.CanMoveBack(this,false))
                {
              return Vector3.Distance(new Vector3( transform.position.x,0,0), new Vector3( ClosestEnemy.transform.position.x,0,0)) < _range;
                }
              else
              {
                  return false;
              }
            }
           // Debug.Log(PlaceRow.CanMoveBack(this,false));
         else 
         {
             if(_placeRow.CanMoveLowPlace(this,false))
             {
                    return Vector3.Distance(new Vector3(0,transform.position.y,0), new Vector3( 0,ClosestEnemy.transform.position.y,0)) < _range;
             }
             else
             {
                return false;
             }
         }
        }
        else
        return false;
    }
    private void OnDisable() {
       // _playerCollection.RemovePlayer(this);
    }
    public void  Destroy()
    {
        OnDeath?.Invoke();
    }
    public void GoBack()
    {
        if (_isChoosenSize == false)
        {
            if(PlaceRow.IsRight)
        {
            transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
        }
         StartSpeed = Speed;
        Size = transform.localScale;
            _isChoosenSize = true;
        }
        transform.localScale = new Vector2(-Size.x, Size.y);

    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.GetComponent<GeneratorFreeMode>() && _placeRow.Enemies.Count <= 0)
        {
            Speed = 0;
            transform.localScale = Size;
            PlayerAnimatorFreeMode.ArmatureComponent.animation.FadeIn("idle");
        }
    }
}
