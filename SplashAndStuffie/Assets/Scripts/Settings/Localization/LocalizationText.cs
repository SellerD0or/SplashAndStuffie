using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]

public class LocalizationText : MonoBehaviour
{
      [SerializeField]
    private string _key;
 
    private LocalizationManager _localizationManager;
    private Text _text;

    public string Key { get => _key; set => _key = value; }

    private void Awake()
    {
        Display();
    }
 
    void Start()
    {
        
    }
    public void Display()
    {
        if (_localizationManager == null)
        {
            _localizationManager = FindObjectOfType<LocalizationManager>();
        }
        if(_text == null)
        {
            _text = GetComponent<Text>();
        }
        _localizationManager.OnLanguageChanged += UpdateText;
        UpdateText();
    }
 
    private void OnDestroy()
    {
        _localizationManager.OnLanguageChanged -= UpdateText;
    }
 
    virtual protected void UpdateText()
    {
        if (gameObject == null) return;
 
        if(_localizationManager == null)
        {
            _localizationManager = FindObjectOfType<LocalizationManager>();
        }
        if (_text == null)
        {
            _text = GetComponent<Text>();
        }
        _text.text = _localizationManager.GetLocalizedValue(Key);
    }
}
