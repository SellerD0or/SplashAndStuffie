using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ClickableArrow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Animator _animator;
    public void OnPointerEnter(PointerEventData eventData)
    {
         _animator.SetBool("_isEnter", false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       _animator.SetBool("_isEnter", true);
    }
}
