using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryLineSpace : Dialogue, ICreatableArrow
{
     [SerializeField] private LoaderCharacter _loaderCharacter;
    [SerializeField] private SaverInventory _saverInventory;
      [SerializeField] private GameObject _leftScreen;
      private Settings _settings;
        [SerializeField] private AudioSource[] _audioSourses;
     [SerializeField] private ChangerOfMessages _changer;
    private void Start() 
    {
      _audioSourses[0].gameObject.SetActive(false);
       _audioSourses[1].gameObject.SetActive(true);
       _audioSourses[1].Play();
    _settings = FindObjectOfType<Settings>();
StartCoroutine(CoolDown());
       StartCoroutine(AppearArrow());
   }
      private IEnumerator CoolDown()
   {
       yield return new WaitForSeconds(16);
       _leftScreen.SetActive(true);
       Invoke(nameof(StartNewScene),3);
   }

    public IEnumerator AppearArrow()
    {
       yield return new WaitForSeconds(5);
       _changer.gameObject.SetActive(true);
       _changer.Appear(this);
    }
        private void StartNewScene() 
   {
       List<Player> players = new List<Player>();
       foreach (var item in _saverInventory.CurrentSaveableSlotOfCharacter.CurrentPlayerNames)
       {
              players.Add(    _saverInventory.AllPlayer.Find(e=> e.Name == item ));
       }
         _loaderCharacter.SaveSaveableCurrentInventory(new SaveableSelectOfCharacter() {CurrentPlayers = players});
       _settings.LoadGame();
   
       
   }
}
