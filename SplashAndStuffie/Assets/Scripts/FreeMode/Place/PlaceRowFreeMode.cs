using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DragonBones;

public class PlaceRowFreeMode : MonoBehaviour
{
  [SerializeField] private PlaceRowFreeMode _higherPlaceRow;
  [SerializeField] private bool _isTheHighestPlaceRow;
         [SerializeField] private Vector2 _additionPosition;

      [SerializeField] private bool _isRight;
    [SerializeField] private int _layer;  
 [SerializeField]  private bool _isLowPlace;
    [SerializeField] private PlaceFreeMode _firstPlace;
   [SerializeField] private Vector2 _direction;
  [SerializeField]   private List< PlayerInformationFreeMode> _players = new List<PlayerInformationFreeMode>();
   [SerializeField] private List<EnemyInformationFreeMode> _enemies = new List<EnemyInformationFreeMode>();
    public Vector2 Direction { get => _direction; set => _direction = value; }
    public PlaceFreeMode FirstPlace { get => _firstPlace; set => _firstPlace = value; }
    public List<EnemyInformationFreeMode> Enemies { get => _enemies; set => _enemies = value; }
    public List<PlayerInformationFreeMode> Players { get => _players; set => _players = value; }
    public bool IsLowPlace { get => _isLowPlace; set => _isLowPlace = value; }
    public bool IsRight { get => _isRight; set => _isRight = value; }
    public Vector2 AdditionPosition { get => _additionPosition; set => _additionPosition = value; }
    public PlaceRowFreeMode HigherPlaceRow { get => _higherPlaceRow; set => _higherPlaceRow = value; }
    public bool IsTheHighestPlaceRow { get => _isTheHighestPlaceRow; set => _isTheHighestPlaceRow = value; }

    public void AddPlayer(PlayerInformationFreeMode playerMovement)
    {
    
      if(playerMovement.PlaceRow.IsLowPlace == false)
      {
        CanMoveBack(playerMovement,true);
      }
      else
      {
       CanMoveLowPlace(playerMovement,true);
      }
      playerMovement.PlayerAnimatorFreeMode.ArmatureComponent.sortingOrder = _layer;
    Players.Add(playerMovement);
    }
     public void RemovePlayer(PlayerInformationFreeMode playerMovement)
     {
        Players.Remove(playerMovement);
          if (Players.Count <= 0)
          {
              foreach (var enemy in Enemies)
              {
                enemy.EnemyAttack.ContinieToMove();
                enemy.EnemyAnimator.PlayRunAnimation();            
              }
              Enemies.ForEach(e=> e.EnemyAttack.ContinieToMove());
          }
     }
      public void AddEnemy(EnemyInformationFreeMode enemy)
      {
        enemy.GetComponent<UnityArmatureComponent>().sortingOrder = _layer;
        enemy.EnemyAnimator.Run();
           Enemies.Add(enemy);
           StartMovingPlayer(enemy);
           //Players.Where(e=> e.Speed != e.StartSpeed).Select(e=> e.Speed = e.StartSpeed);
            //StartMovingPlayer(enemy);
         // foreach (var player in Players)
          //{
            //   if (player.Speed != player.StartSpeed)
            //  {
             //     player.Speed = player.StartSpeed;
              //}
          // }
      }
      public void StartMovingPlayer(EnemyInformationFreeMode enemy)
      {
        if (enemy.PlaceRow.Players.Count >= 0)
           {
         foreach (var player in Players)
             {
                if (player.Speed != player.StartSpeed)
              {
                  player.CanMove = true;
               player.Speed = player.StartSpeed;
               player.PlayerAnimatorFreeMode.PlayRunAnimation();
              }
             }
           }
      }
     public void RemoveEnemy(EnemyInformationFreeMode enemy) 
     {
          Enemies.Remove(enemy);
         Enemies.ForEach(e =>  Debug.Log(e + " is enemies"));
          if (Enemies.Count <= 0)
          {
              foreach (var player in Players)
              {
                Debug.Log("row is empty! PleaseStop!");
                //  player.Speed = 0;
                player.GoBack();
                Debug.LogError(player.StartSpeed + " player run!");
                  player.Speed = -player.StartSpeed;
                  player.PlayerAnimatorFreeMode.PlayRunAnimation();
               // player.PlayerAnimatorFreeMode.ArmatureComponent.animation.FadeIn("idle");
                 // player.PlayerAnimatorFreeMode.Idle();
              }
          }
          else
          {
            Players.ForEach(e=> e.FindClosestEnemy());
          }
     }
    public bool CanMoveLowPlace(PlayerInformationFreeMode playerMovement, bool _shouldChange)
    {
        EnemyInformationFreeMode closestEnemy = new EnemyInformationFreeMode();
         float distance = Mathf.Infinity;
       Vector3 position = transform.position;
        foreach (EnemyInformationFreeMode enemy in playerMovement.PlaceRow.Enemies) 
       {
           Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
           if(curDistance< distance) 
           {
                closestEnemy = enemy;
                distance = curDistance;
           }
        }
        if(closestEnemy != null)
        {
       if (playerMovement.transform.position.y < closestEnemy.transform.position.y)
        {
                if (_shouldChange)
           {
             ChangeState(playerMovement);
           }
           return false;
        }
        else
        {
          return true;
        }
        }
        else
        {
          return false;
        }
    }
     public bool CanMoveBack(PlayerInformationFreeMode playerMovement,bool _shouldChange)
     {
         EnemyInformationFreeMode closestEnemy = new EnemyInformationFreeMode();
         float distance = Mathf.Infinity;
       Vector3 position = transform.position;
        foreach (EnemyInformationFreeMode enemy in playerMovement.PlaceRow.Enemies) 
       {
           Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
           if(curDistance< distance) 
           {
                closestEnemy = enemy;
                distance = curDistance;
           }
        }
        if(closestEnemy != null)
        {
         if (playerMovement.PlaceRow.IsRight)
       {
         if (playerMovement.transform.position.x < closestEnemy.transform.position.x)
         {
           Debug.LogError(playerMovement.PlaceRow.IsRight + " :side, + " + "evil pos > player pos");
           if (_shouldChange)
           {
             ChangeState(playerMovement);
           }
           return false;
         }
         else
         {
           return true;
         }
       }
       else
       {
          if (playerMovement.transform.position.x > closestEnemy.transform.position.x)
         {
          Debug.LogError(playerMovement.PlaceRow.IsRight + " :side, + " + "evil pos > player pos");
         if (_shouldChange)
           {
             ChangeState(playerMovement);
           }
           return false;
         }
         else
         {
           return true;
         }
       }
        }
        else
        {
          return false;
        }
     }
     public void ChangeState(PlayerInformationFreeMode playerMovement)
     {
         playerMovement.GoBack();
            playerMovement.Speed = -playerMovement.Speed;
           playerMovement.PlayerAnimatorFreeMode.PlayRunAnimation();
     }
}
