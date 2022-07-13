using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;

public class StoryDialogue : Dialogue, ICreatableArrow
{
  
    [SerializeField] private StoryZoomDialogue _storyZoomDialogue;
    [SerializeField] private ChangerOfMessages _changer;
           [SerializeField] private UnityArmatureComponent _unityArmature;

   private void Start() {
       LocalizationManager localizationManager = FindObjectOfType<LocalizationManager>();
        string name = "";
      // _name.text = _charactersOfDialogue.Name;
     name =  PlayerPrefs.GetString("Language");
    Debug.Log(name);
       if(name == "en_US")
       {
                             _unityArmature.animation.FadeIn("str_push_3_eng");

       }
       else
       {
                    _unityArmature.animation.FadeIn("str_push_3_ru");


       }
       _changer.gameObject.SetActive(false);
       StartCoroutine(AppearArrow());
   }
   private IEnumerator Cooldown()
   {
       yield return new WaitForSeconds(6);
     //  _storyZoomDialogue.gameObject.SetActive(true);
      // gameObject.SetActive(false);

   }
      public IEnumerator AppearArrow()
    {
       yield return new WaitForSeconds(5);
       _changer.gameObject.SetActive(true);
       _changer.Appear(this);
    }
}
