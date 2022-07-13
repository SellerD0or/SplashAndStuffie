using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using UnityEngine.UI;
[RequireComponent(typeof(GoGoScreen))]
public class Settings : MonoBehaviour
{
  private bool _isReload =false;
    private GoGoScreen _gogoscreen;
    [SerializeField] private AudioSource _audioClip;
   // [SerializeField] private Animator _animation;
   // [SerializeField] private GameObject _blackScreen;
  //  [SerializeField] private Image _image;
     private UnityArmatureComponent _player;
      private SaveableEducation _saveableEducation;

    public GoGoScreen Gogoscreen { get => _gogoscreen; set => _gogoscreen = value; }

    // [SerializeField] private GameObject _joinNewScene;

    private delegate void OnSave();
    private void Start() {
    
        Gogoscreen = GetComponent<GoGoScreen>();
        _audioClip.Play();
        Gogoscreen.OnLoadScene?.Invoke();
      //  _joinNewScene.SetActive(true);
        LoadInformation();
       
      // LoadInformation();
    }
    private void LoadInformation() 
    {
         Loader   loader = FindObjectOfType<Loader>();
         _saveableEducation =  loader.Load();
    }
    private void Update() 
    {
      
         if (Input.GetKeyDown(KeyCode.A))
        {
           // SetDefaultSettings();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
          //  LoadMenu();
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
           // LoadInventory();
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
         //   LoadShop();
        }
    }
     public void LoadOnlineLobby() => StartCoroutine( LoadAsync("OnlineLobby"));
    public void LoadTestArena() => StartCoroutine( LoadAsync("TestArena"));
    public void LoadGame() => StartCoroutine( LoadAsync("Game"));
    public void LoadFreeMode() => StartCoroutine( LoadAsync("FreeModeScene"));
    public void LoadOtisShop() =>  StartCoroutine( LoadAsync("OtisShop"));
    public void LoadMenu()
    {
      Time.timeScale = 1;
       StartCoroutine( LoadAsync("Menu"));
    }
    public void LoadSavedSlots() => StartCoroutine(LoadAsync("SavedSlots")); 
    public void LoadNextScene()
    {
        LoadInformation();
        SaverInventory _saverInventory = FindObjectOfType<SaverInventory>();
        if (_saverInventory.CurrentSaveableSlotOfCharacter.CurrentPlayerNames.Contains("Bomber"))
        {
          LoadLobby();
        }
        else
        {
          LoadEducaion();
        }
        //OnSave save = _saveableEducation.IsEducationEnd ? (OnSave) LoadLobby : (OnSave) LoadEducaion;

       // save?.Invoke();  
    }
    
    public void LoadInventory() => StartCoroutine(LoadAsync("GameInventory"));
    public void LoadShop() => StartCoroutine(LoadAsync("WishShop"));
    public void LoadLobby() => StartCoroutine(LoadAsync("Lobby"));//StartCoroutine( StartLoading(1));
    private void LoadEducaion() => StartCoroutine( LoadAsync("Education"));
    public void LoadSelectLevel() => StartCoroutine( LoadAsync("SelectLevel"));
    public void LoadSelectCharacter() => StartCoroutine( LoadAsync("SelectCharacter"));
    private IEnumerator StartLoading(string _nameOfScene)
    {
        
       // _blackScreen.SetActive(true);
      //  _loadingScreen.SetActive(true);
      //  _image.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
      //  SceneManager.LoadScene(_numberOfScene);
       StartCoroutine(LoadAsync(_nameOfScene));
    }
    private IEnumerator LoadAsync(string _nameOfScene)
    {
      if(_isReload)
      {
        yield break;
      }
        //_animation.gameObject.SetActive(true);
     //   _image.gameObject.SetActive(true);
     // _blackScreen.SetActive(true);
     Gogoscreen.OnCloseScene?.Invoke();
     _isReload = true;
       // _loadingScreen.SetActive(true);
        yield return new WaitForSeconds(1);
        _isReload =false;
        AsyncOperation asyncOperation =UnityEngine.SceneManagement. SceneManager.LoadSceneAsync(_nameOfScene);
        while (!asyncOperation.isDone)
        {
            
            // _image.color = new Color(_image.color.r, _image.color.g, _image.color.b,asyncOperation.progress);
             yield return null;
        }
    }
    private void SetDefaultSettings()
    {
       //  Saver saver = new Saver();
     
      //saver.Save(new SaveableEducation(){IsEducationEnd = false, IsCreated = false});
       // SaveableEducation _saveableEducation = new SaveableEducation() {IsEducationEnd = false};
        //Saver saver =new Saver();
     //   saver.Save(_saveableEducation);
    }
}
