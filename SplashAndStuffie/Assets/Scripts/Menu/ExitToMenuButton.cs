using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitToMenuButton : MonoBehaviour
{
    [SerializeField] private CanvasGroup _menu;
    private Settings _settings;
  private void Start() {
      _settings = FindObjectOfType<Settings>();
  }
  public void Exit()
  {
      _settings.LoadMenu();
      _menu.alpha = 0;
      _menu.blocksRaycasts = false;
  }
}
