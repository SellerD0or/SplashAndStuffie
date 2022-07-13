using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyWarriorHealthOutPut : MonoBehaviour, IEnemyOutPut
{
    [SerializeField] private Image _healthBar;
     private float _fillValue;

    public Enemy Enemy { get ; set ; }

    private void Start() {
           Enemy = GetComponent<Enemy>();
     Enemy.IEnemyHealth.OnTakeDamage += ShowEnemyHealth;
     }
    public void ShowEnemyHealth()
    {
        _fillValue = (float)Enemy.IEnemyHealth.Health;
        _fillValue = _fillValue / Enemy.IEnemyHealth.MaxHealth;
        _healthBar.fillAmount = _fillValue;
    }
}
