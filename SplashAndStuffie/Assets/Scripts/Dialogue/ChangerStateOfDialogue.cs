using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerStateOfDialogue : MonoBehaviour
{
   [SerializeField] private List<Dialogue> _dialogues;
   [SerializeField] private ClickableArrow _arrow;
   public void TurnOnDialogue() => ChangeDialogue(true,true);
   public void TurnOffDialogue() => ChangeDialogue(false,false);
   private void ChangeDialogue(bool isDialoguesActive, bool isClicableArrowActive)
   {
       _dialogues.ForEach(e => e.gameObject.SetActive(isDialoguesActive));
       _arrow.gameObject.SetActive(isClicableArrowActive);
   }
}
