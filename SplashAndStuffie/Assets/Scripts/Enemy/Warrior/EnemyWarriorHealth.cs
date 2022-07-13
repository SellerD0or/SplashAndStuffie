using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyWarriorHealth : MonoBehaviour, IEnemyHealth
{
    [SerializeField] private EnemyFire _enemyFire;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private int _health;
    public int Health { get => _health; set => _health = value; }
    public int MaxHealth { get ; set; }
    private Enemy _enemy;

    public event UnityAction OnDestroy;
    public event UnityAction OnTakeDamage;
     public ParticleSystem ParticleSystem { get => _particleSystem; set => _particleSystem = value; }
    public bool CanAttack { get ; set ; }
    [SerializeField]  private CounterOfCharacterKills _counterOfCharacterKills;
    public CounterOfCharacterKills CounterOfCharacterKills { get => _counterOfCharacterKills; set => _counterOfCharacterKills = value; }
    public EnemyFire EnemyFire { get => _enemyFire; set => _enemyFire = value; }
    public float TimeForExtraDamage { get; set ; } = 0;
    public float LastAppiedDamage { get => _lastAppiedDamage; set => _lastAppiedDamage = value; }

    private float _lastAppiedDamage;
    private void OnEnable() {
        CanAttack = false;
    }
    private void Awake() {
        CounterOfCharacterKills = FindObjectOfType<CounterOfCharacterKills>();
        
    }
    private void Start() {
        _enemy = GetComponent<Enemy>();
        CounterOfCharacterKills.AddEnemy(_enemy);
        //ParticleSystem.Stop();
        MaxHealth = Health;
        OnDestroy += Destroy;
        OnTakeDamage += CreateParticlies;
    }
    public void TakeDamage(int damage)
    {
       
        if(!CanAttack)
        {
       
           Health -= damage;
           LastAppiedDamage = damage;
           OnTakeDamage?.Invoke();
           StartCoroutine(CoolDown());
         
        }
           if(Health <= 0)
           {
               Debug.Log(name + " enemy should be detroy!!!");
           OnDestroy?.Invoke();
           }
    }
    public IEnumerator CoolDown()
    {
        CanAttack = true;
        yield return new WaitForSeconds(1);
        CanAttack = false;
    }

    public void Destroy()
    {
        CounterOfCharacterKills.RemoveEnemy(_enemy);
        EnemyFire enemyFire = Instantiate(_enemyFire,transform.position,Quaternion.identity);
        enemyFire.IsAppear = true;
        Destroy(gameObject);
    }

    public void CreateParticlies()
    {
        
       // ParticleSystem.Play();
    }

    public IEnumerator ApplyExtraDamage(int damage)
    {
        yield return new WaitForSeconds(1);
        Debug.LogError("TAKE DAMAGE BY POST ROCKET EFFECT!!!" + TimeForExtraDamage);
           TimeForExtraDamage++;
            TakeDamage(damage);
        if (TimeForExtraDamage > 6)
        {
            TimeForExtraDamage = 0;
        }
        else
        {
            StartCoroutine(ApplyExtraDamage(damage));
        }
    }

    public void StartApplyingExraDamage(int damage)
    {
        Debug.LogError("EXTRA DAMGE!!!");
        StartCoroutine(ApplyExtraDamage(damage));
    }
}
