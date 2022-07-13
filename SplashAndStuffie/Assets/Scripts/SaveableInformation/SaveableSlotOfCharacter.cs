using System;
using System.Collections.Generic;

[Serializable]
public class SaveableSlotOfCharacter 
{
    public string ItemName;
    public EquipmentOfCharacter EquipmentOfCharacter;
    public string PlayerName;
     public List<string> CurrentPlayerNames;

    public Player Player;
    public SlotOfCharacter SlotOfCharacter;
    public List< Player> CurrentPlayers;
    public List<SlotOfCharacter> CurrentSlotsOfCharacters; //= new List<SlotOfCharacter>();
    public List<EquipmentOfCharacter> CurrentEquipmentOfCharacters;
    public List<string> CurrentItemNames; 
}
