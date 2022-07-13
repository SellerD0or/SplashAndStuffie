using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MainShopTab : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Animator _animator;
    [SerializeField] private MainShopTab[] _tabs;
    [SerializeField] private GameObject _tab;
    private bool _isClick;
    public GameObject Tab { get => _tab; set => _tab = value; }
    public bool IsClick { get => _isClick; set => _isClick = value; }
    [SerializeField] private bool _isStart;
    private void Start() {
        if (_isStart)
        {
            OnClick();
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
       OnClick();
       // _animator.SetBool("IsEnter", false);
    }
    private void OnClick()
    {
         TurnOn();
        TurnOff();
        IsClick = true;
        OnEnter();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(IsClick == false)
       OnEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(IsClick == false)
        OnExit();
    }

    public void TurnOff()
    {
       // _tab.SetActive(false);
        foreach (MainShopTab mainShopTab in _tabs)
       {
           mainShopTab.IsClick = false;
            mainShopTab.Tab.SetActive(false);
            mainShopTab.OnExit();
         //   OnExit();
        }
        //_animator.SetBool("Select", false);
    }
    private void OnEnter() => _animator.SetBool("IsEnter", false);
    private void OnExit() => _animator.SetBool("IsEnter", true);
    public void TurnOn()
    {
        
        _tab.SetActive(true);
        
    }
    
  
}
