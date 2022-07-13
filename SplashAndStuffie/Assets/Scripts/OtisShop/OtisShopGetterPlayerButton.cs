using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OtisShopGetterPlayerButton : MonoBehaviour, IPointerClickHandler
{
  [SerializeField] private string _name;
    [SerializeField] private Player _player;
   [SerializeField] private bool _isSpeatialCharcter;
 [SerializeField] private GameObject _backGround;

   public void OnPointerClick(PointerEventData eventData)
    {
       _backGround?.SetActive(true);
       Invoke(nameof(LoadScene),1);
    }
    public void LoadScene()
    {
        if(_isSpeatialCharcter)
        {
        Save(new SaveableStoreCharacter(){Player = _player});
        }

        PlayerPrefs.SetString("OtisShopBoard",_name);
      SceneManager.LoadScene("GetterEntity");
    }
     public  void Save(SaveableStoreCharacter data)
    {
     
      File.WriteAllText(Application.streamingAssetsPath + "/SaveableStoreCharacter.json", JsonUtility.ToJson(data));
    }
}
