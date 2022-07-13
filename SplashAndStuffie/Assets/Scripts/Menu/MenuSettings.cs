using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;

public class MenuSettings : MonoBehaviour
{
   [SerializeField] private DebugRegistrationBoard _succesfulBoard;
   [SerializeField] private DebugRegistrationBoard _somethingGoneWrongBoard;
     [SerializeField] private LoginBoard _login;
     [SerializeField] private ResetPasswordBoard _password;
    [SerializeField] private SignUpBoard _signup;
    [SerializeField]private GameObject _button;
    [SerializeField] private Settings _settings;
    [SerializeField] private Sprite _english;
        [SerializeField] private Sprite _russian;

    [SerializeField] private SpriteRenderer _name;
         private UnityArmatureComponent _player;
    [SerializeField] private Animator _animator;
    [SerializeField] private DelayedGameSlotWindow _delayedGameSlot;
    private CheckerVersion _checkerVersion;
    private void Start() {
       _checkerVersion = FindObjectOfType<CheckerVersion>();
        _settings =FindObjectOfType<Settings>();
                _player = GetComponent<UnityArmatureComponent>();
         LocalizationManager localizationManager = FindObjectOfType<LocalizationManager>();
         localizationManager.OnClick += ChangeSprite;
        ChangeSprite();
              CheckAutorization();
    }
    private void ChangeSprite()
    {
        string name = "";
      // _name.text = _charactersOfDialogue.Name;
    name =     PlayerPrefs.GetString("Language");
       Debug.Log(name);
       if(name == "ru_RU")
       {
          _name.sprite = _russian;
       }
       else
       {
          _name.sprite = _english;
      }

    }
    public void Close()
    {
         _password.gameObject.SetActive(false);
      _login.gameObject.SetActive(false);
       _signup.gameObject.SetActive(false);
    }
    public void CheckAutorization()
    {
           int autorisiation = 0;
      autorisiation = PlayerPrefs.GetInt("Autorization");
      if(PlayerPrefs.HasKey("Autorization") && autorisiation == 0)
      {
            _button.gameObject.SetActive(true);
         _animator.gameObject.SetActive(false);
      }
      else if(autorisiation == 1)  
      {
         _button.gameObject.SetActive(false);
         _animator.gameObject.SetActive(true);
      }

    }
    public void OpenSignUpBoard()
    {
       _password.gameObject.SetActive(false);
      _login.gameObject.SetActive(false);
       _signup.gameObject.SetActive(true);
    }
    public void OpenLoginBoard()
    {
       _password.gameObject.SetActive(false);
         _login.gameObject.SetActive(true);
          _signup.gameObject.SetActive(false);
    }
     public void OpenResetPasswordBoard()
    {
       _password.gameObject.SetActive(true);
      _login.gameObject.SetActive(false);
       _signup.gameObject.SetActive(false);
    }
  private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && _checkerVersion.IsRightVersion)
        {
           _settings.LoadSavedSlots();
            _player.animation.Play("animation0");
        }
           if (Input.GetKeyDown(KeyCode.Escape))
        {
             _delayedGameSlot.Enter();
        }
        //   if (Input.GetKeyDown(KeyCode.Q))
       // {
           //_settings.LoadNextScene();
          //  _player.animation.Play("animation0");
      //  }
  }
  public void Exit()
  {
       Application.Quit();
  }
  public void CreateSuccesfulBoard(string text)
  {
   DebugRegistrationBoard board =  Instantiate(_succesfulBoard);
    board.DisplayText(text);
  }
   public void CreateSomethingGoneWrongBoard(string text)
  {
   DebugRegistrationBoard board = Instantiate(_somethingGoneWrongBoard);
   board.DisplayText(text);
  }
}
