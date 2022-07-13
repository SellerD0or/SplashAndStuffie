using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
public class LocalizationManager : MonoBehaviour
{
     private string _currentLanguage;
    private Dictionary<string, string> _localizedText;
    public static bool _isReady = false;
     public event UnityAction OnClick;

    public delegate void ChangeLangText();
    public event ChangeLangText OnLanguageChanged;
 
    void Awake()
    {
        if (!PlayerPrefs.HasKey("Language"))
        {
         Debug.Log("startedLanguage");
                PlayerPrefs.SetString("Language", "en_US");
            //    PlayerPrefs.SetString("Language", "en_US");
        }
        Load();
        LoadLocalizedText(_currentLanguage);
    }
    public void Load()
    {
       _currentLanguage = PlayerPrefs.GetString("Language");
    }
    public void Save(string language)
    {
       CurrentLanguage = language;
       Debug.Log(CurrentLanguage);
       PlayerPrefs.SetString("Language", language);
              OnClick?.Invoke();

    }
 
    public void LoadLocalizedText(string langName)
    {
        string path = Application.streamingAssetsPath + "/Languages/" + langName + ".json";
 
        string dataAsJson;
 
        if (Application.platform == RuntimePlatform.Android)
        {
            WWW reader = new WWW(path);
            while (!reader.isDone) { }
 
            dataAsJson = reader.text;
        }
        else
        {
            dataAsJson = File.ReadAllText(path);
        }
 
        LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);
 
        _localizedText = new Dictionary<string, string>();
        for (int i = 0; i < loadedData.items.Length; i++)
        {
            _localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
        }
 
       // PlayerPrefs.SetString("Language", langName);
        _currentLanguage = PlayerPrefs.GetString("Language");
        Debug.Log(_currentLanguage);
        _isReady = true;
 
        OnLanguageChanged?.Invoke();
    }
 
    public string GetLocalizedValue(string key)
    {
        if (_localizedText.ContainsKey(key))
        {
            return _localizedText[key];
        }
        else
        {
            throw new Exception("Localized text with key \"" + key + "\" not found");
        }
    }
 
    public string CurrentLanguage
    {
        get 
        {
            return _currentLanguage;
        }
        set
        {
            PlayerPrefs.SetString("Language", value);
            _currentLanguage = PlayerPrefs.GetString("Language");
            LoadLocalizedText(_currentLanguage);
        }
    }
    public bool IsReady
    {
        get
        {
            return _isReady;
        }
    }
}
