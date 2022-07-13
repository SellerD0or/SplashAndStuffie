using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelecterLevel : MonoBehaviour
{
    [SerializeField] private string _nameOfLevel = "Game";
    private Settings _settings;
    private void Start() {
        _settings = FindObjectOfType<Settings>();
    }
    public void OnClick()
    {
        _settings.LoadSelectCharacter();
        PlayerPrefs.SetString("NameOfLevel", _nameOfLevel);
    }
}
