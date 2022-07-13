using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
public abstract class PlayerAnimatorFreeMode : MonoBehaviour
{
    private PlayerInformationFreeMode _player;
    [SerializeField] private UnityArmatureComponent _unityArmatureComponent;
    [SerializeField] private float _runTime;
    [SerializeField] private float _idleTime;
    [SerializeField] private float _attackTime;
    public UnityArmatureComponent ArmatureComponent {get => _unityArmatureComponent;set => _unityArmatureComponent = value;}
    public float RunTime { get => _runTime; set => _runTime = value; }
    public float IdleTime { get => _idleTime; set => _idleTime = value; }
    public float AttackTime { get => _attackTime; set => _attackTime = value; }
    public bool CanStart { get; set; }
    public PlayerInformationFreeMode Player { get => _player; set => _player = value; }

    public abstract void Run();
    public abstract void Idle();
    public abstract void Attack();
    public virtual void UseAbility()
    {

    }
    public abstract void PlayRunAnimation();
    public abstract IEnumerator CoolDown(float time);
}
