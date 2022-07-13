using System.Runtime.CompilerServices;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangerOfMessages : MonoBehaviour
{
 [SerializeField] private Sprite _sprite;
  [SerializeField] private LighteningEffect _sceneEffect;
    [SerializeField] private List<Dialogue> _dialogues;
    [SerializeField] private CharacterMessage _characterMessage;
    [SerializeField] private ChangerStateOfDialogue _changerStateOfDialogue;
     private int _numberOfMessage;
     [SerializeField] private StoryEvilWomanDialogue _storyEvilWoman;
     [SerializeField] private StoryLoadingDialogue _dialogue;
     private bool _dialogueEnded;
     private Camera _camera;
      [SerializeField] private Animator _animator;

    public int NumberOfMessage { get => _numberOfMessage; set => _numberOfMessage = value; }
    public Animator Animator { get => _animator; set => _animator = value; }
    private bool _isAppear;
    [SerializeField] private EndDialogue _endDiaolgue;
    [SerializeField] private Animator _dialogueAnimator;
   private Dialogue _lastDialogue;
   [SerializeField] private Saver _saver;
    private void Start() {
       _camera = Camera.main;
     }

    public void OpenNextMessage()
    {
      if(_dialogues[NumberOfMessage] == _characterMessage)  
      {
        Debug.Log("SSSSSSSSAAAAAAAAAAAAAVEEEEEEEEEEEE");
      _saver.Save(new SaveableEducation(){IsEducationEnd = true, Player = _characterMessage.CurrentPlayer, IsCreated = false});
      }
     if (NumberOfMessage < _dialogues.Count - 1)
     {
     _dialogues[NumberOfMessage].gameObject.SetActive(false);
     NumberOfMessage++;
     System.Console.WriteLine("cool");
     _dialogues[NumberOfMessage].gameObject.SetActive(true);
     return;
     }
     //if(!_dialogueEnded)
    //{
     //_changerStateOfDialogue.TurnOffDialogue();
   //  Saver saver = new Saver();
    // Debug.Log("cool");
     //_dialogue.gameObject.SetActive(true);
     // saver.Save(new SaveableEducation(){IsEducationEnd = true, Player = _characterMessage.CurrentPlayer});
   //   _dialogueEnded = true;
    //  return;
    // }
    // _storyEvilWoman.gameObject.SetActive(true);
    // _camera.backgroundColor =Color.black;
   //  _dialogues[_numberOfMessage + 1].gameObject.SetActive(true);
    // gameObject.SetActive(false);
      //SceneManager.LoadScene(0);
    }
    private void Update() {
       if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
       {
         Debug.LogError("cool");
                OpenNextMessage();
       }
    }
    private void OnDisable() {
      _isAppear = false;
      _dialogueAnimator.gameObject.SetActive(false);
      Animator.gameObject.SetActive(false);
    }
    public void Appear(Dialogue dialogue)
    {
      
      if (dialogue is TextMessage && !(_lastDialogue is StoryEvilWomanDialogue))
      {
        _dialogueAnimator.gameObject.SetActive(true);
          _dialogueAnimator.SetTrigger("Appearing");
          _lastDialogue = dialogue;
          return;
      }
      //Animator.gameObject.SetActive(true);
      Animator.SetTrigger("Appearing");
      _isAppear = true;
      _lastDialogue = dialogue;
    }   // public void Click() => _dialogue.gameObject.SetActive(false);
}
