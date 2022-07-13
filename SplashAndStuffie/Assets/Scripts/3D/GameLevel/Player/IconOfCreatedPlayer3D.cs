using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconOfCreatedPlayer3D : MonoBehaviour
{
  [SerializeField] private Image _icon;
  private bool _isSelectedPlayer;

    public bool IsSelectedPlayer { get => _isSelectedPlayer; set => _isSelectedPlayer = value; }
    public Player SelectedCharacter { get => _selectedCharacter; set => _selectedCharacter = value; }

    private Player _selectedCharacter;
    public void Create(Player player)
    {
        IsSelectedPlayer = true;
        SelectedCharacter = player;
        ChangeIcon();
    }
    private void ChangeIcon()
  {
      _icon.sprite = SelectedCharacter.BarIcon;
  }
}
