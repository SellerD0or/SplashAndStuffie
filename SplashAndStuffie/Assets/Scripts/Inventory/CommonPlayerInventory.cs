using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonPlayerInventory : Inventory
{
    [SerializeField] private List<ItemSlot> _itemSlots;
    [SerializeField] private List<Item> _items;
    public override List<Item> Items { get => _items; set => _items = value ; }
    private void Start() {
     _itemSlots.ForEach(e => e.AddItem(Items[0]));
    }
}
