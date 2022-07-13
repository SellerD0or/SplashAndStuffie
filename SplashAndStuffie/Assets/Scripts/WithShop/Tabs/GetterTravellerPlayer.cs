using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GetterTravellerPlayer : MonoBehaviour
{
    private readonly string _filePath = Application.streamingAssetsPath + "/Save.json";
    private Player _player;
      private bool _isClassicChoose;
    public Player Player { get => _player; set => _player = value; }
    public bool IsClassicChoose { get => _isClassicChoose; set => _isClassicChoose = value; }
    [SerializeField] private GameObject _background;
  
    private void Start() 
    {
      _background.SetActive(true);
      Player = Load().Player;
      IsClassicChoose = Player == null ? true : false;
    }
    public SaveableStoreCharacter Load()
    {
       return  JsonUtility.FromJson<SaveableStoreCharacter>(File.ReadAllText(Application.streamingAssetsPath + "/SaveableStoreCharacter.json"));
    }
}
