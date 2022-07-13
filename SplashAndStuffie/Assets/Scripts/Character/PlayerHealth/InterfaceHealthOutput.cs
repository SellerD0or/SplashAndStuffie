using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InterfaceHealthOutput : MonoBehaviour
{
    [SerializeField] private HealthOutput _healthOutPut;
    [SerializeField] private List<Image> _hearts;
        private float _fillValue;

   [SerializeField] private Image _currentHeart;
    private float _partOfMaxHealth;
    private int _currentNumberOfHealth;

    public float FillValue { get => _fillValue; set => _fillValue = value; }

    private void Start() {
        _healthOutPut.OnTakeDamage += ChangeHearts;
       // _partOfMaxHealth = (_healthOutPut.StartedPlayer.PlayerHealth.MaxHealth / 5);
    }
    private void ChangeHearts()
    {
        FillValue = (float) _healthOutPut.StartedPlayer.PlayerHealth.Health;
        FillValue = FillValue / _healthOutPut.StartedPlayer.PlayerHealth.MaxHealth;
        _currentHeart.fillAmount = FillValue;
    }
}
