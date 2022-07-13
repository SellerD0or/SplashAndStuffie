using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyTimer : MonoBehaviour
{
    private float _time;
    private float _second;
    [SerializeField] private Redactor _redactor;
    private void OnEnable() {
      if (PlayerPrefs.HasKey("LobbyTime"))
      {
          _time = PlayerPrefs.GetFloat("LobbyTime");
      }
    }
    private void Update() {
        _second += Time.deltaTime;
        if (_second >= 1)
        {
            _time++;
            if (_time >= 150)
            {
                _time =0;
                Debug.Log("TIME IS OVER!!!");
                _redactor.CloseScene();
            }
            PlayerPrefs.SetFloat("LobbyTime",_time);
            _second =0;
        }
    }
}
