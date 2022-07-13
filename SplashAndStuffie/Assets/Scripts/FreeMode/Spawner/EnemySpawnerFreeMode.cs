using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnerFreeMode : MonoBehaviour
{
   private bool _isSpawnLastLevel = false;
    [SerializeField] private BackgroundOfCardFreeMode _background;
    [SerializeField] private Text _text;
    [SerializeField] private WaveOfEnemiesFreeMode _waveOfEnemies;
    [SerializeField] private Image _progressBAr;
    [SerializeField] private List<EnemySpawnPositionFreeMode> _enemySpawnPositions;
    private List<WaveFreeMode> _waves = new List<WaveFreeMode>();
   // private List<EnemyInformationFreeMode> _currentEnemies = new List<EnemyInformationFreeMode>();
    private float _fillValue;
    private int _countOfLevel;
    private ScreenOfEndOfTheGameFreeMode _screen;
    private int _additionStat = 1;
    private void Start() {
        _background.OnStartNewMinute += OnStartNewMinute;
        _screen =FindObjectOfType<ScreenOfEndOfTheGameFreeMode>();
        foreach (var wave in _waveOfEnemies.Waves)
        {
            _waves.Add(wave);
        }
        StartCoroutine(CoolDown());
        
    }
    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(1);
      
        if(_waves[_countOfLevel].CountOfEnemies > 0)
        {
           
         int random = Random.Range(0, _waves[_countOfLevel].Enemies.Count);
           if (_countOfLevel == _waves.Count -1 && _isSpawnLastLevel==false)
        {
           List<EnemyInformationFreeMode> enemies = _waves[_countOfLevel].Enemies.FindAll(e=> e.Name == "MINI BOSS");
                _enemySpawnPositions[0].PlaceRow.FirstPlace.CreateEnemy(enemies[0],this, _additionStat, _enemySpawnPositions[0]);
                _waves[_countOfLevel].Enemies.Remove(enemies[0]);
                _enemySpawnPositions[7].PlaceRow.FirstPlace.CreateEnemy(enemies[1],this, _additionStat, _enemySpawnPositions[7]);
                _waves[_countOfLevel].Enemies.Remove(enemies[1]);         
                _enemySpawnPositions[11].PlaceRow.FirstPlace.CreateEnemy(enemies[2],this, _additionStat, _enemySpawnPositions[11]);   
                _waves[_countOfLevel].Enemies.Remove(enemies[2]);
                _isSpawnLastLevel =true;               
        }
         int randomPosition = Random.Range(0, _enemySpawnPositions.Count);
         _enemySpawnPositions[randomPosition].PlaceRow.FirstPlace.CreateEnemy(_waves[_countOfLevel].Enemies[random],this, _additionStat, _enemySpawnPositions[randomPosition]);
        _waves[_countOfLevel].Enemies.Remove(_waves[_countOfLevel].Enemies[random]);
         _waves[_countOfLevel].CountOfEnemies--;
      StartCoroutine(CoolDown());
        }
       //Show();
    }
    public void Remove()
    {
        _waves[_countOfLevel].CurrentCountOfEnemies --;
        Debug.Log(_waves[_countOfLevel].CurrentCountOfEnemies + " Sssfsafsa");
        if (_waves[_countOfLevel].CurrentCountOfEnemies <= 0)
        {
            
            _countOfLevel ++;
            Debug.Log("LEVEL + " + _countOfLevel);
            if (_countOfLevel >= _waves.Count)
            {
                Debug.Log("NEW LEVEL" + _countOfLevel);
                GeneratorFreeMode generator = FindObjectOfType<GeneratorFreeMode>();
                generator.SetEndGamePosition();
                _screen.Win();
            }
            else if(_countOfLevel < _waves.Count)
            {
            StartCoroutine(CoolDown());
            }
        }
    }
    private void OnStartNewMinute()
    {
          if (_background.Minute == 0)
       {
          _additionStat = Random.Range(1,7);
       }
       else if (_background.Minute == 1)
       {
          _additionStat = Random.Range(12,20);
       }
         else if (_background.Minute == 2)
       {
          _additionStat = Random.Range(12,20);
       }
         else if (_background.Minute == 3)
       {
          _additionStat = Random.Range(22,26);
       }
         else if (_background.Minute == 4)
       {
          _additionStat = Random.Range(28,30);
       }
         else if (_background.Minute == 5)
       {
          _additionStat = Random.Range(31,33);
       }
         else if (_background.Minute >= 6)
       {
          _additionStat = Random.Range(34,35);
       }
    }
    private void Show()
    {
        _text.text = $" Волна содержит: {_waves[_countOfLevel].AllEnemies.Count} врагов. Сейчас осталось: {_waves[_countOfLevel].CurrentCountOfEnemies} врагов!";
     //   Debug.Log(_waveOfEnemies.Waves.Count + " / " + _currentEnemies.Count);
       //   _fillValue = _currentEnemies.Count;
       // _fillValue = _fillValue / _waveOfEnemies.Waves.Count;
       // Debug.Log(_fillValue);
        //_progressBAr.fillAmount = _fillValue;
    }
}
