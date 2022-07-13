using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBoard : MonoBehaviour
{
    private bool _isClicked;
    private SelectedSlotOfPlayer _currentSelectedSlotOfPlayer;
    private List<SelectedSlotOfPlayer> _selectedSlotOfPlayers = new List<SelectedSlotOfPlayer>();

    public List<SelectedSlotOfPlayer> SelectedSlotOfPlayers { get => _selectedSlotOfPlayers; set => _selectedSlotOfPlayers = value; }
    public SelectedSlotOfPlayer CurrentSelectedSlotOfPlayer { get => _currentSelectedSlotOfPlayer; set => _currentSelectedSlotOfPlayer = value; }
    public bool IsClicked { get => _isClicked; set => _isClicked = value; }
}
