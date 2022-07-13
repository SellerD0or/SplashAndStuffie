using System.Text.RegularExpressions;
using System.ComponentModel;
using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CreatorSlotOfItem : MonoBehaviour
{
     [SerializeField] private SaverDroppedLoot _saverDroppedLoot;
  [SerializeField] private ItemSlot _slotOfItem;
  [SerializeField] private Transform _spawnPosition;
  [SerializeField] private List<ItemSlot> _slots;
  [SerializeField] private Item _emptyItem;
  [SerializeField] private Transform _equipment;
  [SerializeField] private   List<int> _rarities = new List<int>();
  [SerializeField]   private int _number = 0;
  [SerializeField]  private  List<string> _itemsInInventory = new List<string>();
  [SerializeField] private SaverInventory _saverInventory;
  public void Create() {
    //  Debug.LogError("everything is ok");
    //  _saverDroppedLoot.CurrentSaveableCurrentInventory.CurrentItems.RemoveAll(item => item == null);
   //_saverDroppedLoot.SaveSaveableCurrentInventory(_saverDroppedLoot.CurrentSaveableCurrentInventory);
   List<Item> items = new List<Item>();
   List<Item> oneNameItems = new List<Item>();
   foreach (var item in _saverDroppedLoot.CurrentSaveableCurrentInventory.CurrentItemNames)
   {
      int pos = item.IndexOf(',');
      string name = item.Substring(0,pos);
      string rarityName = item.Remove(0,pos +1);
      int rarity = Convert.ToInt32(rarityName);
      _rarities.Add(rarity);
      oneNameItems = _saverDroppedLoot.AllTheItems.FindAll(e=> e.FullName == name);
      Item item3 = oneNameItems.Find(e=>(int) e.Rarity == rarity);
      items.Add(item3);
      Debug.LogError(items.Count + " item: " + item3  + " NORMAL !!!");
      if(_saverInventory.CurrentSaveableSlotOfCharacter.CurrentItemNames.Count > 0)
      {
       foreach (var itemName in _saverInventory.CurrentSaveableSlotOfCharacter.CurrentItemNames)
        {
            string[] items2 = itemName.Split(new char[] {','});
            List<string> namesOfItems = items2.ToList();
            string checkedName = "";
            namesOfItems.Remove(namesOfItems[0]);
            Debug.LogError("DIVIIDING!!! " + itemName + namesOfItems.Count);
            foreach (var item2 in namesOfItems)
            {
                int pos2 = item2.IndexOf('?');
               string middleNameOfItem = item2.Substring(0,pos2);
                int pos3 = item2.IndexOf('!');
                string fullName = item2.Substring(0,pos3);
                string rarityStr = middleNameOfItem.Remove(0,pos3 +1);
                int rarity2  =Convert.ToInt32(rarityStr);
                checkedName = fullName + "," + rarity2;
                Debug.LogError(checkedName + " NEED + " + item);
                if (checkedName == item)
                {
                  _itemsInInventory.Add(checkedName);
                  break;
                }
                //string position = item2.Remove(0,pos2 +1);
            //    int numberOfItem = Convert.ToInt32(position);
               // Debug.LogError(fullName + " Rarity: " + rarity + " " + " position: " + numberOfItem);            
             }
         }
        }
   }
      foreach (var item in items)
      {
         Debug.Log(item + " We have it");
         ItemSlot itemSlot = Instantiate(_slotOfItem, transform.position, Quaternion.identity);
             if(_itemsInInventory.Contains(item.FullName + "," + _rarities[_number]) == false)
         {
           Debug.LogError(item + "IS EMPTY!!221");
                  itemSlot.AddItem(item);
          }
         itemSlot.gameObject.transform.SetParent(_spawnPosition,false);
         itemSlot.Background.sprite = itemSlot.Sprites[_rarities[_number]];
         _number++;
//         Debug.Log(item.FullName + "," + _rarities[_number] + " PERFECT!!!");
      
        // itemSlot.Background.sprite = itemSlot.Sprites[(int)item.Rarity];
      }
  }
}
