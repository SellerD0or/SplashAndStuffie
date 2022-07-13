using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.IO;
public class TravellerShopTab : MonoBehaviour, IPointerClickHandler
{
    private readonly string _filePath = Application.streamingAssetsPath + "/Save.json";
    [SerializeField] private GameObject _exclamationMark;
    [SerializeField] private GameObject _shopBackGround;
    [SerializeField] private Player _player;
     [SerializeField] private GameObject _backGround;
      private void OnEnable() {
        _exclamationMark.SetActive(true);
        _shopBackGround.SetActive(true);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
       _backGround.SetActive(true);
       Invoke(nameof(LoadScene),1);
    }
    public void LoadScene()
    {
        Save(new SaveableStoreCharacter(){Player = _player});
      SceneManager.LoadScene("GetterEntity");
    }
     public  void Save(SaveableStoreCharacter data)
    {
     
      File.WriteAllText(Application.streamingAssetsPath + "/SaveableStoreCharacter.json", JsonUtility.ToJson(data));
    }
      private void OnDisable() {
         _exclamationMark.SetActive(false);
        _shopBackGround.SetActive(false);
    }
}
