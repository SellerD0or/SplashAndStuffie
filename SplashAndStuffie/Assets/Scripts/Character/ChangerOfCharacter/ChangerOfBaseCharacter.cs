using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangerOfBaseCharacter : ChangerOfPlayer
{
     [SerializeField] private GetterPlayer _getterPlayer;
     [SerializeField] private Player _currentPlayer;
    public override Player Player { get => _currentPlayer; set => _currentPlayer = value; }
    public override GetterPlayer GetterPlayer { get => _getterPlayer; set => _getterPlayer = value; }
    [SerializeField] private HealthOutput _healthOutput;
    public override bool IsChoosen { get; set ; }
    private void Start() {
       // _healthOutput.StartedPlayer = _getterPlayer.LoadedPlayer;
        Debug.Log(_getterPlayer.LoadedPlayer);
        _healthOutput.ChangeIcon();
    }
       public override void ChangeCharacter(bool _isNormal)
    {
       // GetterPlayer.ChooseBaseCharacter();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
      
    }
}
