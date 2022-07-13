using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestPlayerHealthOutPut : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
        private float _fillValue;
        [SerializeField] private CanvasGroup _canvasGroup;
   private Player _player;

    public CanvasGroup CanvasGroup { get => _canvasGroup; set => _canvasGroup = value; }
    public Player Player { get => _player; set => _player = value; }

    private void Start() {
     Player.PlayerHealth.ApplyDamage += ShowEnemyHealth;
     Player.PlayerHealth.OnDead+= Destroy;
     }
     public void Destroy()
     {
     TestChangerPlayer changerPlayer =Player.GetComponent<TestClickableCharacter>().Changer;
    TestPlayerPosition position = changerPlayer.PlayerPositions.Find(e => e.Player.Name == Player.Name);
     changerPlayer.Create();
     position.Create();
         Destroy(gameObject);
     }
    public void ShowEnemyHealth()
    {
        _fillValue = (float)Player.PlayerHealth.Health;
        _fillValue = _fillValue / Player.PlayerHealth.MaxHealth;
        _healthBar.fillAmount = _fillValue;
    }
   
}
