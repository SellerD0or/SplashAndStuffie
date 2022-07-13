using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.EventSystems;
public class ChangerOfSelectedCharacter : ChangerOfPlayer
{
   [SerializeField] private Player _currentPlayer;
   [SerializeField] private GetterPlayer _getterPlayer;

    public override Player Player { get => _currentPlayer; set => _currentPlayer = value; }
    public override GetterPlayer GetterPlayer { get => _getterPlayer; set => _getterPlayer = value; }
    
    public override bool IsChoosen { get; set ; }

    public override void OnPointerClick(PointerEventData eventData)
    {
      
    }
    public override void ChangeCharacter(bool _isNormal)
    {
        
        GetterPlayer.ChangeCurrentCharacter(Player, this);
    }
}
