using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugRegistrationBoard : MonoBehaviour
{
    [SerializeField] private LocalizationText _localizationText;
    [SerializeField] private Text _text;
    public void DisplayText(string text)
    {
        _localizationText.Key= text;
        _localizationText.Display();
    }
    private void Start() {
        Destroy(gameObject,8);
    }
}
