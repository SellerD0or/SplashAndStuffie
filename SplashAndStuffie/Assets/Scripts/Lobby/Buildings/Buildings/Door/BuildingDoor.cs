using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDoor : Building
{
    [SerializeField] private BuildingInformation _buildingInformation;
    public override Signboard Signboard { get ; set ; }
    public override BuildingInformation BuildingInformation { get => _buildingInformation; set => _buildingInformation = value; }

    private void Start() {
        Signboard = FindObjectOfType<DoorSignboard>();
    }
      public override void Open()
    {
         ChangeStateOfCanvasGroup(true,1);
    }
    public override void Close()
    {
        ChangeStateOfCanvasGroup(false,0);
    }
    private void ChangeStateOfCanvasGroup(bool _isBlocked, int _alpha)
    {
        Signboard.CanvasGroup.alpha = _alpha;
        Signboard.CanvasGroup.blocksRaycasts = _isBlocked;
    }
}
