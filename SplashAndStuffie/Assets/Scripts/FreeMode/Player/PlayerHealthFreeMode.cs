using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthFreeMode : MonoBehaviour
{
    public PlaceRowFreeMode PlaceRow { get; set; }
    public PlayerInformationFreeMode PlayerInformation { get => _playerInformation; set => _playerInformation = value; }
    public float AdditionShield { get => _additionShield; set => _additionShield = value; }

    [SerializeField] private PlayerInformationFreeMode _playerInformation;
    private float _additionShield = 1;
  private void Start() {
      PlayerInformation.OnDeath += Destroy;
  }
  public void TakeDamage(float damage)
  {
      damage = damage * AdditionShield;
      Debug.Log(damage);
      if(PlayerInformation.Health > 0)
      {
      PlayerInformation.Health -= damage;
      }
      else
      {
          PlayerInformation.Destroy();
      }

  }
  private void Destroy()
  {
      PlaceRow.RemovePlayer(PlayerInformation);
      Destroy(gameObject);
  }

}
