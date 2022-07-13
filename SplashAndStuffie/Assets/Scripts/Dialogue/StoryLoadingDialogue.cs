using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
public class StoryLoadingDialogue : Dialogue, ICreatableArrow
{
      [SerializeField] private CameraFilterPack_Real_VHS _cameraVhs;
       [SerializeField] private StoryEvilWomanDialogue _storyEvilDialogue;
       [SerializeField] private ChangerOfMessages _changer;
       [SerializeField] private UnityArmatureComponent _unityArmature;
   private void Start() {
        string name = "";
      // _name.text = _charactersOfDialogue.Name;
      name = PlayerPrefs.GetString("Language");
       if(name == "ru_RU")
       {
      _unityArmature.animation.FadeIn("str_loading_comp_3_ru");
       }
       else
       {
                _unityArmature.animation.FadeIn("str_loading_comp_3_eng");
       }
     _cameraVhs.enabled =  true;
     _changer.gameObject.SetActive(false);
       StartCoroutine(AppearArrow());
   }
   private IEnumerator Cooldown()
   {
       yield return new WaitForSeconds(6);
     //  _changer.gameObject.SetActive(true);
       

   }
   private void OnDisable() {
     _cameraVhs.enabled =  false;
   }
    public IEnumerator AppearArrow()
    {
       yield return new WaitForSeconds(5);
       _changer.gameObject.SetActive(true);
       _changer.Appear(this);
    }
}
