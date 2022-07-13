using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
     [SerializeField] private GameObject[] _stars;
      [SerializeField] private Sprite[] _spritesOfstars;
        [SerializeField] private int _idForCharacterItemIcon;
    [SerializeField] private Sprite _emptySprite;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _background;
    private bool _isEmpty = true;
    [SerializeField] private Image _icon;
   [SerializeField]  private Item _item;
    public Item Item { get => _item; set => _item=value; }
    public bool IsEmpty { get => _isEmpty; set => _isEmpty = value; }
    public Sprite[] Sprites { get => _sprites; set => _sprites = value; }
    public Image Background { get => _background; set => _background = value; }
    public int IdForCharacterItemIcon { get => _idForCharacterItemIcon; set => _idForCharacterItemIcon = value; }
    public event UnityAction OnAdd;
    public event UnityAction OnRemove;
    [SerializeField] private bool _isSpetion = true;
    private int _rarity;
    [SerializeField] private bool _isSimple;
    
    public void AddItem(Item item)
    {
                 Debug.Log(item + " ADDD!! TO ITEM SLOT" + IsEmpty);
                 foreach (var star in _stars)
                 {
                     star.SetActive(false);
                 }
        if(IsEmpty == true)
        {
            IsEmpty = false;
        Item = item;
        if (item.Name[0] =='О')
        {
            _rarity = 0;
        }
        else   if (item.Name[0] =='Д')
        {
            _rarity = 1;
        }
          else   if (item.Name[0] =='Т')
        {
            _rarity = 2;
        }
        Debug.LogError(item.Name[0]);
        if(_isSpetion)
        {
        _background.sprite =_sprites[_rarity];
        }
        _icon.sprite = item.Sprite;
        OnAdd?.Invoke();
        if(_isSimple)
        {
               for (int i = 0; i < _rarity +1; i++)
       {
           _stars[i].gameObject.SetActive(true);
       }
       for (int i = 0; i < _stars.Length; i++)
        {
           _stars[i].GetComponent<Image>().sprite = _spritesOfstars[_rarity];

        }
        }
        }
    }
    public void RemoveItem()
    {
        
      IsEmpty = true;
      _icon.sprite = _emptySprite;
      Item = null;
      OnRemove?.Invoke();
    }
}
