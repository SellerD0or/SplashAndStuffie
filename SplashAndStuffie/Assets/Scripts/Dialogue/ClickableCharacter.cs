using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ClickableCharacter : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string _englishName;
    [SerializeField] private string _name;
    [SerializeField] private CharacterMessage _dialogue;
     [SerializeField] private Player _player;
     [SerializeField] private Animator _animator;
     
    public string Name { get => _name; set => _name = value; }

    public void OnClick()
     {
         string lamguage = "";
       lamguage =  PlayerPrefs.GetString("Language");
        if(lamguage == "en_US")
         _dialogue.Name = _englishName;
         else
         {
             _dialogue.Name = Name;
         }
            _dialogue.Save(_player);
            Debug.Log("Saveeeeeeeeeee");
            _dialogue.Open();
            
     }
     public void OnEnter()
     {
         _animator.SetBool("_isMove", false);
     }
     public void OnExit()
     {
          _animator.SetBool("_isMove", true);
     }
    public void OnPointerClick(PointerEventData eventData)
    {
     
       // 
    }
}
