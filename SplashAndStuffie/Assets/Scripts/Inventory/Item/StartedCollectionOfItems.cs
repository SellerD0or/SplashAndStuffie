using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class StartedCollectionOfItems : MonoBehaviour
{
    private EquipmentOfCharacter _equipmnetOfCharacter;
    private Equipment _equipment;
    private void Start() {
        _equipmnetOfCharacter = GetComponent<EquipmentOfCharacter>();
        _equipment = FindObjectOfType<Equipment>();
        Create();
    }
    private void Create()
    {
        Debug.LogError("TRYYYY!!!");
      foreach (var item in _equipment.SaverInventory.CurrentSaveableSlotOfCharacter.CurrentItemNames)
      {
          int pos = item.IndexOf('-');
          string name = item.Substring(0,pos);
          Debug.LogError(name + " " + _equipmnetOfCharacter.Player.Name);
          if (name == _equipmnetOfCharacter.Player.Name)
          {
            Debug.LogError("SLOOOOT!!!!!!! + " + name);
            string itemName =item.Remove(0, pos +1);
            string[] items = itemName.Split(new char[] {','});
            List<string> namesOfItems = items.ToList();
            namesOfItems.Remove(namesOfItems[0]);
            foreach (var item2 in namesOfItems)
            {
                int pos2 = item2.IndexOf('?');
               string middleNameOfItem = item2.Substring(0,pos2);
                int pos3 = item2.IndexOf('!');
                string fullName = item2.Substring(0,pos3);
                string rarityStr = middleNameOfItem.Remove(0,pos3 +1);
                Debug.LogError(rarityStr);
                int rarity  =Convert.ToInt32(rarityStr);
                string position = item2.Remove(0,pos2 +1);
                Debug.LogError(position);
                int numberOfItem = Convert.ToInt32(position);
                Debug.LogError(fullName + " Rarity: " + rarity + " " + " position: " + numberOfItem);
                List< Item> items2 =  _equipment.SaverDroppedLoot.AllTheItems.FindAll(e=> e.FullName == fullName);
                Item item1 = items2.Find(e=>(int) e.Rarity == rarity);
                _equipmnetOfCharacter.ItemSlots[numberOfItem].AddItem(item1);
            }
              
              break;
          }
      }  
    }
}
