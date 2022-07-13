using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropExit : MonoBehaviour
{
    [SerializeField] private Settings _settings;
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _settings.LoadOtisShop();
        }
    }
    private void Start() 
    {
      PlayerPrefs.SetString("OtisShop","DROP");
    }
}
