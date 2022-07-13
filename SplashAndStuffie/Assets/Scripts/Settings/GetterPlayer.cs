using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
public class GetterPlayer : MonoBehaviour
{
   [SerializeField] private OutlineOfAbility _outlineOfAbility;
   private List<OutlineOfAbility> _currentOutlineOfAbilities =new List<OutlineOfAbility>();
   private List<PlayerInterfaceSkill> _currentSkills = new List<PlayerInterfaceSkill>();
   [SerializeField] private Transform _abilityPosition;
   [SerializeField] private PlayerInterfaceSkill _skill;
   [SerializeField] private Transform _skillPosition;
   [SerializeField] private PlayerInterface _playerInterface;
   private int _countOfHealths;
   
   [SerializeField] private HealthOutput _healthOutput;
  [SerializeField] private List<HealthOutput> _healthsOutputs =new List<HealthOutput>();
   [SerializeField] private Transform _spawnPosition;
  private List<Player> _players = new List<Player>();
   [SerializeField] private TakerDamageVisitor _takerDamageVisitor;
    private SaveableEducation _saveableEducation;
    private Player _currentPlayer;
    private Player _createdPlayer;
    public Player CreatedPlayer { get => _createdPlayer; set => _createdPlayer = value; }
    public Player LoadedPlayer { get => _loadedPlayer; set => _loadedPlayer = value; }
    [SerializeField] private SelecterCharacter _selecterCharacter;
    public event UnityAction OnDestroy;
    private Player _loadedPlayer;
   [SerializeField] private bool _firstCreating = true;
   private Player _firstPlayer;
      public List<Player> Players { get => _players ; set=> _players =value ; }
    public List<HealthOutput> HealthsOutputs { get => _healthsOutputs; set => _healthsOutputs = value; }
    public List<BoardOfReloadingAbility> CurrentBoards { get => _currentBoards; set => _currentBoards = value; }
    public List<OutlineOfAbility> CurrentOutlineOfAbilities { get => _currentOutlineOfAbilities; set => _currentOutlineOfAbilities = value; }

