using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ChangerItem : MonoBehaviour
{
    private Item _lastItem;
    private ItemSlot _lastItemSlot;
    private Equipment _equipment;
    private bool _haveItem;
    private bool _canTakeItem;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Image _icon;
    private Item _item;
    public Image Icon { get => _icon; set => _icon = value; }
    public bool HaveItem { get => _haveItem; set => _haveItem = value; }
    public Item Item { get => _item; set => _item = value; }
    public bool CanTakeItem { get => _canTakeItem; set => _canTakeItem = value; }

    private void Start() 
    {
        _equipment  = FindObjectOfType<Equipment>();
        _equipment.OnDisable += ReturnItem;
       Disactive();  
    }
    private void Update() {
       Icon.transform.position = Input.mousePosition;
   }
   public void ChooseItem(Item item, ItemSlot itemIcon)
   {
       if(HaveItem == false)
       {
       Item = item;
       _haveItem = true;
       _canvasGroup.alpha = 1;
       _icon.sprite = item.Sprite;
       _lastItem = item;
       _lastItemSlot = itemIcon;
       }
   }
   public void RemoveItem()
   {
       _haveItem = false;
       Item = null;
       Disactive();
   }
   private void Disactive() => _canvasGroup.alpha = 0;
   private void ReturnItem()
   {
       if(_canvasGroup.alpha == 1)
       {
     RemoveItem();
     Debug.LogError(" p: " + _lastItem);
     _lastItemSlot.AddItem(_lastItem);
        }// _icon.sprite = _lastItem.Sprite;
   }
}
