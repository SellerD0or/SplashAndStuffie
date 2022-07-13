using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class GameSlot : MonoBehaviour
{
    [SerializeField] private GameObject _slot;
    [SerializeField] private LocalizationText _text;
    private DelayedGameSlotWindow _window;
    private SaverBuilding _saverBuilding;
    private SaverDroppedLoot _saverDroppedLoot;
    private SaverInventory _saverInventory;
    [SerializeField] private int _savedIndex;
    private Settings _settings;
    private SaveableSlotOfCharacter _currentSaveableSlotOfCharacter;
    private void Start() {
         _window = FindObjectOfType<DelayedGameSlotWindow>();
        _settings =FindObjectOfType<Settings>();
        _saverInventory = FindObjectOfType<SaverInventory>();
        _saverDroppedLoot = FindObjectOfType<SaverDroppedLoot>();
        _saverBuilding = FindObjectOfType<SaverBuilding>();
         _currentSaveableSlotOfCharacter  =  JsonUtility.FromJson<SaveableSlotOfCharacter>(File.ReadAllText(Application.streamingAssetsPath + $"/SaveableSlotOfCharacter{_savedIndex}.json"));
        if (_currentSaveableSlotOfCharacter.CurrentPlayerNames.Contains("Ezra"))
        {
            _slot.SetActive(true);
            _text.Key = "PROLOGUE PASSED";
            _text.Display();
        }
        else
        {
            _text.Key = "THE PROLOGUE IS NOT STARTED";
            _text.Display();
        }
    }
     public void Save()
     {
        PlayerPrefs.SetInt("GameSlot", _savedIndex);
     }
     public void RemoveFile()
     {
          Save();
          _window.Enter();
          _window.OnChoose += Destroy;
          _window.OnExit += Exit;
     }
     private void Exit() => _window.OnChoose-= Destroy;
     private void Destroy()
     {
         _saverBuilding.Destroy();
         _saverDroppedLoot.Destroy();
         _saverInventory.Destroy();
         _window.OnChoose-= Destroy;
     }
     public void ChooseCurrentFile()
     {
         Save();
         _saverDroppedLoot.Load();
         _saverInventory.Load();
         _settings.LoadNextScene();
     }
}
