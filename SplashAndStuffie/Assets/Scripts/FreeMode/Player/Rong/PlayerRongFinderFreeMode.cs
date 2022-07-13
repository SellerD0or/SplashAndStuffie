using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRongFinderFreeMode : MonoBehaviour
{
    [SerializeField] private CircleCollider2D _collider;
    [SerializeField] private List<PlayerInformationFreeMode> _players;
    public CircleCollider2D Collider { get => _collider; set => _collider = value; }
    public List<PlayerInformationFreeMode> Players { get => _players; set => _players =value; } 
    private void OnTriggerEnter2D(Collider2D other) {
       
            if (other.TryGetComponent<PlayerInformationFreeMode>(out PlayerInformationFreeMode player))
            {
                Players.Add(player);
            
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
         if (other.TryGetComponent<PlayerInformationFreeMode>(out PlayerInformationFreeMode player))
            {
                Players.Remove(player);
            }
    }
}
