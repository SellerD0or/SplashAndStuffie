using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMessage : Dialogue
{
  [SerializeField] private SaverDroppedLoot _saverDroppedLoot;
  [SerializeField] private GameObject _person;
    [SerializeField] private ChangerOfMessages _changer;
    [SerializeField] private GameObject[] _shadows;
    [SerializeField] private GameObject _backGround;
     private Player _currentPlayer;
    [SerializeField] private string _name;
    public Player CurrentPlayer { get => _currentPlayer; set => _currentPlayer = value; }
    public string Name { get => _name; set => _name = value; }
    [SerializeField] private List<Player> _playersToSave;
      [SerializeField] private SlotOfCharacter _slotOfCharacter;
      [SerializeField] private SaverInventory _saverInventory;
    private void OnEnable() {
      _backGround.SetActive(true);
      foreach (var shadow in _shadows)
      {
          shadow.SetActive(true);
      }
      
      _person.SetActive(false);
   //   _changer.gameObject.SetActive(false);
    }
    private void Start() {
     
    }
    public void Save(Player player)
    {
        CurrentPlayer = player;
        //_saverDroppedLoot.Save(new SaveableCurrentInventory() {Player = CurrentPlayer});
        SlotOfCharacter slotOfCharacter = Instantiate(_slotOfCharacter, transform.position, Quaternion.identity);
     _saverInventory.Save(new SaveableSlotOfCharacter () {PlayerName = player.Name, SlotOfCharacter =slotOfCharacter});
  //  slotOfCharacter.gameObject.SetActive(false);
     foreach (var player2 in _playersToSave)
      {
         SlotOfCharacter slotOfCharacter2 = Instantiate(_slotOfCharacter, transform.position, Quaternion.identity);
     _saverInventory.Save(new SaveableSlotOfCharacter () {PlayerName = player2.Name, SlotOfCharacter =slotOfCharacter2});
  //  slotOfCharacter2.gameObject.SetActive(false);
      }
        // Saver saver = new Saver();
      //   SaveableEducation saveableEducation = new SaveableEducation();
    //     saveableEducation.Player = player;
   //   saver.Save(saveableEducation);
    //  Debug.Log(saveableEducation.IDOfPlayer + " - during education");
    }
    public void Open() => _changer.OpenNextMessage();
    private void OnDisable() {
      _person.SetActive(true);
       _backGround.SetActive(false);
       foreach (var shadow in _shadows)
      {
          shadow.SetActive(false);
      }
     // _changer.gameObject.SetActive(true);
      
    }

  
}
