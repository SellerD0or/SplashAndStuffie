using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Equipment : MonoBehaviour
{
    [SerializeField]private Animator[] _animators;
    [SerializeField] private CanvasGroup[] _equipmentCanvasThings;
    [SerializeField] private Image _iconOfTypeOfPlayer;
    [SerializeField] private Sprite[] _spritesOfTypeOfPlayer;
    [SerializeField] private InventoryBoard _board;
    [SerializeField] private EquipmentCamera _camera;
    [SerializeField] private RuntimeAnimatorController _axelRuntimeAnimatorController;
    [SerializeField] private RuntimeAnimatorController _mummtHatRuntimeAnimatorController;
    [SerializeField] private GameObject _equimpentButton;
        [SerializeField] private Transform _equipmentEndPoint, _equipmentStartPoint;
    [SerializeField] private Transform _characterPosition;
    [SerializeField] private Transform _endPoint, _startPoint;
    [SerializeField] private GameObject _scrollRect;
    [SerializeField] private float _speed = 5f;
        [SerializeField] private Sprite[] _spritesOfstars;
        [SerializeField] private GameObject[] _stars;
    [SerializeField] private CreatorSlotOfCharacter _creator;
    [SerializeField] private LocalizationText _description;
    [SerializeField] private LocalizationText _name;
    [SerializeField] private CanvasGroup _canvasGroup;
    private bool _isOpen;
    private Player _player;
    public Player Player { get => _player; private set => _player = value; }
    public EquipmentInterface EquipmentInterface { get => _equipmentInterface; set => _equipmentInterface = value; }
    public List<CharacterItemIcon> CharacterItemIcons { get => _characterItemIcons; set => _characterItemIcons = value; }
    public bool IsOpen { get => _isOpen; set => _isOpen = value; }
    public SaverInventory SaverInventory { get => _saverInventory; set => _saverInventory = value; }
    public SaverDroppedLoot SaverDroppedLoot { get => _saverDroppedLoot; set => _saverDroppedLoot = value; }
    public Transform CharacterPosition { get => _characterPosition; set => _characterPosition = value; }
    public RuntimeAnimatorController MummtHatRuntimeAnimatorController { get => _mummtHatRuntimeAnimatorController; set => _mummtHatRuntimeAnimatorController = value; }
    public RuntimeAnimatorController AxelRuntimeAnimatorController { get => _axelRuntimeAnimatorController; set => _axelRuntimeAnimatorController = value; }

    [SerializeField] private List< CharacterItemIcon> _characterItemIcons;
    [SerializeField] private EquipmentInterface _equipmentInterface;
    public event UnityAction OnEnable;
    public event UnityAction OnDisable;
    [SerializeField] private Transform _spawnPosition;
    private Player _lastPlayer;
    [SerializeField] private SaverInventory _saverInventory;
    [SerializeField] private SaverDroppedLoot _saverDroppedLoot;
    [SerializeField] private Settings _settings;
    private int _rarity;
    private bool _isChoosenSlot;
    private bool _isChoosenEquipment = true;
    [SerializeField] private float _range = 1;
    [SerializeField] private Transform _playerPosition;
    private void Start() {
        OnEnable += CreateCharacter;
        OnDisable += DestroyCharacter;
        OnDisable += Save;
        
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
        if (IsOpen)
        {
           ChangeStateOfEquipment();
        }
        else
        {
            Open();
        }
        }
       /* if(_isChoosenSlot == true)
        {
        _scrollRect.transform.position = Vector3.MoveTowards(_scrollRect.transform.position, _endPoint.position,_speed *Time.deltaTime);
        }
        else
        {
          _scrollRect.transform.position = Vector3.MoveTowards(_scrollRect.transform.position, _startPoint.position,_speed *Time.deltaTime);
        }
        if (_isChoosenEquipment == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(_equipmentEndPoint.position.x,transform.position.y),_speed * 1.5f *Time.deltaTime);
        }
        else
        {
            if(_equimpentButton.gameObject.activeInHierarchy == false)
            {
              transform.position = Vector3.MoveTowards(transform.position, new Vector3(_equipmentStartPoint.position.x,transform.position.y,_equipmentStartPoint.position.z),_speed *Time.deltaTime);
              if (Vector2.Distance(transform.position, new Vector3(_equipmentStartPoint.position.x,transform.position.y,_equipmentStartPoint.position.z)) < _range) 
              {
                  _equimpentButton.gameObject.SetActive(true);
              }
            }
        }*/

    }
    public void Open()
    {
        Debug.Log("COOOOOOOOOOOOOOOOl open" + IsOpen);
        if(!IsOpen)
        _settings.LoadLobby();
    }
    public void ChangeStateOfEquipment()
    {
          if (IsOpen)
        {
            Close();
        }
        IsOpen =! IsOpen;
       // Open();
       // _canvasGroup.alpha = IsOpen ? 1 :0;
       // _canvasGroup.blocksRaycasts = IsOpen;
       foreach (var animator in _animators)
       {
           animator.SetBool("Appeared",IsOpen);
       }
       foreach (var canvasGroup in _equipmentCanvasThings)
       {
          canvasGroup.alpha = IsOpen ? 1 :0;
          canvasGroup.blocksRaycasts = IsOpen;  
       }
        UnityAction OnHappen = IsOpen ? OnEnable : OnDisable;
        OnHappen?.Invoke();
    }
    private void Close()
    {
          _camera.MoveToStartPosition();
          
            _board.IsClicked = false;
          //  FindObjectOfType<Player>();
          _board.CurrentSelectedSlotOfPlayer.InventorySelectedPlayer.UnityArmatureComponent.animation.Play("idle");
           // _equimpentButton.gameObject.SetActive(false);
            _isChoosenEquipment = true;
            _isChoosenSlot =false;
    }
    private void Save()
    {
        EquipmentOfCharacter equipmentOfCharacter = FindObjectOfType<EquipmentOfCharacter>();
        List<Item> currentItemsFromEquipment = new List<Item>();
        List<int> positions = new List<int>();
        List<int> rarities = new List<int>();
        foreach (var item in equipmentOfCharacter.ItemSlots)
        {
            if (item.Item != null)
            {
                    if (item.Item.Name[0] =='О')
        {
            _rarity = 0;
        }
        else   if (item.Item.Name[0] =='Д')
        {
            _rarity = 1;
        }
          else   if (item.Item.Name[0] =='Т')
        {
            _rarity = 2;
        }
                rarities.Add(_rarity);
                Debug.LogError("ITEM: " + item.Item);
                positions.Add(item.IdForCharacterItemIcon);
                currentItemsFromEquipment.Add(item.Item);
            }
        }

        List<Item> items = new List<Item>();
        string nameOfItems = "";
        bool isUsedName = true;
        int count = 0;
        foreach (var item in currentItemsFromEquipment)
        {
            Debug.LogError(item + ", its rarity: " + item.Rarity);
            if (isUsedName)
            {
                nameOfItems = Player.Name + "-";
                isUsedName = false;
            }
        Debug.LogError(item.Name[0] + " CPPPPPPdasda");
            nameOfItems += "," + item.FullName + "!" + _rarity + "?" + positions[count];
             count++;
        }
        if(SaverInventory.CurrentSaveableSlotOfCharacter.CurrentItemNames.Count > 0)
        {
        foreach (var itemName in SaverInventory.CurrentSaveableSlotOfCharacter.CurrentItemNames)
        {
            if(itemName != "")
            {
            int pos =  itemName.IndexOf('-');
            string nameOfPlayer = itemName.Substring(0, pos);
            string clone = itemName;
             Debug.LogError(" name which needs: " + nameOfPlayer + " current name " + Player.Name);
            if (nameOfPlayer == Player.Name)
            {
                Debug.LogError("REMOVE: " + clone + " WHICH NEED TO PUT INSTEAD: " + nameOfItems);
                SaverInventory.CurrentSaveableSlotOfCharacter.CurrentItemNames.Remove(clone);
                SaverInventory.SaveSaveableCurrentInventory(SaverInventory.CurrentSaveableSlotOfCharacter);
                break;
            }
            }
        }
        }
        SaverInventory.Save(new SaveableSlotOfCharacter {ItemName = nameOfItems});
      //  foreach (var item in CharacterItemIcons)
     //   {
          // items.Add(item.ItemSlot.Item);
          //  nameOfItems += item.ItemSlot.Item.Name;
      //  }
      //  foreach (var item in collection)
      //  {
       //     _saverInventory.AllPlayer.
      //  }
        //EquipmentOfCharacter equipmentOfCharacter = _saverInventory.CurrentSaveableSlotOfCharacter.CurrentItems.Find(e=> e == EquipmentInterface.EquipmentOfCharacter);
     /*    SlotOfCharacter slotOfCharacter = _saverInventory.CurrentSaveableSlotOfCharacter.CurrentSlotsOfCharacters.Find(e=> e == EquipmentInterface.SlotOfCharacter);
         
          int index = _saverInventory.CurrentSaveableSlotOfCharacter.CurrentItems.IndexOf(slotOfCharacter.NameOfItems);
          
        _saverInventory.CurrentSaveableSlotOfCharacter.CurrentItems.Remove(slotOfCharacter.NameOfItems); 
        slotOfCharacter.NameOfItems = nameOfItems;
        _saverInventory.CurrentSaveableSlotOfCharacter.CurrentItems.Insert(index, slotOfCharacter.NameOfItems);
*/      
        //_saverInventory.SaveSaveableCurrentInventory(_saverInventory.CurrentSaveableSlotOfCharacter);
        /*
       List<Item> items = new List<Item>();
        foreach (var item in CharacterItemIcons)
        {
            items.Add(item.ItemSlot.Item);
        }
        
         SlotOfCharacter slotOfCharacter = _saverInventory.CurrentSaveableSlotOfCharacter.CurrentSlotsOfCharacters.Find(e=> e == EquipmentInterface.SlotOfCharacter);
         slotOfCharacter.Items = items;
         int index = _saverInventory.CurrentSaveableSlotOfCharacter.CurrentSlotsOfCharacters.IndexOf(slotOfCharacter);
         _saverInventory.CurrentSaveableSlotOfCharacter.CurrentSlotsOfCharacters.Remove(slotOfCharacter); 
         _saverInventory.CurrentSaveableSlotOfCharacter.CurrentSlotsOfCharacters.Insert(index, slotOfCharacter);
         foreach (var item in slotOfCharacter.Items)
        {
            Debug.Log("your items contains: " + item);
        } 
        _saverInventory.SaveSaveableCurrentInventory(_saverInventory.CurrentSaveableSlotOfCharacter);
        */
    }
    public void SetPlayer(Player player)
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
      //  _equimpentButton.SetActive(false);
        _isChoosenSlot = true;
        _isChoosenEquipment = false;
        Player = player;
        _name.Key = player.Name;
        _description.Key = player.MiniDescription;
        _name.Display();
        _description.Display();
         _iconOfTypeOfPlayer.sprite = _spritesOfTypeOfPlayer[(int) player.TypeOfPlayer];
        EquipmentInterface.ChangeIcon(player);
    }
    //-4.49
    private void CreateCharacter()
    {
        Player player = FindObjectOfType<Player>();//Instantiate(Player, _spawnPosition.position, Quaternion.identity);
        
      //  player.transform.localScale = new Vector3(1, 1, 0.4522f);
        _lastPlayer = player;
       /* if(player is Axel)
        {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - 1.08f);
        }
        if(player is Bomber)
        {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - 0.89f);
        }*/
        foreach (var item in _stars)
        {
            item.GetComponent<Image>().sprite = null;
            item.SetActive(false);

        }
         for (int i = 0; i < player.LevelOfPlayer +1; i++)
       {
           _stars[i].gameObject.SetActive(true);
       }
       /*        player.transform.SetParent(_playerPosition);
         if(player is Axel)
        {
            player.transform.localPosition = new Vector2(-524f, -524.0001f);
        }
       else if(player is Bomber)
        {
            player.transform.localPosition = new Vector2(-524f, player.transform.position.y - 0.89f);
        }
        else if(player is Aki)
        {
             player.transform.localPosition = new Vector2(-524f, -46.53f);
        }
        else
        {
        player.transform.localPosition = new Vector3(-524f,player.transform.position.y, player.transform.position.z);
        }*/
       if (player.LevelOfPlayer == 3)
       {
         for (int i = 0; i < _stars.Length; i++)
         {
               _stars[i].GetComponent<Image>().sprite = _spritesOfstars[2];
         }  
       }
       else
       {
       for (int i = 0; i < _stars.Length; i++)
        {
           _stars[i].GetComponent<Image>().sprite = _spritesOfstars[player.LevelOfPlayer];
        }
       }
      //  _creator.CreateItems();
    }
    private void DestroyCharacter()
    {
       Invoke(nameof( StartToDestroy),2);
    }
    private void StartToDestroy()
    {
        if(_lastPlayer != null)
        {
             //   _lastPlayer.transform.localScale = new Vector3(1,1,1);
      //  Destroy(_lastPlayer.gameObject);
        }
    }
    
}
