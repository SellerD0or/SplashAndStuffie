using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SlotOfCharacter : MonoBehaviour ,IPointerClickHandler
{
    public event UnityAction OnClick;
        [SerializeField] private List<Sprite> _spritesOfBackground;

    [SerializeField] private LocalizationText _localizationText;
        [SerializeField] private Sprite[] _spritesOfstars;
        [SerializeField] private GameObject[] _stars;
    [SerializeField] private Sprite[] _spritesOfTypeOfPlayer;
    [SerializeField] private  Image _iconOfTypeOfPlayer;
    [SerializeField] private string _nameOfItems = "";
    [SerializeField] private Text _text;
   [SerializeField] private List<Item> _items = new List<Item>();
   [SerializeField] private Image _icon;
    private Equipment _equipment;
   [SerializeField] private Player player;
    public Player Player { get => player; set => player = value; }
    public List<Item> Items { get => _items; set => _items = value; }
    public List<Item> CurrentItems {get;set;} = new List<Item>();
    public EquipmentOfCharacter CurrentEquipmentOfCharacter { get => _currentEquipmentOfCharacter; set => _currentEquipmentOfCharacter = value; }
    public string NameOfItems { get => _nameOfItems; set => _nameOfItems = value; }
    public bool IsSimple { get => _isSimple; set => _isSimple = value; }
    public bool IsOpen { get => _isOpen; set => _isOpen = value; }

    [SerializeField] private EquipmentOfCharacter _equipmentOfCharacter;
    private EquipmentOfCharacter _currentEquipmentOfCharacter;
    private SaveableEquipmentOfCharacter _saveableEquipmentOfCharacter;
    private CreatorSlotOfCharacter _creatorSlotOfCharacter;
    private int _countOfStars;
    private bool _isSimple;
    [SerializeField] private Image _background;
     [SerializeField] private Image _outline;
    [SerializeField] private Sprite _availableSpriteOfOutline;
    [SerializeField] private Sprite _choosenSpriteOfOutline;
    [SerializeField] private Sprite _closeSpriteOfOutline;
        [SerializeField] private GameObject _mask;
        private EquipmentCamera _camera;
    
    private bool _isOpen;
    private InventoryBoard _board;
    private void Start() {
        _board = FindObjectOfType<InventoryBoard>();
        _camera = FindObjectOfType<EquipmentCamera>();
        _creatorSlotOfCharacter = FindObjectOfType<CreatorSlotOfCharacter>();
        _iconOfTypeOfPlayer.sprite = _spritesOfTypeOfPlayer[(int) player.TypeOfPlayer];
        
        _icon.sprite  = player.BarIcon;
        _text.text = player.Name;
        if (_saveableEquipmentOfCharacter == null)
        {
            //  File.WriteAllText(Application.streamingAssetsPath + "/SaveableEquimentOfCharacter.json", JsonUtility.ToJson(new SaveableEquipmentOfCharacter() {EquipmentOfCharacter = _currentEquipmentOfCharacter}));
        }
        else
        {
           //_saveableEquipmentOfCharacter = JsonUtility.FromJson<SaveableEquipmentOfCharacter>(File.ReadAllText(Application.streamingAssetsPath + "/SaveableEquimentOfCharacter.json")); 
         //  _currentEquipmentOfCharacter = _saveableEquipmentOfCharacter.EquipmentOfCharacter;
        }
        if(IsOpen)
        {
        _equipment = FindObjectOfType<Equipment>();
        _equipment.OnDisable += CloseEquipmentOfCharacter;
           CurrentEquipmentOfCharacter = Instantiate(_equipmentOfCharacter, new Vector3(-321,396,0), Quaternion.identity);
            CurrentEquipmentOfCharacter.Player = Player;
        CurrentEquipmentOfCharacter.transform.SetParent(_equipment.EquipmentInterface.EquipmentsOfCharacters, false);
       
       for (int i = 0; i < Player.LevelOfPlayer +1; i++)
       {
           _stars[i].gameObject.SetActive(true);
       }
       for (int i = 0; i < _stars.Length; i++)
        {
           _stars[i].GetComponent<Image>().sprite = _spritesOfstars[Player.LevelOfPlayer];

        }
        }
        _localizationText.Key = Player.Name;
        _localizationText.Display();
        CloseEquipmentOfCharacter();
    }
    private void CloseEquipmentOfCharacter()
    {
        CurrentEquipmentOfCharacter.gameObject.SetActive(false);
    }
    public void SetBackground(bool isAvailable)
    {
              Sprite spriteOfBackground = Player.LevelOfPlayer >= 2 ? _spritesOfBackground[2] : _spritesOfBackground[Player.LevelOfPlayer];
      _icon.sprite = Player.Icon;
      _background.sprite = spriteOfBackground;
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
     IsOpen = isAvailable;
    }
    public void OpenEquipment()
    {
        if(IsOpen)
        {
        SlotOfCharacter slotOfCharacter = _creatorSlotOfCharacter.SaverInventory.CurrentSaveableSlotOfCharacter.CurrentSlotsOfCharacters.Find(e=> e==this);
        if(slotOfCharacter!= null)
        {
            int pos= _creatorSlotOfCharacter.SaverInventory.CurrentSaveableSlotOfCharacter.CurrentSlotsOfCharacters.IndexOf(slotOfCharacter);
            _creatorSlotOfCharacter.SaverInventory.CurrentSaveableSlotOfCharacter.CurrentSlotsOfCharacters.Remove(slotOfCharacter);
            _creatorSlotOfCharacter.SaverInventory.CurrentSaveableSlotOfCharacter.CurrentSlotsOfCharacters.Insert(pos,slotOfCharacter);
            _creatorSlotOfCharacter.SaverInventory.SaveSaveableCurrentInventory(_creatorSlotOfCharacter.SaverInventory.CurrentSaveableSlotOfCharacter);
        }
        
        //_creatorSlotOfCharacter.SaverInventory.Save(new SaveableSlotOfCharacter() {SlotOfCharacter = this});
        _equipment.EquipmentInterface.SlotOfCharacter = this;
        _equipment.SetPlayer(Player);
        _equipment.EquipmentInterface.EquipmentOfCharacter = _equipmentOfCharacter;
        for (int i = 0; i < 3; i++)
        {
            _equipment.CharacterItemIcons[i] = _equipmentOfCharacter.Icons[i];
        }
      //  foreach (var item in _equipmentOfCharacter.Icons)
       // {
        //    Debug.Log("YEYYS");
          //  _equipment.CharacterItemIcons.Add(item);
      //  }
        
        _equipment.ChangeStateOfEquipment();
        CurrentEquipmentOfCharacter.gameObject.SetActive(true);
        }
    }
    public void AddItem(Item item)
    {
        if (Items.Count < 3 && IsOpen)
        {
            Items.Add(item);
        }
    }
    public void RemoveItem(Item item)
    {
        if(IsOpen)
        {
        Items.Remove(item);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(IsOpen)
        {
        OnClick?.Invoke();
        Click();
        OpenEquipment();
        }
    }
    private void Click()
    {
        _board.IsClicked =true; 
        _camera.MoveToEndPosition();
    }
}
