using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GetterGem : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI _text;
   [SerializeField] private int _gem;
   public UnityAction OnSpendGem;
   private void Start() {
       OnSpendGem += ChangeGem;
       OnSpendGem?.Invoke();
   }
   public void ChangeGem()
   {
       _text.text = _gem.ToString("#,#", CultureInfo.InvariantCulture); 
   }
}
