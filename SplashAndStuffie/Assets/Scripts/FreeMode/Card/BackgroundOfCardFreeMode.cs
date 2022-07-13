using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackgroundOfCardFreeMode : MonoBehaviour
{
   public event UnityAction OnStartNewMinute;
    [SerializeField] private GetterCardFreeMode _getterCard;
    [SerializeField] private int _countOfCards;
    [SerializeField] private Transform _position;
    [SerializeField] private PlayerIconFreeModeScene _playerIcon;
    [SerializeField] private DisplayerSelectedPlayerFreeMode _displayer;
    private PlayerIconFreeModeScene _lastIcon;
    [SerializeField] private Animator _animator;
   [SerializeField] private int _minute;
   [SerializeField] private List<PlayerInformationFreeMode> _randomPlayers;
   [SerializeField] private int _time;
   private int _countOfGivenCards = 10;
  private Dictionary<int,int> _currentSpawnRate = new Dictionary<int, int>();

    public int CountOfCards { get => _countOfCards; set => _countOfCards = value; }
    public int Minute { get => _minute; set => _minute = value; }

    [SerializeField] private CardPositionFreeMode[] _cardPositions;
   [SerializeField] private Vector3 _lastPosition;
   [SerializeField] private bool _canMove = true;
    [SerializeField] private float _speed = 2;
    private int _damageIncreased =1;
    private int _healthIncreased = 1;
    private int _rangLevel = 1;
    [SerializeField] private Sprite[] _rangs;
   [SerializeField] private int _currentCountOfCards = 0;
 //   private  List<(int,int)> _randomRangLevel = new List<(int, int)>() {(1,15),(12,26),(22, 31), (28,34), (32, 35),(35,35)};
    private void Start() 
    {
       SetLastPosition(0);
        _getterCard.OnDestroy += Move;
        // Invoke(nameof(Create),0.4f);

        StartCoroutine(Create(10,0.4f));
        StartCoroutine(RepeatCard(5));
         //Invoke(nameof(Move),0.5f);
        StartCoroutine(ChangeTime());
      
    }
    private void SetLastPosition(int countOfPosition)
    {
      
       if(countOfPosition < _cardPositions.Length)
       {
        _lastPosition = _cardPositions[countOfPosition].transform.position;
        _canMove = true;
       }
    }
    public void Stop()
    {
       if(CountOfCards < _cardPositions.Length)
       _lastPosition = _cardPositions[_currentCountOfCards].transform.position;
       else
       _lastPosition = _cardPositions[_cardPositions.Length - 1].transform.position;
    }
    private void Update() {
       if (_canMove)
       {
        //  Debug.Log("MOVING");
        GetComponent<RectTransform>().transform.position = Vector2.Lerp(new Vector3(GetComponent<RectTransform>().transform.position.x, transform.position.y,0),new Vector3(_lastPosition.x, transform.position.y,0),_speed *Time.deltaTime );
         if (Mathf.Abs(transform.position.x - _lastPosition.x) < 0.1f )
         {
             _canMove =false;
           
         }
       }
      // if (transform.position.x < -1500)
    //   {
     //     transform.position = _positions[0].position;
     //  }
    }
    private IEnumerator Create(int count, float _time)
    {
       yield return new WaitForSeconds(_time);
        int result = 0;
         List<PlayerInformationFreeMode> commonPlayers = new List<PlayerInformationFreeMode>();
         commonPlayers = _getterCard.CurrentCards.FindAll(e=> e.LevelOfPlayer == 0);
         List<PlayerInformationFreeMode> rarePlayers = new List<PlayerInformationFreeMode>();
         rarePlayers = _getterCard.CurrentCards.FindAll(e=> e.LevelOfPlayer == 1);
         List<PlayerInformationFreeMode> epicPlayers = new List<PlayerInformationFreeMode>();
         epicPlayers = _getterCard.CurrentCards.FindAll(e=> e.LevelOfPlayer == 2);
         
         List<PlayerInformationFreeMode> legendaryPlayers = new List<PlayerInformationFreeMode>();
         legendaryPlayers = _getterCard.CurrentCards.FindAll(e=> e.LevelOfPlayer == 3);
         if (commonPlayers.Count >= 1)
         {
            result += 7;
         }
          if (rarePlayers.Count >= 1)
         {
            result += 6;
         }
           if (epicPlayers.Count >= 1)
         {
            result += 5;
         }
           if (legendaryPlayers.Count >= 1)
         {
            result += 3;
         }
         //Debug.LogError(result + " of everything");
      for (int i = 0; i < count; i++)
      {
        
         int randomNumber = Random.Range(0,result);
                     Debug.LogError("DROP LEGENDARY!!!"  + randomNumber);

         if (randomNumber < 7)
         {
            int random = Random.Range(0, commonPlayers.Count);
           _randomPlayers.Add(commonPlayers[random]);
         }
          if (randomNumber < 13 && randomNumber >= 7)
         {
            int random = Random.Range(0, rarePlayers.Count);
           _randomPlayers.Add(rarePlayers[random]);
         }
         if (randomNumber < 18 && randomNumber >= 13)
         {
            int random = Random.Range(0, epicPlayers.Count);
           _randomPlayers.Add(epicPlayers[random]);
         }
            if (randomNumber < 21 && randomNumber >= 18)
         {
            Debug.LogError(legendaryPlayers.Count + " COOL");
            //if(legendaryPlayers.Count == 1)
          //  {
           int random = Random.Range(0, legendaryPlayers.Count);
           _randomPlayers.Add(legendaryPlayers[random]);
           // }
           // else
          //  {
           //_randomPlayers.Add(legendaryPlayers[0]);
          // }
         }
          
           
      }
    //  _randomPlayers.ForEach(e=> Debug.Log(e + " PLi"));
    }
    private void CreateCard(PlayerInformationFreeMode player)
    {
       if(CountOfCards < _randomPlayers.Count)
       {
       PlayerIconFreeModeScene createdPlayerIcon =  Instantiate(_playerIcon,transform.position,Quaternion.identity);
       createdPlayerIcon.transform.SetParent(_position,false);
       createdPlayerIcon.DisplayerSelectedPlayer = _displayer;   
       createdPlayerIcon.GetterCard = _getterCard;
       createdPlayerIcon.Player = player;
        int rang = 0;
       if (Minute == 0)
       {
          rang = Random.Range(1,15);
       }
        if (Minute == 1)
       {
          rang = Random.Range(12,26);
       }
        if (Minute == 2)
       {
          rang = Random.Range(22,31);
       }
        if (Minute == 3)
       {
          rang = Random.Range(28,34);
       }
        if (Minute == 4)
       {
          rang = Random.Range(32,35);
       }
        if (Minute >= 5)
       {
          rang = 35;
       }
       if(rang > 0)
       {
       createdPlayerIcon.Damage = rang  * (int) createdPlayerIcon.Player.ExtraDamage + createdPlayerIcon.Player.Damage;
       Debug.Log(createdPlayerIcon.Damage + " DAMAGE _ 'dad' sasds ");
       createdPlayerIcon.Health = rang *  (int) createdPlayerIcon.Player.ExtraHealth + (int) createdPlayerIcon.Player.Health;
       }
       createdPlayerIcon.IconOfRang.sprite = _rangs[rang];
       //createdPlayerIcon.IconOfRang.sprite = _rangs[_rangLevel -1];
      // createdPlayerIcon.Player.Damage += _damageIncreased ;
       //createdPlayerIcon.Player.Health += _healthIncreased;
      if(player.LevelOfPlayer == 0)
       {
          int randomPrice = Random.Range(-2,2);
          createdPlayerIcon.CurrentCountOfMoneyForBuying = randomPrice + 5;
          if (createdPlayerIcon.CurrentCountOfMoneyForBuying == 0)
          {
             createdPlayerIcon.CurrentCountOfMoneyForBuying = 1;
          }
          Debug.LogError(createdPlayerIcon.CurrentCountOfMoneyForBuying + player.ToString() + player.LevelOfPlayer);
       }
       else   if(player.LevelOfPlayer == 1)
       {
          int randomPrice = Random.Range(-3,3);
          createdPlayerIcon.CurrentCountOfMoneyForBuying = randomPrice + 7;
                    Debug.Log(createdPlayerIcon.CurrentCountOfMoneyForBuying + player.ToString() + player.LevelOfPlayer);

       }
        else if(player.LevelOfPlayer == 2)
       {
          int randomPrice = Random.Range(-2,4);
          createdPlayerIcon.CurrentCountOfMoneyForBuying = randomPrice + 9;
                    Debug.Log(createdPlayerIcon.CurrentCountOfMoneyForBuying + player.ToString() + player.LevelOfPlayer);

      }
         else if(player.LevelOfPlayer == 3)
       {
          int randomPrice = Random.Range(-1,7);
          createdPlayerIcon.CurrentCountOfMoneyForBuying = randomPrice + 13;
                    Debug.Log(createdPlayerIcon.CurrentCountOfMoneyForBuying + player.ToString() + player.LevelOfPlayer);

      }

     createdPlayerIcon.SetText(createdPlayerIcon.CurrentCountOfMoneyForBuying);
     //  if(_currentCountOfCards <= 5 )
     //  {
          _currentCountOfCards++;
      // }
       CountOfCards++;
//       _cardPositions[CountOfCards].HaveCard = true;
     //  if(_positions.Length > CountOfCards)
      // {
       SetLastPosition(_currentCountOfCards);
      // }
       _lastIcon = createdPlayerIcon;
       }
       else
       {
        //  if(_lastIcon != null)
        //  {
       //  Destroy(_lastIcon.gameObject);
        // MoveBack();
         // }
       }
    }
    private void SetPlayerRang(PlayerIconFreeModeScene playerIcon)
    {
       int rang = 0;
       if (Minute == 0)
       {
          rang = Random.Range(1,15);
       }
        if (Minute == 1)
       {
          rang = Random.Range(12,26);
       }
        if (Minute == 2)
       {
          rang = Random.Range(22,31);
       }
        if (Minute == 3)
       {
          rang = Random.Range(28,34);
       }
        if (Minute == 4)
       {
          rang = Random.Range(32,35);
       }
        if (Minute >= 5)
       {
          rang = 35;
       }
       if(rang > 0)
       {
       playerIcon.Player.Damage *= rang;
       playerIcon.Player.Health *= rang;
       }
       playerIcon.IconOfRang.sprite = _rangs[rang];
    }
    private void MoveBack()
    {
       //SetLastPosition();
      // _animator.SetBool("Move",false);
    }
    private void Move(int _number)
    {
       CountOfCards--;
       _currentCountOfCards--;
     // int count = _currentCountOfCards- 1;
      //_cardPositions[CountOfCards].HaveCard = true;
       if(_currentCountOfCards >= 0)
      {
        SetLastPosition(_currentCountOfCards);
       }
      // StartCoroutine(RepeatCard(5, _number));
    }
    private IEnumerator RepeatCard(int time)
    {
       yield return new WaitForSeconds(time);
       if(CountOfCards < _randomPlayers.Count)
       {
       CreateCard(_randomPlayers[CountOfCards]);
       }
       StartCoroutine(RepeatCard(5));
    }
     private IEnumerator ChangeTime()
    {
       
       yield return new WaitForSeconds(1);
       _time ++;
       if (_time >= 60)
       {
          _randomPlayers.Clear();
          Minute++;
          OnStartNewMinute?.Invoke();
         StartCoroutine(Create(10 + Minute * 2,0.4f));
        //  _currentSpawnRate.Add(_minute,);
        // for (int i = 0; i < _countOfCards; i++)
      // {
      //     Move(i);
      //  }
      //_healthIncreased= 1 * _minute;
      //_damageIncreased= 1 * _minute;
           _time = 0;
       }
        StartCoroutine(ChangeTime());

    }
}
