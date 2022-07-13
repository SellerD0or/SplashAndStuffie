using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemOutPutFreeMode : MonoBehaviour
{
    [SerializeField] private GetterGemFreeMode _getterGem;
   [SerializeField] private Text _text;
   private void Start() {
       _getterGem.OnGetGem += Show;
   }
   private void Show()
   {
       _text.text = _getterGem.CountOfGem.ToString();
   }
}
