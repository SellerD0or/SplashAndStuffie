using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class GetterEnergy : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
   [SerializeField] private int _energy;
   public UnityAction OnSpendEnergy;
   private void Start() {
       OnSpendEnergy += ChangeEnergy;
       OnSpendEnergy?.Invoke();
   }
   public void ChangeEnergy()
   {
       _text.text = _energy.ToString(); 
   }
   
}

