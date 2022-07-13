using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GetterCardFreeMode : MonoBehaviour
{
  [SerializeField] private AudioClip _audioClip;
    public UnityAction<int> OnDestroy;
   [SerializeField] private SaverInventory _saverInventory;
   
   [SerializeField] private List<PlayerInformationFreeMode> _allPlayersInformation;
   public List<Player> Players { get; set; } = new List<Player>();
   [SerializeField] private List<PlayerInformationFreeMode> _currentCards;
   public List<PlayerInformationFreeMode> CurrentCards { get => _currentCards; set => _currentCards = value; }
    public AudioClip AudioClip { get => _audioClip; set => _audioClip = value; }

    private void Start() {
     Invoke(nameof(SetCurrentPlayer),0.2f);
 //  SetCurrentPlayer();
   }
   private void SetCurrentPlayer()
   {
     
           foreach (var item in _saverInventory.CurrentSaveableSlotOfCharacter.CurrentPlayerNames)
           {  
              Players.Add(    _saverInventory.AllPlayer.Find(e=> e.Name == item ));
           }
         foreach (var player in Players)
         {
             Debug.Log(player);
             PlayerInformationFreeMode player1 = _allPlayersInformation.Find(e => e.Name == player.Name);
             if(player1 != null)
             {
             CurrentCards.Add(player1);
             }
         }
   }
}
