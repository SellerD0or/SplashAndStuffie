using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateBehaviour : MonoBehaviour, IEnemyStateSwitcher
{
    private BaseEnemyState _currentState;
    [SerializeField] private Enemy _enemy;
    private List<BaseEnemyState> _states;
    private void Start() {
          _states = new List<BaseEnemyState>()
        {
           
            new RunnableState(this,_enemy),
             new AttackableState(this,_enemy)
        }; 
        _currentState = _states[0];
    }
    private void Update() {
        Move();
        Attack();
        Stay();
    }
    public void Attack()
    {
        _currentState.Attack();
    }
    public void Move()
    {
        _currentState.Run();
    }
    public void Stay()
    {
        _currentState.Stay();
    }
    public void SwitchState<T>() where T : BaseEnemyState
    {
        var _state = _states.FirstOrDefault(s => s is T);
        _currentState = _state;
    }
}
