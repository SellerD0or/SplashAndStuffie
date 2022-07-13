using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardOfReloadingAbility : MonoBehaviour
{
    private bool _canReload;
    [SerializeField] private CanvasGroup _canvasGroup;
  private Player _player;
  private float _reloadAmount = 0;
  [SerializeField] private MiniBoardOfReloadingAbility _miniBoard;
    public Player Player { get => _player; set => _player = value; }
    public CanvasGroup CanvasGroup { get => _canvasGroup; set => _canvasGroup = value; }
    public bool IsEndedReloading { get => _isEndedReloading; set => _isEndedReloading = value; }

    private List<MiniBoardOfReloadingAbility> _currentMiniBoards = new List<MiniBoardOfReloadingAbility>();
    private bool _isEndedReloading;
    [SerializeField] private float _additionalX = 800,_additionalY = 500;
    private float _timeForReloading;
    private void Start() {
        Debug.Log(Player + " YEH?PLAYER!!!");
        if(_player.Ultimate != null)
        {
         _player.Ultimate.MaxAmountOfReloading = _player.Ultimate.AmountOfReloadig;
         
        for (int i = 0; i < _player.Ultimate.MaxAmountOfReloading; i++)
        {
            MiniBoardOfReloadingAbility miniBoard = Instantiate(_miniBoard,transform.position,Quaternion.identity);
            miniBoard.transform.SetParent(transform,false);
            miniBoard.OnReload += Add;
            miniBoard.TimeForRemoving = (_player.Ultimate.MaxAmountOfReloading -i) / 10;
            miniBoard.TimeForAdding = (_player.Ultimate.MaxAmountOfReloading + i) / 10;
            _timeForReloading += miniBoard.TimeForRemoving;
            _currentMiniBoards.Add(miniBoard);
        }
        UpdateAmount();
        _player.Ultimate.OnRemove += RemoveAmount;
        _player.Ultimate.OnUploadAmount+= UpdateAmount;
        _player.Ultimate.OnReload += ReloadAmount;
       }
    }
    public void SetPosition(HealthOutput healthOutput,PlayerInterface playerInterface)
    {
      //  -360;272
        transform.localScale = new Vector2(0.2296766f,0.08755239f);
          
    
         
    }
    public void SetNormalPosition(Transform position,HealthOutput healthOutput,PlayerInterface playerInterface)
    {
        transform.localScale = new Vector2(1.668401f,0.6359923f);
                transform.localPosition = position.position;

          if (healthOutput.Index == 0)
    {
      healthOutput.PlayerHealth.CurrentBoards[1].transform.localPosition = playerInterface.TopBoardPosition.position;
      healthOutput.PlayerHealth.CurrentBoards[2].transform.localPosition = playerInterface.BottomBoardPosition.position;
    }
    if (healthOutput.Index == 1)
    {
            healthOutput.PlayerHealth.CurrentBoards[0].transform.localPosition = playerInterface.TopBoardPosition.position;
      healthOutput.PlayerHealth.CurrentBoards[2].transform.localPosition = playerInterface.BottomBoardPosition.position;

    }
    if (healthOutput.Index == 2)
    {
          healthOutput.PlayerHealth.CurrentBoards[0].transform.localPosition = playerInterface.TopBoardPosition.position;
      healthOutput.PlayerHealth.CurrentBoards[1].transform.localPosition = playerInterface.BottomBoardPosition.position;
    }
    }
    private void Add()
    {
        if(_player.Ultimate != null)
        {
        if (_player.Ultimate.AmountOfReloadig < _player.Ultimate.MaxAmountOfReloading)
        {
            _player.Ultimate.AmountOfReloadig++;
            _reloadAmount =0;
        }
        }
    }
    private IEnumerator CoolDown()
    {

        yield return new WaitForSeconds(_player.Ultimate.ProcentOfReloading);
        if (_player.Ultimate.AmountOfReloadig < _player.Ultimate.MaxAmountOfReloading)
        {
            _player.Ultimate.AmountOfReloadig++;
        UpdateAmount();
        }
        StartCoroutine(CoolDown());

    }
    private void ReloadAmount(float amount)
    {
         if(_player.Ultimate != null)
        {
        if(_player.Ultimate.AmountOfReloadig < _player.Ultimate.MaxAmountOfReloading)
        {
        _reloadAmount += amount;
        _currentMiniBoards[(int)_player.Ultimate.AmountOfReloadig].Reload(_reloadAmount);
        }
        }
    }
    private void UpdateAmount()
    {
         if(_player.Ultimate != null)
        {
        if(_canReload)
        {
        for (int i = 0; i < _player.Ultimate.AmountOfReloadig; i++)
        {
            if(_currentMiniBoards[i].IsFull)
            {
                _currentMiniBoards[i].UseAbility();
            }
        }
        }
        }
    }
    public void RemoveAmount()
    {
         if(_player.Ultimate != null)
        {
        _player.Ultimate.AmountOfReloadig = 0;
          _reloadAmount =0;
          _canReload = true;
          IsEndedReloading = true;
        for (int i = 0; i < _player.Ultimate.MaxAmountOfReloading; i++)
        {
            Debug.LogError("NAME: " + _currentMiniBoards[i].name + " , " + " TIME FOR RELOADING: " + _currentMiniBoards[i].TimeForRemoving);
            _currentMiniBoards[i].RemoveAbility();
        }
        _canReload = false;
        Invoke(nameof(EndReloading), _timeForReloading);
        }
    }
    private void EndReloading() => IsEndedReloading = false;
}
