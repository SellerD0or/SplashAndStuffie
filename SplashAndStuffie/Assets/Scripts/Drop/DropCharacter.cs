using System.Net.Mime;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class DropCharacter : MonoBehaviour
{
     [SerializeField] private List<DroppedStar> _droppedStars;
    [SerializeField] private LocalizationText _playerName;
         [SerializeField] private Sprite[] _playerSpritesOfstars;
    [SerializeField] private GameObject[] _playerStars;
    [SerializeField] private List<GettingCharacterBoard> _boards;
     [SerializeField] private Sprite[] _spritesOfstars;
    [SerializeField] private GameObject[] _stars;
    [SerializeField] private LocalizationText _localizationItemText;
    [SerializeField] private LocalizationText _localizationText;
      [SerializeField] private SlotOfCharacter _slotOfCharacter;
      [SerializeField] private SaverInventory _saverInventory;
    [SerializeField] private List<Player> _allThePlayers;
  [SerializeField] private GetterTravellerPlayer _getterTravelledPlayer;
  [SerializeField] private List<Item> _items;
  [SerializeField] private List< Player> _twoStarsPlayers;
  [SerializeField] private List< Player> _threeStarsPlayers;
  private Player _createdPlayer;
 [SerializeField] private List<Item> _currentItems = new List<Item>();
  private List<Item> _gotItems = new List<Item>();
 [SerializeField] private List<GameObject> _wishMovements;
 [SerializeField] private SaverDroppedLoot _saverDroppedLoots;
  private SaveableEducation _saveableEducation;
  private Player _loadedPlayer;
  [SerializeField] private Saver _saver;
  [SerializeField] private CreatorSlotOfCharacter _creatorSlotOfCharacter;
          private   List<Player> _oneStarCharacters = new List<Player>();
          private   List<Player> _threeStarCharacters = new List<Player>();
          private   List<Player> _twoStarCharacters = new List<Player>();
          private   List<Player> _fourStarCharacters = new List<Player>();
     private   List<Player> _fiveStarCharacters = new List<Player>();
    [SerializeField] private List<Player> _selectedPlayers = new List<Player>();
    private float _playerProcent;
    private List<Player> _currentPlayers  = new List<Player>();
    private List<int> _currentRarities = new List<int>();
     bool _oneStar = false;
     bool _twoStar = false;
     bool _threeStar = false;
    private bool _isTwoStarCharacter = false;
    private bool _isThreeStarCharacter = false;
    private bool _isFourStarCharacter = false;
    private List<Player> _playersForDrop =new List<Player>();
  private List<TupleItemDropingChances> _tupleItemDropingChances = new List<TupleItemDropingChances> () {new TupleItemDropingChances(0, 98), new TupleItemDropingChances(98, 99), new TupleItemDropingChances(99, 100)};
  private void Start() {
      Loader loader = new Loader();
         _saveableEducation =  loader.Load();
        if(! _saveableEducation.IsCreated)
        {
            _loadedPlayer = _saveableEducation.Player;
            _saver.Save(new SaveableEducation() {Player =_loadedPlayer,IsCreated = true, IsEducationEnd =false});
        }
          List<Player> selectedPlayers =new List<Player>();
           foreach (var item in _saverInventory.CurrentSaveableSlotOfCharacter.CurrentPlayerNames)
           {  
              selectedPlayers.Add(    _saverInventory.AllPlayer.Find(e=> e.Name == item ));
           }
        foreach (var item in selectedPlayers)
        {
            if (item != null)
            {
                _selectedPlayers.Add(item);
            }
        }
//      _gotItems = _saverDroppedLoots.CurrentSaveableCurrentInventory.CurrentItems;
   Drop();  
  }
  private void Update() {
      if(Input.GetKeyDown(KeyCode.Space))
      {
          //Drop();
      }
        if(Input.GetKeyDown(KeyCode.F))
      {
         // CreateAllPlayer();
      }
  }
  private void CreateAllPlayer()
  {
      foreach (var player in _allThePlayers)
      {
          Player createdPlayer =   Instantiate(player,new Vector3(100,100,0), Quaternion.identity);
        
    //_creatorSlotOfCharacter.Create(player);
     SlotOfCharacter slotOfCharacter = Instantiate(_slotOfCharacter, transform.position, Quaternion.identity);
     _saverInventory.Save(new SaveableSlotOfCharacter () {PlayerName = player.Name, SlotOfCharacter =slotOfCharacter});
    slotOfCharacter.gameObject.SetActive(false);
    _saverDroppedLoots.Save(new SaveableCurrentInventory() {Player = player});
    createdPlayer.enabled = false;
      createdPlayer.gameObject.SetActive(false);
      }
      
  }
  public void Drop()
  {
      
        
       /* GetPlayerProcent(ref _oneStarCharacters,0,3f);
        foreach (var item in _oneStarCharacters)
        {
            Debug.Log(item + " EXIST!!!");
        }
        GetPlayerProcent(ref _twoStarCharacters,1,1.5f);
         GetPlayerProcent(ref _threeStarCharacters,2,0.5f);
        GetPlayerProcent(ref _fourStarCharacters,3,0.25f);
        GetPlayerProcent(ref _fiveStarCharacters,4,0.1f);
     float _randomAction= Random.Range(0,200 + _playerProcent);
         Debug.Log(_randomAction + " playerProcent: " + _playerProcent);

      if (_randomAction <= 200 )
      {
          DropItem();
      }
      else 
      {
          DropPlayer();
      }
      */
        List<string> names = new List<string>();
              List<Player> players = new List<Player>();
    foreach (var item in _saverInventory.AllPlayer)
    {
        if(item.Name != "Stuffie" || item.Name != "Splash")
        {
            Debug.LogError("COOOL " + item.Name);
        names.Add(item.Name);
        }
    }
    foreach (var item in _saverInventory.CurrentSaveableSlotOfCharacter.CurrentPlayerNames)
    {
            players.Add(_saverInventory.AllPlayer.Find(e=>e.Name == item));
    }
   var playersForDrop = _saverInventory.AllPlayer.ToArray().Except(players.ToArray());
   foreach (var item in playersForDrop)
   {
       if(item is Dd1 || item is Dd2)
       continue;
       else
       {
       _playersForDrop.Add(item);
       }
   }
    _twoStarCharacters = _playersForDrop.FindAll(e=>e.LevelOfPlayer == 1);
     _fourStarCharacters = _playersForDrop.FindAll(e=>e.LevelOfPlayer == 3);
    _threeStarCharacters = _playersForDrop.FindAll(e=>e.LevelOfPlayer == 2);
    _fiveStarCharacters = _playersForDrop.FindAll(e=>e.LevelOfPlayer == 4);
      int random = Random.Range(0,101);
      Debug.LogError(random);
      if (random < 60 || _playersForDrop.Count == 0)
      {
          DropItem();
      }
      else if(random >= 60 && _playersForDrop.Count > 0)
      {
          DropPlayer();
      }
  }
  private void GetPlayerProcent(ref List<Player> players, int level, float additionPercent)
  {
      players = _allThePlayers.FindAll(e=> e.LevelOfPlayer == level);
      List<Player> resultPlayers = new List<Player>();
      foreach (var item in players)
      {
          resultPlayers.Add(item);    
      }
       if (players.Count > 0)
        {
             foreach (var player in resultPlayers)
      {
          if (_selectedPlayers.Contains(player))
          {
            //  Debug.Log(player);
              players.Remove(player);
          }
          if (!_currentRarities.Contains(player.LevelOfPlayer))
         {
            _currentRarities.Add(player.LevelOfPlayer);
        }
      }
      players.ForEach(e=>_currentPlayers.Add(e));
            _playerProcent += additionPercent;
            
        }
  }
  public void DropItem()
  {
       int random = Random.Range(0,100);
      if (random >= 95)
      {
         DropItem();
         return;
      }
           if (random < 95)
      {
          _oneStar = true;
      }
      if (random < 75)
      {
          _twoStar = true;
      }
      if (random < 30)
      {
          _threeStar = true;
      }
        DroppingItem();
 
   
  
    // _items.Remove(item);
  }
  private void SetRandomNumber(ref int random)
  {
     
        random = Random.Range(0,100);
         Debug.Log("new cool number:" + random);
        if (random >= 95)
        {
            SetRandomNumber(ref random);
        }
             
  }
  private void DroppingItem()
  {
         int random2 = Random.Range(0,3);
      Debug.Log(random2);
    if (random2 == 0 && _oneStar)
     {
      _currentItems =_items.FindAll(e => e.Rarity == ArtifactRarity.Common);
      _wishMovements[0].SetActive(true);
      CreateItem();
      return;
     }
      else if(random2 == 1 && _twoStar )
   {
        Debug.LogError("coool");
           _currentItems =_items.FindAll(e => e.Rarity == ArtifactRarity.Rare);
             _wishMovements[1].SetActive(true);
             CreateItem();
             return;
     }
      else if(random2 == 2 && _threeStar )
     {
           _currentItems =_items.FindAll(e => e.Rarity == ArtifactRarity.Epic);
              _wishMovements[2].SetActive(true);
              CreateItem();
              return;
     }
     else
     {
         DroppingItem();
     }
  }
  public void DroppingPlayer()
  {
     int random2 = Random.Range(0,3);
//      Debug.Log(random2);
    if (random2 == 0 && _isTwoStarCharacter)
     {
         int randomPlayer = Random.Range(0,_twoStarCharacters.Count);
          CreateCharacter(_twoStarCharacters[randomPlayer]);
                    _boards[0].gameObject.SetActive(true);

      _wishMovements[4].SetActive(true);
      return;
     }
      else if(random2 == 1 && _isThreeStarCharacter )
   {
       int randomPlayer = Random.Range(0,_threeStarCharacters.Count);
          CreateCharacter(_threeStarCharacters[randomPlayer]);
          _boards[1].gameObject.SetActive(true);

            _wishMovements[5].SetActive(true);
             return;
     }
      else if(random2 == 2 && _isFourStarCharacter )
     {
         int randomPlayer = Random.Range(0,_fourStarCharacters.Count);
          CreateCharacter(_fourStarCharacters[randomPlayer]);
                    _boards[2].gameObject.SetActive(true);

           _wishMovements[5].SetActive(true);
              return;
     }
     else
     {
         DroppingPlayer();
     }
  }
  private void CreateItem()
  {
        int _random =  Random.Range(0, _currentItems.Count);
        Item item = Instantiate(_currentItems[_random],new Vector3(-3,0,0), Quaternion.identity);
        _localizationItemText.gameObject.SetActive(true);
        _localizationItemText.Key = item.FullName;
        _localizationItemText.Display();
      //   for (int i = 0; i < (int) item.Rarity +1; i++)
    //   {
     //      _stars[i].gameObject.SetActive(true);
     //  }
      // Sprite sprite = (int) item.Rarity == 2 ? _spritesOfstars[1] :_spritesOfstars[0] ;
     //  for (int i = 0; i < _stars.Length; i++)
     //   {
        //   _stars[i].GetComponent<Image>().sprite = sprite;

      //  }
          CreateDroppedStar((int)_currentItems[_random].Rarity,TypeOfDroppedStar.Item);
         // if (_gotItems.Contains(_currentItems[_random]) && _gotItems.Except(_currentItems) != null)
     // {
     //    CreateItem();
    //     return;
     // }
    // Item item = Instantiate(_currentItems[_random],transform.position, Quaternion.identity);
//      _saverDroppedLoots.SaveableCurrentInventory.CurrentItems.Add(item);
    _saverDroppedLoots.Save(new SaveableCurrentInventory {ItemName = _currentItems[_random].FullName + "," + (int)_currentItems[_random].Rarity});
     // int _random = Random.Range(0, _currentItems.Count);
    //  if (_gotItems.Contains(_currentItems[_random]))
     // {
      //    CreateItem();
    //  }
     //  Item item = Instantiate(_currentItems[_random],transform.position, Quaternion.identity);
      // _gotItems.Add(item);

  }
  private void CreateDroppedStar(int length,TypeOfDroppedStar typeOfDroppedStar)
  {
      Debug.LogError(length);
      Vector3 position = new Vector3(4.67f,0.25f,1);
      if (length == 0)
      {
          position.x = 5.85f;
      }
     else  if(length == 1)
      {
          position.x = 5.27f;
      }
      else if (length == 2)
      {
         position.x = 5.56f;
      }
      if(typeOfDroppedStar == TypeOfDroppedStar.TwoStars)
      {
          position.x = 6.11f;
      }
      DroppedStar droppedStar = Instantiate(_droppedStars.Find(e=> e.TypeOfDroppedStar == typeOfDroppedStar),position,Quaternion.identity); 
        droppedStar.SetParticleSystems(length);   
  }
  
  public void DropPlayer()
  {
   
    int chance = 0;
    int randomCharacter =Random.Range(0,_playersForDrop.Count);
    int allRandom = Random.Range(1,101);
    if (_playersForDrop[randomCharacter].LevelOfPlayer == 1 && _twoStarCharacters.Count >0)
    {
      chance = 50;  
    } 
    else if (_playersForDrop[randomCharacter].LevelOfPlayer == 2 && _threeStarCharacters.Count >0)
    {
      chance = 80;  
    } 
     else if (_playersForDrop[randomCharacter].LevelOfPlayer == 3 && _fourStarCharacters.Count >0)
    {
      chance = 95;  
    } 
    if (allRandom >= chance)
    {
           CreateCharacter(_playersForDrop[randomCharacter]);
    }
    else
    {
        DropPlayer();
    }
   /*   float random = Random.Range(0,100);
    Debug.Log(random);
      if (random > 3)
      {
         DropPlayer();
         return;
      }
      if (random < 1.5f && _twoStarCharacters.Count> 0)
      {
          _isTwoStarCharacter = true;
           
      }
      if (random < 0.5f  && _threeStarCharacters.Count> 0)
      {
          _isThreeStarCharacter = true;
      
      }
         if (random < 0.25f  && _fourStarCharacters.Count> 0)
      {
          _isFourStarCharacter = true;
        

      }
      DroppingPlayer();*/
  }

  public void DropSpetionCharacter<T, U>(T firstPlayer,U senondPlayer ) where T: Player where U : Player
  {
       int _randomPlayer = Random.Range(0,100);
       if (_randomPlayer < 60)
       {
           CreateCharacter(_getterTravelledPlayer.Player);
       }
       else if(_randomPlayer > 61 && _randomPlayer < 80)
       {
           CreateCharacter(firstPlayer);
       }
       else
       {
           CreateCharacter(senondPlayer);
       }
  }
  
  public void DropSimpleCharacter()
  {
       int randomThreeStarsCharacter = Random.Range(0,_threeStarsPlayers.Count);
      CreateCharacter(_threeStarsPlayers[randomThreeStarsCharacter]);
  }
  private void CreateCharacter(Player player) 
  {
    Player createdPlayer =   Instantiate(player,new Vector3(-4,0,0), Quaternion.identity);
    createdPlayer.IPlayerAnimator.AudioClips = null;
    if (player.LevelOfPlayer == 1)
     {
     _boards[0].gameObject.SetActive(true);
       CreateDroppedStar(player.LevelOfPlayer,TypeOfDroppedStar.TwoStars);
      _wishMovements[3].SetActive(true);
     }
      else if(player.LevelOfPlayer == 2 )
   {
          _boards[1].gameObject.SetActive(true);
        CreateDroppedStar(player.LevelOfPlayer,TypeOfDroppedStar.ThreeStars);
            _wishMovements[4].SetActive(true);
     }
      else if(player.LevelOfPlayer == 3)
     {
         _boards[2].gameObject.SetActive(true);
                CreateDroppedStar(player.LevelOfPlayer,TypeOfDroppedStar.FourStars);

           _wishMovements[4].SetActive(true);
     }
    _createdPlayer = createdPlayer;
    _localizationText.gameObject.SetActive(true);
    _localizationText.Key = createdPlayer.Description;
    _localizationText.Display();
        _playerName.gameObject.SetActive(true);
    _playerName.Key = createdPlayer.Name;
    _playerName.Display();

    /* for (int i = 0; i < createdPlayer.LevelOfPlayer +1; i++)
       {
           _playerStars[i].gameObject.SetActive(true);
       }
       for (int i = 0; i < _playerStars.Length; i++)
        {
           _playerStars[i].GetComponent<Image>().sprite = _playerSpritesOfstars[createdPlayer.LevelOfPlayer];

        }*/ 
     if (_createdPlayer is Axel)
      {
          createdPlayer.transform.position = new Vector3(createdPlayer.transform.position.x,-4.21f, createdPlayer.transform.position.z);
      }
       if (_createdPlayer is Bomber)
      {
          createdPlayer.transform.position = new Vector3(createdPlayer.transform.position.x,  -0.59f, createdPlayer.transform.position.z);
      }
    
    //_creatorSlotOfCharacter.Create(player);
     SlotOfCharacter slotOfCharacter = Instantiate(_slotOfCharacter, transform.position, Quaternion.identity);
     _saverInventory.Save(new SaveableSlotOfCharacter () {PlayerName = player.Name, SlotOfCharacter =slotOfCharacter});
    slotOfCharacter.gameObject.SetActive(false);
    _saverDroppedLoots.Save(new SaveableCurrentInventory() {Player = player});
    createdPlayer.enabled = false;
}
}
public struct TupleItemDropingChances
{
    public TupleItemDropingChances(int minChance, int maxChance)
    {
        MinChance = minChance;
        MaxChance = maxChance;
    }
 public int MinChance { get; set; }
 public int MaxChance { get; set; }
}