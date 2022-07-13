using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OtisShopGlobalBoard : MonoBehaviour 
{
    [SerializeField] private string _name;
      [SerializeField] private Animator _animator;
    [SerializeField] private OtisShopGlobalBoard[] _tabs;
    [SerializeField] private GameObject _tab;
    private bool _isClick;
    public GameObject Tab { get => _tab; set => _tab = value; }
    public bool IsClick { get => _isClick; set => _isClick = value; }
    public bool IsStart { get => _isStart; set => _isStart = value; }
    public string Name { get => _name; set => _name = value; }
    [SerializeField] private GameObject[] _objectsForAppearing;
    [SerializeField] private GameObject[] _objectsForDisappearing;

    [SerializeField] private bool _isStart;
    private void Start() 
    {
        if (IsStart)
        {
            OnClick();
        }
    }
    public void OnPointerClick()
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

    public void OnPointerEnter()
    {
        if(IsClick == false)
       OnEnter();
    }

    public void OnPointerExit()
    {
        if(IsClick == false)
        OnExit();
    }

    public void TurnOff()
    {
       // _tab.SetActive(false);
        foreach (OtisShopGlobalBoard mainShopTab in _tabs)
       {
           mainShopTab.IsClick = false;
            mainShopTab.Tab.SetActive(false);
            mainShopTab.OnExit();
         //   OnExit();
        }
        foreach (var item in _objectsForDisappearing)
        {
           item.SetActive(false);
        }
        //_animator.SetBool("Select", false);
    }
    private void OnEnter() => _animator.SetBool("IsEnter", false);
    private void OnExit() => _animator.SetBool("IsEnter", true);
    public void TurnOn()
    {
        foreach (var item in _objectsForAppearing)
        {
            item.SetActive(true);
        }
        _tab.SetActive(true);
        
    }
    
}
