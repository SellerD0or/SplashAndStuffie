using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class SaveableCurrentInventory 
{
  //  public SaveableCurrentInventory(Player player)
  //  {
   //     CurrentPlayer = player;
   // }
 //   public SaveableCurrentInventory(Item item)
  //  {
    //    CurrentItem = item;
   // }
  //public SaveableCurrentInventory()
  // {
       
   //}
   public Player Player;
   public Item Item ;
        public string ItemName;
     public List<string> CurrentItemNames;

    public List< Player> CurrentPlayers;//= new List<Player>();
    public List< Item> CurrentItems;// = new List<Item>();

}
