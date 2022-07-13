using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BuildingRocketDrop : Building
{
      [SerializeField] private BuildingInformation _buildingInformation;
     public override Signboard Signboard { get ; set ; }
    public override BuildingInformation BuildingInformation { get => _buildingInformation; set => _buildingInformation = value; }

    private Settings _settings;
    private void Start() {
        _settings = FindObjectOfType<Settings>();
        Signboard = FindObjectOfType<DoorSignboard>();
    }
      public override void Open()
    {
      Signboard.Icon.SetActive(false);
      Signboard. Redactor.CloseScene();
       _settings.LoadInventory();
    }
    public override void Close()
    {
     
    }
}
