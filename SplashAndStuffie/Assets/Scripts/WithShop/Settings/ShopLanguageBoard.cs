using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopLanguageBoard : MonoBehaviour
{
    [SerializeField] private string _nameOfLanguage;
    public void SetLanguage()
    {
        PlayerPrefs.SetString("LANGUAGE", _nameOfLanguage);
    }
}
