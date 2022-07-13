using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
public class BuildingOtisShop : Building
{
    [SerializeField] private BuildingInformation _buildingInformation;
    public override Signboard Signboard { get ; set ; }
    public override BuildingInformation BuildingInformation { get => _buildingInformation; set => _buildingInformation = value; }
    [SerializeField] private string _englishName, _russianName;
    private OtisShopSignboard _otisShopSignboard;
    private void Start()
    {

        _otisShopSignboard = FindObjectOfType<OtisShopSignboard>();
        Signboard = _otisShopSignboard;
        _otisShopSignboard.Localization.OnClick += ChangeText;
       ChangeText();
        }
    public void ChangeText()
    {
         string name = "";
      // _name.text = _charactersOfDialogue.Name;
      name = PlayerPrefs.GetString("Language");
       if(name == "ru_RU")
       {
         BuildingInformation.NameOfMovementAnimation = _russianName;
       }
       else
       {
            BuildingInformation.NameOfMovementAnimation = _englishName;
       }
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
