using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LoaderSaveableSlotOfCharacter : MonoBehaviour
{
   [SerializeField] private CreatorAdderCharacter _creatorAdderCharacter;
  [SerializeField] private SaverInventory _saverInventory;
     [SerializeField] private Transform _spawnPosition;
     [SerializeField] private SlotOfCharacter _slotOfCharacter;

    public CreatorAdderCharacter CreatorAdderCharacter { get => _creatorAdderCharacter; set => _creatorAdderCharacter = value; }
    public int NumberOfSelectedCharacter { get => _numberOfSelectedCharacter; set => _numberOfSelectedCharacter = value; }
    public List<Player> CurrentPlayers { get => _currentPlayers; set => _currentPlayers = value; }

    private List<Player> _currentPlayers = new List<Player>();
    private List<SelectablePlayer> _selectablePlayers =new List<SelectablePlayer>();
    private int _numberOfSelectedCharacter;
    [SerializeField] private float _timeForRemovingEscape = 5f;
    private bool _isEscapeRemoved;
    private Settings _settings;
    private Player _currentPlayer;   
   private SelectCharacterInterface _selectCharacterInterface; 
        [SerializeField] private List<GameObject> _appearedBackgrounds;
private Dictionary<string, GameObject> _currentBackgrounds = new Dictionary<string, GameObject>() {};
    private void Start()
    {
      _selectCharacterInterface = FindObjectOfType<SelectCharacterInterface>();
      for (int i = 0; i < _saverInventory.AllPlayer.Count; i++)
      {
        _currentBackgrounds.Add(_saverInventory.AllPlayer[i].Name,_appearedBackgrounds[i]);
      }
      _settings = FindObjectOfType<Settings>();
     CreateStartedSlotOfPlayer("Splash");
     CreateStartedSlotOfPlayer("Stuffie");
     foreach (var player in _saverInventory.AllPlayer)
     {
       if (player.Name == "Splash" || player.Name == "Stuffie")
       {
         continue;
       }
       if (_saverInventory.CurrentSaveableSlotOfCharacter.CurrentPlayerNames.Contains(player.Name))
       {
         CreateSlotOfPlayer(player.Name,true);
       }
       else
       {
         CreateSlotOfPlayer(player.Name,false);
       }
     }
     _creatorAdderCharacter.Find();   
    }
    private void CreateStartedSlotOfPlayer(string nameOfCharacter)
    {
      string player ="";
      player = _saverInventory.CurrentSaveableSlotOfCharacter.CurrentPlayerNames.Find(e=> e == nameOfCharacter);
      if (player == null)
      {
        return;
      }
    else if (player != "")
     {
       CreateSlotOfPlayer(player,true);
     }
    }
    public void ChooseCurrentCharacter(Player player)
    {
      _currentPlayer =player;
      _selectCharacterInterface.SetPlayer(player);
       
    }
    private void CreateSlotOfPlayer(string player,bool isAvailable)
    {
        SlotOfCharacter slotOfCharacter = Instantiate(_slotOfCharacter, transform.position, Quaternion.identity);
            slotOfCharacter.Player = _saverInventory.AllPlayer.Find(e=> e.Name == player);
           slotOfCharacter.gameObject.transform.SetParent(_spawnPosition,false);
         SelectablePlayer selectablePlayer =  slotOfCharacter.GetComponent<SelectablePlayer>();
          selectablePlayer.NumberOfSelectedCharacter.Loader = this;
         selectablePlayer.CreateSlot(slotOfCharacter.Player,isAvailable);
         _selectablePlayers.Add(selectablePlayer);
    }
    public void TurnOffAppearedBackgrouds()
    {
      foreach (var item in _appearedBackgrounds)
      {
        item.SetActive(false);
      }
    }
    private void Update() {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
         if (_isEscapeRemoved == false)
         {
        List<SelectablePlayer> selectablePlayers = _selectablePlayers.FindAll(e=>e.IsSelected == true);
           _isEscapeRemoved = true;
           if(_currentPlayer != null)
           {
         GameObject appearedBackground = GetAppearedBackground(_currentPlayer);
         appearedBackground.SetActive(false);
           }
           foreach (var selectablePlayer in selectablePlayers)
           {
             selectablePlayer.RemoveClick();
           }
           _selectCharacterInterface.RemovePlayer();
           Invoke(nameof(Reload),_timeForRemovingEscape);
         }
         else
         {
          _settings.LoadLobby();
         }
      }
    }
    public GameObject GetAppearedBackground(Player player)
    {
      return _currentBackgrounds[player.Name];
    }
    private void Reload()=> _isEscapeRemoved = false;
 
}
