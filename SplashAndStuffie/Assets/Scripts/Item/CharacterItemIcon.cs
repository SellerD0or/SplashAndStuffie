using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterItemIcon : MonoBehaviour
{
  private Equipment _equipment;
    private SlotOfCharacter _slotOfCharacter;
    [SerializeField] private ItemSlot _itemSlot;
    public ItemSlot ItemSlot { get => _itemSlot; set => _itemSlot = value; }
    [SerializeField] private EquipmentOfCharacter _equipmentOfCharacter;
    [SerializeField] private Image _icon;
    [SerializeField] private Color[] _colors;
    private void Start() {
      _equipment = FindObjectOfType<Equipment>();
      _itemSlot = GetComponent<ItemSlot>();
          _equipmentOfCharacter.CharacterIcons.Add(this);

        ItemSlot.OnAdd += OnAdd;
        ItemSlot.OnRemove += OnRemove;
        if (ItemSlot.Item == null)
        {
          ClearColor();
        }
        else
        {
          SetColor();
        }
    }
    public void SetPlayer(SlotOfCharacter slotOfCharacter)
    {
     // _slotOfCharacter = slotOfCharacter;
    // _currentPlayer =  _equipment.Player;
    }
    public void OnAdd()
    {
      SetColor();
      //  _equipmentOfCharacter.Add(ItemSlot.Item);
    //_slotOfCharacter.AddItem(ItemSlot.Item);
    //_slotOfCharacter.CurrentItems.Add(ItemSlot.Item);
    }
    private void ClearColor() =>    _icon.color = _colors[0];
    private void SetColor() =>  _icon.color = _colors[(int)ItemSlot.Item.Rarity + 1];
    public void OnRemove()
    {
      ClearColor();
      //  _equipmentOfCharacter.Remove(ItemSlot.Item);
        //_slotOfCharacter.RemoveItem(ItemSlot.Item);
    }
   
    public void RemoveSlot() {
      if (_equipmentOfCharacter.CharacterIcons.Contains(this))
      {
          _equipmentOfCharacter.CharacterIcons.Remove(this);
      }
      //if (_itemSlot.Item != null)
     // {
     // _equipment.SaverInventory.Save(new SaveableSlotOfCharacter() {ItemName = _itemSlot.Item + "," + (int) _itemSlot.Item.Rarity + "." + _equipment.EquipmentInterface.SlotOfCharacter.Player.Name});
     // }
      
    }
}
