using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class GetterMoney : MonoBehaviour
{
   [SerializeField] private Text _text;
   [SerializeField] private int _money;
   public UnityAction OnSpendMoney;
   private void Start() {
       OnSpendMoney += ChangeMoney;
       OnSpendMoney?.Invoke();
   }
   public void ChangeMoney()
   {
       _text.text = _money.ToString(); 
   }
   
}
