using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ButtonSwitchLanguage : MonoBehaviour
{
    [SerializeField] private LocalizationManager _localizationManager;
    [SerializeField] private string _nameOfLangueage = "en_US";
  public  void OnButtonClick()
    {
        _localizationManager.Save(_nameOfLangueage);
    }
}
