using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public event UnityAction OnTimeChanged;
    private float _time;
    private int _currentMinute;
    private int _currentSecond;
    public int CurrentSecond { get => _currentSecond; set => _currentSecond = value; }
    public int CurrentMinute { get => _currentMinute; set => _currentMinute = value; }

    private void Update() {
        _time += Time.deltaTime;
        if (_time > 1)
        {
            if (CurrentSecond > 59)
            {
                CurrentMinute++;
                CurrentSecond =0;
            }
            OnTimeChanged?.Invoke();
            CurrentSecond++;
            _time = 0;
        }
    }
}
