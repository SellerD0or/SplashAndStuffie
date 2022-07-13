using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDialogue : MonoBehaviour
{
    [SerializeField] private ChangerOfMessages _changerOfMessages;
   private void Start() {
     //  _changerOfMessages.gameObject.SetActive(false);
       StartCoroutine(CoolDown());
   }
   private IEnumerator CoolDown()
   {
       yield return new WaitForSeconds(5);
      
   }
}
