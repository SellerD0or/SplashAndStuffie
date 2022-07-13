using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DragonBones;
using GameToolkit.Localization;

public class TextMessage : Dialogue, ICreatableArrow
{
   [SerializeField] private  Text _localizedText;
   [SerializeField] private CharactersOfDialogue _charactersOfDialogue;
   [SerializeField] private CharacterMessage _characterMessage;
   [SerializeField] private ChangerOfMessages _changer;
   [SerializeField] private UnityArmatureComponent _animator;
   [SerializeField] private string _playedAnimation;
    [SerializeField] private float _waitTime = 0.1f;
    [SerializeField] private string _message;
    private string _resultOfMessage;
    [SerializeField] private Text _text;
    private int _numberOfLetter;
    [SerializeField] private string _secondMessage;
   [SerializeField] private string _fullMessage;
    [SerializeField] private bool _isAfterChoose;
    [SerializeField] private Text _name;
    [SerializeField] private bool _isEvilDama;
    [SerializeField] private string[] _evilDamaWords;
    private bool _isEvilDamaEnded;
    private bool _isSimpleEnded;

    public bool IsSimpleEnded { get => _isSimpleEnded; set => _isSimpleEnded = value; }
    public bool IsEvilDamaEnded { get => _isEvilDamaEnded; set => _isEvilDamaEnded = value; }

    private void OnEnable() {
       
       //;
    }
    private void Start() {
       string name = "";
      // _name.text = _charactersOfDialogue.Name;
       PlayerPrefs.GetString("LANGUAGUE",name);
  //   _message =  _localizedText.GetLocaleValue();
    // if(name == ")
    
    _fullMessage = _localizedText.text;
    if(_isAfterChoose == true)
    {
       int first = _fullMessage.IndexOf(',');
       Debug.Log(first + _characterMessage.Name);
      _fullMessage = _fullMessage.Insert(first +1, " " + _characterMessage.Name);         
    }
    if (_isEvilDama)
    {
       _fullMessage = _localizedText.text;
       _evilDamaWords = _fullMessage.Split(' ');
    }
    
      // if(!_isAfterChoose)
      // _fullMessage = _secondMessage + _message;
     //  else
     //  {
      //     _fullMessage = _secondMessage + _characterMessage.Name  + _message;
     //  }
       
       _animator.animation.Play(_playedAnimation);
       if(_isEvilDama == false)
       {
       StartCoroutine(Display());
       }
       else
       {
          StartCoroutine(ShowWords());
       }
       StartCoroutine(AppearArrow());
       
    }
    public IEnumerator ShowWords()
    {
       yield return new WaitForSeconds(0.25f);
       
       _resultOfMessage += _evilDamaWords[_numberOfLetter] + " ";
         _text.text = _resultOfMessage; //+ _message[_numberOfLetter];
         _numberOfLetter++;
       if (_text.text != _fullMessage && IsEvilDamaEnded == false)
       {
          StartCoroutine(ShowWords());
       }
       else if(IsEvilDamaEnded)
       {
          _text.text = _fullMessage;
        StopCoroutine(ShowWords());  
       }
    }
    public IEnumerator Display()
    {
        yield return new WaitForSeconds(_waitTime);
        _resultOfMessage += _fullMessage[_numberOfLetter];
         _text.text = _resultOfMessage; //+ _message[_numberOfLetter];
         _numberOfLetter++;
       if (_text.text != _message && IsSimpleEnded == false)
       {
          StartCoroutine(Display());
       }
       else if(IsSimpleEnded)
       {
          _text.text = _fullMessage;
        StopCoroutine(Display());  
       }
       
       
    }
    private void OnDisable() {
       _changer.gameObject.SetActive(false);
    }
      public IEnumerator AppearArrow()
    {
       yield return new WaitForSeconds(5);
       _changer.gameObject.SetActive(true);
       _changer.Appear(this);
    }
    private void Update() {
                 Debug.Log(IsSimpleEnded + " [] - [] " + IsEvilDamaEnded);

       if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
       {
          if(IsSimpleEnded == false)
          {
           IsSimpleEnded = true;
          _resultOfMessage = _fullMessage;
              IsEvilDamaEnded = true;
              Debug.Log("COOOL!!!");
          if(_isEvilDama == false)
       {
       StopCoroutine(Display());
       }
       else
       {
          StopCoroutine(ShowWords());
       }
          }
          else //if((IsSimpleEnded && _isEvilDama == false) || (IsEvilDamaEnded && _isEvilDama))
          {
             Debug.Log("NEXT APPEAR!!!");
             StopCoroutine(AppearArrow());
             _changer.gameObject.SetActive(true);
       _changer.Appear(this);
       _changer.OpenNextMessage();
          }
      
       //_text.text = _fullMessage;
       }
    }
    private IEnumerator ShowText(float waitTime)
    {
       yield return new WaitForSeconds(waitTime);
       _text.text = "";
    }
}
