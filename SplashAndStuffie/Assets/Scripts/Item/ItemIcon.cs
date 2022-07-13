using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(ItemSlot))]
public class ItemIcon : MonoBehaviour, IPointerClickHandler
{
    private ChangerItem _changerOfItem;
   [SerializeField] private ItemSlot _itemSlot;
   private void Start() {
       _changerOfItem = FindObjectOfType<ChangerItem>();
   }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if(!_itemSlot.IsEmpty && _changerOfItem.HaveItem == false)
            {
            _changerOfItem.ChooseItem(_itemSlot.Item,_itemSlot);
            _itemSlot.RemoveItem();
            }
        }
        else  if(eventData.button == PointerEventData.InputButton.Right)
        {
            if(_itemSlot.IsEmpty && _changerOfItem.HaveItem)
            {
            
           //_itemSlot.RemoveItem();
           _itemSlot.AddItem(_changerOfItem.Item);
            _changerOfItem.RemoveItem();
            }
            //_changerOfItem.ChooseItem(_itemSlot.Item);
        }
       
      // if ( _itemSlot.IsEmpty && _changerOfItem.HaveItem == false)
      //     {
              
       //    }
      // if (   && _changerOfItem.CanTakeItem)
      // {
          //  _changerOfItem.RemoveItem();
          // _itemSlot.RemoveItem();
        //   _itemSlot.AddItem(_changerOfItem.Item);
           Debug.LogError("you are able"); 
       //}
    }
    public void Log() => Debug.LogError("log");
}