    [SerializeField] private LoaderCharacter _loader;
    private int _countOfPlayer = 0;
    private bool _isFirstTimeForCreating;
    [SerializeField] private BoardOfReloadingAbility _board;
    [SerializeField] private Transform _boardPosition;
    [SerializeField] private Transform _characterBoardPosition;
    private PlayerBotZBoard _currentBotZBoard;
    private List<BoardOfReloadingAbility> _currentBoards = new List<BoardOfReloadingAbility>();
    [SerializeField] private CanvasGroup _ultimateInterface;
    private void Awake() {
       LoadCharacter();
       
   }
   private void Start() {
     // CreatePlayer();
      OnDestroy?.Invoke();
      
   }
   private void LoadCharacter()
   {
       Loader loader = new Loader();
         _saveableEducation =  loader.Load();
         LoadedPlayer = _saveableEducation.Player;
        _currentPlayer =  _saveableEducation.Player;
   }
   private void CreatePlayer()
   {
      Player player = (Player) Instantiate(_currentPlayer, transform.position, Quaternion.identity);
      CreatedPlayer = player;
      CreatedPlayer.TakerDamageVisitor = _takerDamageVisitor;
   }
   public void ChooseBaseCharacter()
   {
      //SetPlayer(LoadedPlayer);
     // CreateCharacter(LoadedPlayer);
   }
   public void ChangeCurrentCharacter(Player player,ChangerOfPlayer changerOfPlayer)// bool _isNormal)
   {
      Debug.Log(changerOfPlayer.IsChoosen + " ok you can go there!");
      if(_countOfHealths <= 2)
      SetPlayer(player,false);
      else
      {
         if (!_isFirstTimeForCreating)
         {
           // ChangePlayers();
             _isFirstTimeForCreating = true;
         }
         CreateCharacter(player,false);
      }
      //CreatePlayer(player, changerOfPlayer);
     // SetPlayer(player, _isNormal);
     //CreateCharacter(player);

   }
   private void CreateCharacter(Player player, bool _isNormal)
   {
     Player _selectablePlayer = player;
        _selecterCharacter.CurrentPlayer = CreatedPlayer;
        Vector2 lastPlayerPosition;
        if(!_firstCreating)
        {
              if (player.Name == "Axel")
     {
        Debug.Log(CreatedPlayer.transform.position + " BEFORE");
       lastPlayerPosition = CreatedPlayer.transform.position + new Vector3(0,-4.55f,0);
        Debug.Log(lastPlayerPosition + " nameof plauyyers is " + player);
     }
     else if (player.Name == "Tao")
     {
         lastPlayerPosition = CreatedPlayer.transform.position + new Vector3(0,-0.7f,0);
         if (CreatedPlayer.transform.position.y - 0.7f > -2.503057)
         {
            lastPlayerPosition.y = -2.5f;
         }
     }
     else
     {
         lastPlayerPosition = CreatedPlayer.transform.position;
     }
     if (lastPlayerPosition.y < -9.38f)
     {
        lastPlayerPosition.y = -9.38f;
        Debug.LogError("MOVE BY POWER!!!");
     }
      CreatedPlayer.gameObject.SetActive(false);
    
        }
        else
        {
           lastPlayerPosition = new Vector2(0,0);
        }
        if (_isNormal)
        {
           

            //player.name = player.name + _countOfPlayer;
        }

     // if (!_selecterCharacter.AllPlayers.ContainsKey(player.name) || _isNormal)
    //  {
        // Player createdPlayer = (Player) Instantiate(_selectablePlayer, lastPlayerPosition, Quaternion.identity);
        
       //  createdPlayer.enabled = true;
       //  Debug.Log(createdPlayer + "Aften find is ok");

         // createdPlayer.name = createdPlayer.name + _countOfPlayer;
        // _countOfPlayer++;
         // _selecterCharacter.AllPlayers.Add(player.name, createdPlayer);
        //  _players.Add(createdPlayer);
    // }
     foreach (var item in _selecterCharacter.AllPlayers)
     {
         Debug.Log(item.Key);
     }
     Debug.Log(player.name + "last checking");
     Player foundPlayer= _selecterCharacter.AllPlayers[player.name];
     foreach (var item in CurrentBoards)
     {
        item.CanvasGroup.alpha = 0;
       // item.SetPosition(HealthsOutputs.Find(e=>e.StartedPlayer.Name == item.Player.Name),_playerInterface);
     }
      foreach (var item in _currentSkills)
     {
        item.CanvasGroup.blocksRaycasts = false;
        item.CanvasGroup.alpha = 0;
     }
     foreach (var item in _currentOutlineOfAbilities)
     {
        item.CanvasGroup.alpha =0;
     }
      PlayerInterfaceSkill skill = _currentSkills.Find(e => e.Player.Name == foundPlayer.Name);
     skill.CanvasGroup.blocksRaycasts = true;
     skill.CanvasGroup.alpha = 1;
     OutlineOfAbility outlineOfAbility = _currentOutlineOfAbilities.Find(e=> e.Player.Name == foundPlayer.Name);
     outlineOfAbility.CanvasGroup.alpha =1;
     _ultimateInterface.alpha = 0;
     if(_countOfHealths > 2)
     {
     BoardOfReloadingAbility board = CurrentBoards.Find(e => e.Player.Name == foundPlayer.Name);
     if(board != null)
     {
     board.CanvasGroup.alpha = 1;
     _ultimateInterface.alpha = 1;
     }
     //board.SetNormalPosition(_playerInterface.SpetialPosition,HealthsOutputs.Find(e=> e.StartedPlayer == foundPlayer), _playerInterface);
     }
     //board.CanvasGroup.alpha = 1;
     foundPlayer.gameObject.SetActive(true);
     foundPlayer.transform.position = lastPlayerPosition;
       CreatedPlayer = foundPlayer; 
       if(_firstCreating)
       {
          CreatedPlayer.gameObject.SetActive(false);
       _firstCreating = false;
       }
        OnDestroy?.Invoke();
      
       if(_countOfHealths <= 2)
       {
       HealthsOutputs[_countOfHealths].StartedPlayer =CreatedPlayer;
       HealthsOutputs[_countOfHealths].GetPlayer();
       _countOfHealths++;
       }    
        if(_countOfHealths > 2)
       {
          foreach (var item in HealthsOutputs)
          {
             item.SetDefaltPosition(item);
          }
        HealthOutput healthOutput =  HealthsOutputs.Find(e=> e.StartedPlayer == CreatedPlayer);
        healthOutput.SetCurrentHealth(healthOutput);
       }
   }
   public void CreatePlayer(Player player,  ChangerOfPlayer changerOfPlayer)
   {
      _selecterCharacter.CurrentPlayer = CreatedPlayer;
        Vector2 lastPlayerPosition;
            if(!_firstCreating)
        {

           lastPlayerPosition = CreatedPlayer.transform.position;
           Debug.Log(CreatedPlayer.name + " Plsdoasd: " +lastPlayerPosition);
      CreatedPlayer.gameObject.SetActive(false);
      
        }
        else
        {
          
           lastPlayerPosition = new Vector2(0,0);
           _firstCreating = false;
          // _firstCreating = false;
        }
        CreatedPlayer = player;
      if (!changerOfPlayer.IsChoosen)
      {
       //  lastPlayerPosition = new Vector2(0,0);
         Player createdPlayer = (Player) Instantiate(player, lastPlayerPosition, Quaternion.identity);
         createdPlayer.enabled = true;
         changerOfPlayer.IsChoosen = true;
      }
    //  else
    //  {
         //  lastPlayerPosition = CreatedPlayer.transform.position;
    //  CreatedPlayer.gameObject.SetActive(false);
    //  }
     //CreatedPlayer.gameObject.SetActive(true);
     player.transform.position = lastPlayerPosition;
     Debug.Log(player.Name);
     if (player.Name == "Axel")
     {
        player.transform.position = lastPlayerPosition + new Vector2(0,-1.7f);
        Debug.Log(player.transform.position + " nameof plauyyers is " + player);
     }
       CreatedPlayer = player; 
       if(!_firstCreating)
       {
      //    CreatedPlayer.gameObject.SetActive(false);
      //_firstPlayer = CreatedPlayer;
    //   _firstCreating = false;
      }
      if (_firstCreating)
      {
          
      }
       OnDestroy?.Invoke();
            if(_countOfHealths <= 2)
       {
       HealthsOutputs[_countOfHealths].StartedPlayer =CreatedPlayer;
       HealthsOutputs[_countOfHealths].GetPlayer();
       _countOfHealths++;
       }    
   }
   private void ChangePlayers()
   {
      for (int i = 0; i < _countOfHealths; i++)
      {
         _selecterCharacter.ChangerOfPlayers[i].Player = _selecterCharacter.CurrentCharacters[i];
         Debug.LogError(_selecterCharacter.ChangerOfPlayers[i].Player + "THANK YOU A LOT!");
        // _selecterCharacter.CurrentCharacters[i].name = _selecterCharacter.ChangerOfPlayers[i].Player.name + i;
       _selecterCharacter.AllPlayers.Add(_selecterCharacter.CurrentCharacters[i].name ,_selecterCharacter.CurrentCharacters[i]);

      }
   }
   private void SetPlayer(Player player, bool _isNormal)
   {
     // Player _loadedPlayer = _loader.CurrentSaveableSelectOfCharacter.CurrentPlayers.Find(e => e == player);
        Player _selectablePlayer = player;// _selecterCharacter.AllTheCharacters.Find(e => e.Name == player.Name);
      //  Debug.Log(_selectablePlayer + " Aften find");
        _selecterCharacter.CurrentPlayer = CreatedPlayer;
        Vector2 lastPlayerPosition;
        if(!_firstCreating)
        {
           lastPlayerPosition = CreatedPlayer.transform.position;
      CreatedPlayer.gameObject.SetActive(false);
        }
        else
        {
           lastPlayerPosition = new Vector2(0,0);
        }
        Debug.Log(player.Name + " AXELLL!!");
    
       
      //Destroy(CreatedPlayer.gameObject);
   //   CreatedPlayer = _selectablePlayer;
   //   if (!Players.All(x => _loader.CurrentSaveableSelectOfCharacter.CurrentPlayers.Contains(x)))
    //  {
     //     Player createdPlayer = (Player) Instantiate(_selectablePlayer, lastPlayerPosition, Quaternion.identity);
  //       createdPlayer.enabled = true;
     //    Debug.Log(createdPlayer + "Aften find is ok");
    //      _selecterCharacter.CurrentPlayers.Add(_selectablePlayer, createdPlayer);
    //      _players.Add(createdPlayer);
      //}
      
      //if (!_selecterCharacter.CurrentPlayers.ContainsKey(_selectablePlayer) || _isNormal)
     // {
         Player createdPlayer = (Player) Instantiate(_selectablePlayer, lastPlayerPosition, Quaternion.identity);
         createdPlayer.enabled = true;
        /* if (createdPlayer is BotZ)
         {
            _currentBotZBoard = Instantiate(_botzBoard,_characterBoardPosition.position,Quaternion.identity);
            _currentBotZBoard.transform.SetParent(_characterBoardPosition,false);
            _currentBotZBoard.CanvasGroup.alpha = 0;
            _currentBotZBoard.CanvasGroup.blocksRaycasts = false;

         }*/
         PlayerInterfaceSkill skill = Instantiate(_skill,new Vector3(0,0,0),Quaternion.identity);
         OutlineOfAbility outlineOfAbility = Instantiate(_outlineOfAbility,new Vector3(0,0,0),Quaternion.identity);
         skill.GetPlayer(createdPlayer);
         skill.transform.SetParent(_skillPosition,false);
         outlineOfAbility.transform.SetParent(_abilityPosition,false);

         skill.CanvasGroup.alpha = 0;
         skill.CanvasGroup.blocksRaycasts = false;
         outlineOfAbility.GetPlayer(createdPlayer);
         outlineOfAbility.CanvasGroup.alpha = 0;
         outlineOfAbility.CanvasGroup.blocksRaycasts = false;
         if (createdPlayer.Name == "Stuffie")
         {
            skill.IsDd2Skill = true;
         }
         _currentOutlineOfAbilities.Add(outlineOfAbility);
         _currentSkills.Add(skill);
         if(createdPlayer.LevelOfPlayer >= 3)
         {
          if(createdPlayer.Ultimate != null)
          {
         BoardOfReloadingAbility board = Instantiate(_board, _boardPosition.position, Quaternion.identity);
         board.Player= createdPlayer;
         board.transform.SetParent(_boardPosition,false);
      //   board.CanvasGroup.alpha = 0;
        // board.CanvasGroup.blocksRaycasts = false;
         CurrentBoards.Add(board);
          }
         }
         createdPlayer.PlayerHealth. MaxHealth =createdPlayer.PlayerHealth.Health;
         Debug.Log(createdPlayer + "Aften find is ok");
         // _selecterCharacter.CurrentPlayers.Add(_selectablePlayer, createdPlayer);
          createdPlayer.name = createdPlayer.name + _countOfHealths;
          Debug.LogError(createdPlayer.name + " you are the best!");
          _players.Add(createdPlayer);
          _selecterCharacter.CurrentCharacters.Add(createdPlayer);
          createdPlayer.PlayerHealth.SelecterCharacter = _selecterCharacter;
       //   if (_players.Count >= 2)
          
             Debug.Log("yeysyys");
             // _players[2].gameObject.SetActive(false);
          
     //}
     
     Player foundPlayer=createdPlayer;// _selecterCharacter.CurrentPlayers[_selectablePlayer];
     foundPlayer.gameObject.SetActive(true);
     foundPlayer.transform.position = lastPlayerPosition;
       CreatedPlayer = foundPlayer; 
       if(_firstCreating)
       {
          CreatedPlayer.gameObject.SetActive(false);
       //_firstPlayer = CreatedPlayer;
       _firstCreating = false;
       }
        OnDestroy?.Invoke();
       if(_countOfHealths > HealthsOutputs.Count)
       {
          /*
         HealthOutput healthOutput = Instantiate(_healthOutput,transform.position,Quaternion.identity);
         healthOutput.transform.SetParent(_spawnPosition,false);
         healthOutput.StartedPlayer = CreatedPlayer;
         healthOutput.GetPlayer();
         _healthsOutputs.Add(healthOutput);
         _countOfHealths++;
         */
       }
       if(_countOfHealths <= 2)
       {
          
//       _playerInterface.PlayerAbilityInterfaces[_countOfHealths].Player = CreatedPlayer;
       HealthsOutputs[_countOfHealths].StartedPlayer =CreatedPlayer;
       HealthsOutputs[_countOfHealths].GetPlayer();
       _countOfHealths++;
       }
       if (_countOfHealths == 3)
       {
          if(CurrentBoards.Count > 0)
          {
         CurrentBoards[0].CanvasGroup.alpha = 1;
          _ultimateInterface.alpha = 1;
          }
            ChangePlayers();
            foreach (var item in HealthsOutputs)
          {
             item.SetDefaltPosition(item);
          }
         _currentSkills[2].CanvasGroup.alpha = 1;
         _currentOutlineOfAbilities[2].CanvasGroup.alpha = 1;
        HealthOutput healthOutput =  HealthsOutputs.Find(e=> e== HealthsOutputs[2]);
        healthOutput.SetCurrentHealth(healthOutput);
        Debug.LogError(CurrentBoards.Count + " COUNT OF BOARDS");
        if(CurrentBoards.Count > 0)
        {
          // BoardOfReloadingAbility board = CurrentBoards.Find(e => e.Player.Name == Players[2].Name);
     //if(board != null)
    // {
     //board.CanvasGroup.alpha = 1;
    
    // }
        }
       
       }    
   }
   //var allInCollection = src.All(x => valid.Contains(x));
 //  var a = new List<int>() {1,2,5};
//var b = new List<int>() {1,3};
//var c = b.Except(a);
//if (c.Any()){ //then it is wrong, some items of b is not in a
//}
   //sourceCollection.All(num => validDataCollection.Contains(num))
}
