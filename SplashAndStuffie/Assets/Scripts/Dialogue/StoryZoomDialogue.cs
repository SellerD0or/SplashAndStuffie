using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;

public class StoryZoomDialogue : Dialogue
{
     [SerializeField] private StoryLoadingDialogue _storyLoadingDialogue;
     [SerializeField ] private ChangerOfMessages _changerOfMessages;
        [SerializeField] private UnityArmatureComponent _unityArmature;

   private void Start() {
       StartCoroutine(Cooldown());
         string name = "";
      // _name.text = _charactersOfDialogue.Name;
       PlayerPrefs.GetString("Language",name);
       if(name == "ru_Ru")
       {
       //  _unityArmature.animation.FadeIn("str_push_3_ru");
       }
       else
       {
               //   _unityArmature.animation.FadeIn("str_push_3_eng");

       }
   }
   private void OnEnable() {
     _changerOfMessages.NumberOfMessage ++;
     _changerOfMessages.gameObject.SetActive(false);
   }
   private IEnumerator Cooldown()
   {
       yield return new WaitForSeconds(4);
       _storyLoadingDialogue.gameObject.SetActive(true);
       //_storyLoadingDialogue.gameObject.SetActive(true);
      gameObject.SetActive(false);

   }
   private void OnDisable() {
     _changerOfMessages.gameObject.SetActive(true);
   }
}
