using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectionFreeMode : MonoBehaviour
{
    public List<PlayerInformationFreeMode> PlayerInformations { get; set; } = new List<PlayerInformationFreeMode>();
    public void AddPlayer(PlayerInformationFreeMode playerInformation)
    {
        PlayerInformations.Add(playerInformation);
    }
    public void RemovePlayer(PlayerInformationFreeMode playerInformation)
    {
        PlayerInformations.Remove(playerInformation);
    }
}
