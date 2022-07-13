using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SelectablePlayer : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private SlotOfCharacter _slotOfCharacter;
   [SerializeField] private AdderCharacter _adderCharacter;

    public AdderCharacter AdderCharacter { get => _adderCharacter; set => _adderCharacter = value; }
    public NumberOfSelectedCharacter NumberOfSelectedCharacter { get => _numberOfSelectedCharacter; set => _numberOfSelectedCharacter = value; }
    public bool IsSelected { get => _isSelected; set => _isSelected = value; }

    private bool _canSelect = true;
    [SerializeField] private CanvasGroup _banner;
    private Player _currentPlayer;
   [SerializeField] private Image _icon;
   [SerializeField] private Image _background;
    [SerializeField] private List<Sprite> _spritesOfBackground;
    [SerializeField] private Image _outline;
    [SerializeField] private Sprite _availableSpriteOfOutline;
    [SerializeField] private Sprite _choosenSpriteOfOutline;
    [SerializeField] private Sprite _closeSpriteOfOutline;
    [SerializeField] private NumberOfSelectedCharacter _numberOfSelectedCharacter;
    private LoaderSaveableSlotOfCharacter _loaderSaveableSlot;
    private bool _isSelected;
    private bool _isOpen;
    [SerializeField] private SpriteRenderer _blackWhiteIcon;
    [SerializeField] private SpriteRenderer _blackWhiteBackground;
    [SerializeField] private Image _border;
    [SerializeField] private GameObject _mask;
    private void Start() {
       
    }
       
     public void Close()
    {
        if(_canSelect)
        {
          AdderCharacter.Choose(_slotOfCharacter);
          _banner.alpha = 1;
          _banner.blocksRaycasts = true;
          _canSelect = false;
        }
    }
    public void CreateSlot(Player player,bool isAvailable)
    {
      _currentPlayer =player;
      Sprite spriteOfBackground = player.LevelOfPlayer >= 2 ? _spritesOfBackground[2] : _spritesOfBackground[player.LevelOfPlayer];
      _icon.sprite = player.Icon;
      _background.sprite = spriteOfBackground;
     // if(isAvailable)
    //  {
     //   _icon.gameObject.SetActive(true);
     //   _background.gameObject.SetActive(true);
      
     // _border.gameObject.SetActive(true);
      //_mask.SetActive(false);
    //  }
      if(isAvailable == false)
      {
        //_icon.gameObject.SetActive(false);
       // _background.gameObject.SetActive(false);
      //  _blackWhiteIcon.sprite = player.Icon;
       // _blackWhiteBackground.sprite = spriteOfBackground;
       // _border.gameObject.SetActive(false);
        _mask.SetActive(true);
      }
    //  _background.sprite  = player.LevelOfPlayer >= 2 ? _spritesOfBackground[2] : _spritesOfBackground[player.LevelOfPlayer];
     _outline.sprite = isAvailable ?  _availableSpriteOfOutline : _closeSpriteOfOutline;
     _isOpen = isAvailable;
     _numberOfSelectedCharacter.Player = player;
     _loaderSaveableSlot = _numberOfSelectedCharacter.Loader;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      Debug.Log("COOOL you click");
        if (_isOpen && _isSelected == false && _loaderSaveableSlot.NumberOfSelectedCharacter < 3)
        {
          _loaderSaveableSlot.TurnOffAppearedBackgrouds();
           _numberOfSelectedCharacter.Open();
         GameObject appearedItem = _loaderSaveableSlot.GetAppearedBackground(_currentPlayer);
         appearedItem.SetActive(true);
           ChangeStateOfSelect(true,_choosenSpriteOfOutline);

        }
    }
   // public void TurnOffAppearedBackgroud() => _appearedBackground.SetActive(false);
    public void RemoveClick()
    {
      _numberOfSelectedCharacter.Close();
          ChangeStateOfSelect(false,_availableSpriteOfOutline);
          
    }
    private void ChangeStateOfSelect(bool isSelected, Sprite sprite)
    {
      _outline.sprite = sprite;
          _isSelected = isSelected;
    }
}
