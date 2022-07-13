using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieCreditsButton : MonoBehaviour
{
    [SerializeField] private MovieCredits _movieCredits;
    private ShopSettings _shopSettings;
  private void Start() {
    _shopSettings = FindObjectOfType<ShopSettings>();
    _shopSettings.OnPlayGame += Exit;
  }
  public void Open()
  {
    _movieCredits.gameObject.SetActive(true);
  }
  private void Exit()
  {
    _movieCredits.gameObject.SetActive(false);
  }
}
