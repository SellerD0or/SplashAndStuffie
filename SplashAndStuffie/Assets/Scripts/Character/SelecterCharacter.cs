using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class SelecterCharacter : MonoBehaviour
{
  public event UnityAction<int> OnSelect;
  public int MyProperty { get; set; }
   [SerializeField] private List<Player> _players;
   public Player CurrentPlayer{get;set;}
   private Dictionary<string, Player> _allPlayers = new Dictionary<string, Player>();
    public List<Player> CurrentCharacters { get => _currentCharacters; set => _currentCharacters = value; }
    public Dictionary<string, Player> AllPlayers { get => _allPlayers; set => _allPlayers = value; }
    public List<ChangerOfPlayer> ChangerOfPlayers { get => _changerOfPlayers; set => _changerOfPlayers = value; }

    private bool _isCoolDown;
    [SerializeField] private List<ChangerOfPlayer> _changerOfPlayers = new List<ChangerOfPlayer>();
    [SerializeField] private LoaderCharacter _loaderCharacter;
    [SerializeField] private List<ChangerOfSelectedCharacter> _changerOfSelectedCharacters;
  [SerializeField] private List<Player> _currentCharacters = new List<Player>();
   [SerializeField] private Player _creatingPlayer;
   private static ChangerOfPlayer _lastChangerOfPlayer;
  [SerializeField] private List<int> _numbers = new List<int>();
   private int _numberOfChanger;
   [SerializeField] private CompletetedLevelScreen _completetedLevelScreen;
    private void Awake() {
      //  _loaderCharacter.OnLoad += SetCharacter;
    }
    private void Start() {
        
        
        //
        _lastChangerOfPlayer = ChangerOfPlayers[2];
        SetCharacter();
       
       // ChangeCharacter(1);
      //  ChangeCharacter(2);
     //   ChangeCharacter(3);
        
    }
    private void SetCharacter()
    {
          //if(_loaderCharacter.CurrentSaveableSelectOfCharacter.CurrentPlayers == null)
     // {
      //  _loaderCharacter.Destroy();
    // }
    /// _loaderCharacter.CurrentSaveableSelectOfCharacter.CurrentPlayers.RemoveAll(item => item == null);
     //  _loaderCharacter.SaveSaveableCurrentInventory(_loaderCharacter.CurrentSaveableSelectOfCharacter);
        _players = _loaderCharacter.CurrentSaveableSelectOfCharacter.CurrentPlayers;
       // _players.ForEach(e => Debug.Log(e + " I LOVE YOU!" + e.Name));
//        _loaderCharacter.CurrentSaveableSelectOfCharacter.CurrentPlayers.ForEach(e=> Debug.Log(e.Name + " save player"));
      //  foreach (var item in _players)
      //  {
  //         Player player = Instantiate(_creatingPlayer);
     //      player.enabled = false;
  //         player.gameObject.AddComponent(item.GetType());
     //      player.gameObject.AddComponent(item.IPlayerMovement.GetType());
      //  }
        for (int i = 0; i < _changerOfSelectedCharacters.Count; i++)
        {
            Debug.Log("co "  + i +  " YAYA " + _changerOfSelectedCharacters.Count);
            _changerOfSelectedCharacters[i].Player = _players[i];
           // SetFirstCharacters(i,i);
        }
        //_changerOfSelectedCharacters.ForEach(e=> e.SetFirstCharacters(1,));
       //  SetFirstCharacters(1,11);
       // SetFirstCharacters(2,22);
      //  SetFirstCharacters(3,33);
        _changerOfSelectedCharacters.ForEach(e=> e.ChangeCharacter(true));
        
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // ChangeCharacter(1);
        }
        if(!_isCoolDown)
        {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //_lastChangerOfPlayer = ChangerOfPlayers[_numberOfChanger];
            ChangeCharacter(0);
        }
        else   if (Input.GetKeyDown(KeyCode.Alpha2))
        {
           // _lastChangerOfPlayer = ChangerOfPlayers[_numberOfChanger];
            ChangeCharacter(1);
        }
        else   if (Input.GetKeyDown(KeyCode.Alpha3))
        {
          //  _lastChangerOfPlayer = ChangerOfPlayers[_numberOfChanger];
            ChangeCharacter(2);
        }
       
        }
    }
    private void SetFirstCharacters(int numberOfChanger, int smt)
    {
        Debug.Log(smt);
           ChangerOfPlayers[numberOfChanger].ChangeCharacter(false);
    }
    private void ChangeCharacter(int numberOfChanger)
    {
      
      Player player = FindObjectOfType<Player>();
      OnSelect?.Invoke(numberOfChanger);
      if(_currentCharacters[numberOfChanger].name != player.name)
      {
          Debug.Log(numberOfChanger + " have choosen: " +_currentCharacters[numberOfChanger].name +  " creating: "+ _creatingPlayer.name);
        if(!ChangerOfPlayers[numberOfChanger].Player.IsDead)
        {
        _numberOfChanger = numberOfChanger;
        ChangerOfPlayers[numberOfChanger].ChangeCharacter(false);
        StartCoroutine(CoolDown());
        }
         if (_numbers.Contains(_numberOfChanger))
         {
             _numbers.Remove(_numberOfChanger);
         } 
        _numbers.Add(_numberOfChanger);
      }
      
    }
    public void LoadLastChanger(Player player)
    {
     // CurrentPlayers.Remove(player);
       // Debug.Log("You are dead: " + _lastChangerOfPlayer);
       List<Player> deadPlayers = new List<Player>();
       deadPlayers = player.IHealthOutPut.HealthOutput.PlayerHealth.Players.FindAll(e=> e.IsDead);
       if (player.IHealthOutPut.HealthOutput.PlayerHealth.Players.All(e=> e.IsDead == true))
       {
         //gameObject.SetActive(false);
         
           _completetedLevelScreen.gameObject.SetActive(true);
            _completetedLevelScreen.Lose(player);
            return;
       }
       Debug.Log(_numbers.Count + "COUNT OF NUMBERS" + deadPlayers.Count + " COUNT OF DEAD CHARACTER!!!");
       if (deadPlayers.Count > 0 && deadPlayers.Count <2)
       {
         Player player1 = _currentCharacters.Find(e=> e.Name != player.Name);
         IsBomber(player1,player.transform.position);
         int index = _currentCharacters.IndexOf(player1);
         ChangerOfPlayers[index].ChangeCharacter(false);       
        StartCoroutine(CoolDown());
         return;
       }
       else  if (deadPlayers.Count == 2)
       {
         List<string > names = new List<string>();
          List<string > deadPlayerNames = new List<string>();
         foreach (var item in _currentCharacters)
         {
           names.Add(item.Name);
         }
         foreach (var item in deadPlayers)
         {
           deadPlayerNames.Add(item.Name);
         }
         foreach (var item in names)
         {
          if (deadPlayerNames.Contains(item) == false)
          {
            Player player2 = _currentCharacters.Find(e=> e.Name == item);
                     IsBomber(player2,player.transform.position);

         int index = _currentCharacters.IndexOf(player2);
         ChangerOfPlayers[index].ChangeCharacter(false);       
        StartCoroutine(CoolDown());
            return;
          }
         }
       }
       if(_numbers.Count == 3)
       {
         ChangerOfPlayers[_numbers[_numbers.Count - 2]].ChangeCharacter(false);
       }
       else if(_numbers.Count == 2 || _numbers.Count == 1)
       {
         if (_players[1].Name ==player.Name )
           {
             // CurrentPlayer = _players[0];
             ChangerOfPlayers[0].ChangeCharacter(false);  
           }
           else if(_players[0].Name == player.Name)
           {
                // CurrentPlayer = _players[1];
             ChangerOfPlayers[1].ChangeCharacter(false);  
           }
         /*if(deadPlayers.Count == 0)
         {
            if (_players[1].Name ==player.Name )
          {
             CurrentPlayer = _players[0];
           ChangerOfPlayers[0].ChangeCharacter(false);  
          }
           else if(_players[0].Name == player.Name)
           {
               CurrentPlayer = _players[1];
             ChangerOfPlayers[1].ChangeCharacter(false);  
           }
         }
         else if(deadPlayers.Count == 1)
         {
                        CurrentPlayer = _players[2];
           ChangerOfPlayers[2].ChangeCharacter(false);  

         }*/
          //ChangerOfPlayers[_numbers[0]].ChangeCharacter(false);
       }
       else if( _numbers.Count==0)
       {
           Debug.Log(_players[2].name +  " / "+ player.name);
            if (_players[2].Name ==player.Name )
           {
             // CurrentPlayer = _players[0];
             ChangerOfPlayers[0].ChangeCharacter(false);  
           }
           else if(_players[0].Name == player.Name)
           {
                // CurrentPlayer = _players[1];
             ChangerOfPlayers[1].ChangeCharacter(false);  
           }
       }
     //   _lastChangerOfPlayer.ChangeCharacter(false);
        StartCoroutine(CoolDown());
    } 
    private void IsBomber(Player player,Vector2 position)
    {
      if (player is Bomber)
      {
        player.GetComponent<PlayerBomberMovement>().SetPosition(position);
      }
    }
    // public List<Player> Players { get; set; }// = new List<Player>();
    private IEnumerator CoolDown()
    {
        _isCoolDown = true;
        Debug.LogError(_isCoolDown + " before");
        yield return new WaitForSeconds(1);
        
        _isCoolDown = false;
         Debug.LogError(_isCoolDown + " after");
    }
}
