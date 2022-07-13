using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentOfCharacter : MonoBehaviour
{
  private Player _player;
  [SerializeField] private List< ItemSlot> _itemSlots;

    public List<ItemSlot> ItemSlots { get => _itemSlots; set => _itemSlots = value; }
    public CharacterItemIcon[] Icons { get => _icons; set => _icons = value; }

    [SerializeField] private CharacterItemIcon[] _icons;
        public  List<CharacterItemIcon> CharacterIcons { get => _characterIcons; set => _characterIcons = value; }
    public Player Player { get => _player; set => _player = value; }

    private List<CharacterItemIcon> _characterIcons = new List<CharacterItemIcon>();

    private Equipment _equipment;

    private void OnEnable() {
      //Icons = GetComponentsInChildren<CharacterItemIcon>();
    }
}
