using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyHealth : MonoBehaviour
{
   private EnemyWarriorHealth _enemyHealth;
   private TestEnemyText _enemyText;
    public TestEnemyText EnemyText { get => _enemyText; set => _enemyText = value; }

    private void Start() {
       _enemyHealth = GetComponent<EnemyWarriorHealth>();
       _enemyHealth.OnTakeDamage += ShowHealth; 
   }
   private void ShowHealth()
   {
       TestEnemyText enemyText = Instantiate(EnemyText,transform.position + new Vector3(Random.Range(-3,3),Random.Range(-3,3),0),Quaternion.identity);
       enemyText.Text.text = _enemyHealth.LastAppiedDamage.ToString();
   }
}
