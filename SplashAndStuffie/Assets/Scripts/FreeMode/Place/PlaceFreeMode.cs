using System.Net.Http.Headers;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlaceFreeMode : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Color _currentColor;
    [SerializeField] private Color _selectedColor;
   // private DisplayerSelectedPlayerFreeMode _displayer;
   [SerializeField] private PlaceRowFreeMode _placeRowFreeMode;

    public PlaceRowFreeMode PlaceRowFreeMode { get => _placeRowFreeMode; set => _placeRowFreeMode = value; }
    [SerializeField] private Vector2 _additionSpaceForBigTravellers;
    private void Start() {
       // _displayer = FindObjectOfType<DisplayerSelectedPlayerFreeMode>();
        _currentColor =_spriteRenderer.color;
    }
   public void OnEnter()
   {
       _spriteRenderer.color = _selectedColor;
   }   public void OnExit()
   {
       Unselect();
   }
   public void CreatePlayer(PlayerInformationFreeMode player, PlayerIconFreeModeScene icon)
   {
     Vector2 position = transform.position;
     if (player.IsBig)
     {
         position = new Vector3(transform.position.x + _additionSpaceForBigTravellers.x, transform.position.y + _additionSpaceForBigTravellers.y,transform.position.z);

     }
     if (player.PlayerAnimatorFreeMode is PlayerRongAnimatorFreeMode)
     {
         position = new Vector3(transform.position.x,transform.position.y + 0.5f, transform.position.z);
     }
     
     PlayerInformationFreeMode createdPlayer = Instantiate(player,position,Quaternion.identity);
     
     createdPlayer.PlaceRow = PlaceRowFreeMode;
     createdPlayer.Health = icon.Health;
     createdPlayer.Damage = icon.Damage;
     createdPlayer.PlayerMovementFreeMode.PlayerHealth.PlaceRow = PlaceRowFreeMode;
     if(PlaceRowFreeMode.IsTheHighestPlaceRow == false && player.IsBig)
     {
         PlaceRowFreeMode.HigherPlaceRow.AddPlayer(createdPlayer);
      }
     createdPlayer.Direction = -PlaceRowFreeMode.Direction;
     createdPlayer.PlayerAnimatorFreeMode.Run();
     PlaceRowFreeMode.AddPlayer(createdPlayer);
     if (PlaceRowFreeMode.Enemies.Count <= 0)
     {
         createdPlayer.PlayerAnimatorFreeMode.ArmatureComponent.animation.FadeIn("idle");
         createdPlayer.Speed = 0;  
    }
   }
   public void CreateEnemy(EnemyInformationFreeMode enemyMovement, EnemySpawnerFreeMode enemySpawner,  int additionStat, EnemySpawnPositionFreeMode spawnPosition)
   {
       EnemyInformationFreeMode enemy = Instantiate(enemyMovement,new Vector2(transform.position.x, transform.position.y) + _placeRowFreeMode.AdditionPosition,Quaternion.identity);
       enemy.Health *= additionStat;
       enemy.Damage *= additionStat;
       enemy.Direction = PlaceRowFreeMode.Direction;
       enemy.EnemyAttack.EnemyHealth.EnemySpawner = enemySpawner;
       enemy.EnemyAttack.EnemyHealth.PlaceRow = PlaceRowFreeMode;
       enemy.PlaceRow = PlaceRowFreeMode;
       PlaceRowFreeMode.AddEnemy(enemy);
   }
   private void Unselect()
   {
       _spriteRenderer.color = _currentColor;
   }
}
