using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : Target, IDamageable
{
    public abstract IEnemyOutPut IEnemyOutPut {get;set;}
    public abstract float MaxDistance {get;set;}
    public abstract IEnemyHealth IEnemyHealth { get; set; }
    public abstract Player Player { get; set; }
    public Target Target { get; set; }
    public abstract float Speed { get; set; }
    public abstract int Damage {get;set;}
    public abstract float AttackDistance {get;set;}
    public abstract void Accept(IVisitor visitor);
    public abstract IEnemyAttackable  IEnemyAttackable{get;set;}
    public abstract IEnemyMovement IEnemyMovement { get; set; }    
    public abstract bool CanAttack();
    public abstract TakerDamageVisitor Visitor {get;set;}
    public abstract GetterPlayer GetterPlayer { get; set; }
    public abstract IEnemyAnimator IEnemyAnimator {get;set;}
    public abstract void GetPlayer();
    public bool IsBewitched { get; set; }
    public List<Enemy> Enemies { get => _enemies; set => _enemies = value; }
    private Target[] _targets; 
    public bool IsUnderPlayerControl { get; set; }
    public event UnityAction OnDestroyed;
        private List<Enemy> _enemies = new List<Enemy>();

    public IEnumerator Find()
    {
        FindClosestTarget();
        yield return new WaitForSeconds(2f);
        StartCoroutine(Find());
    }
    public Target FindClosestTarget()
    {
        _targets =FindObjectsOfType<Enemy>();
        List<Target> allTargets = new List<Target>();
        allTargets.Clear();
        foreach (var item in _targets)
        {
            if(item is Enemy enemy)
            {
            if(enemy.IsUnderPlayerControl == false)
            {
            allTargets.Add(item);
            }
            }
        }
        allTargets.Add(Player);
        List<Target> currentTargets = new List<Target>();
        currentTargets.Clear();
       
        foreach (var item in allTargets)
        {
            if(item is Enemy && IsBewitched == false || item == this)
            {
                continue;
            }
            Debug.Log(item + " FIND IT!!!");
            currentTargets.Add(item);
        }
         if (IsBewitched)
        {
            List<Target> targets = new List<Target>();
            foreach (var item in currentTargets)
            {
                if (item is Player)
                {
                    continue;
                }
                targets.Add(item);
            }
         currentTargets = targets;   
        }
         float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (Target target in currentTargets) {
            Vector3 diff = target.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance< distance) {
                Target = target;
                distance = curDistance;
            }
        }
        return Target;
    }
     public void TurnOff()
    {
        gameObject.SetActive(false);
    }
    public void TurnOn()
    {
        gameObject.SetActive(true);
    }
    public bool CanStop()
    {
           return Vector2.Distance(transform.position, Player.transform.position) > MaxDistance;
    }
    private void OnDestroy() {
        OnDestroyed?.Invoke();
    }
    public void RemoveWitching()
    {
         foreach (var enemy in Enemies)
        {
            enemy.IsBewitched = false;
        }
        
    }
   
}
