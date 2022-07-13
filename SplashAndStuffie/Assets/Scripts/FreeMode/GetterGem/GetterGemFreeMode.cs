using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GetterGemFreeMode : MonoBehaviour
{
    public event UnityAction OnGetGem;
    [SerializeField] private int _countOfGem;
    private float _time;
    [SerializeField] private int _maxCountOfGems =20;
    public int CountOfGem { get => _countOfGem; set => _countOfGem = value; }
    public void Buy(int countOfGems)
    {
            Debug.Log("BUY " + countOfGems);
        CountOfGem -= countOfGems;
        OnGetGem?.Invoke();
    }
    private void Update() {
        _time+= Time.deltaTime;
        if (_time >= 2)
        {
            if(CountOfGem < _maxCountOfGems)
            {
            CountOfGem++;
            OnGetGem?.Invoke();
            }
            _time =0;
            
        }
    }
}
