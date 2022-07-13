using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBotZBoard : MonoBehaviour
{
    private GetterPlayer _getterPlayer;
  [SerializeField] private CanvasGroup _canvasGroup;

    public CanvasGroup CanvasGroup { get => _canvasGroup; set => _canvasGroup = value; }
      [SerializeField] private MiniBoardOfReloadingAbility _miniBoard;

    private void Start() {
        _getterPlayer =FindObjectOfType<GetterPlayer>();
        DoApperation();
    }
    private void DoApperation()
    {
                 Player player =_getterPlayer.Players.Find(e=> e.Name == "Spire");
         Debug.Log(player.Name +" OKEY BOMBER1");
              for (int i = 0; i < 3; i++)
        {
            MiniBoardOfReloadingAbility miniBoard = Instantiate(_miniBoard,transform.position,Quaternion.identity);
            miniBoard.transform.SetParent(transform,false);
        }
        // player.Ability.OnFull+= Appear;
         player.Ability.OnRemove+= Disappear;
         Appear();

    }
        private void Disappear()
    {
        CanvasGroup.alpha = 0;
        CanvasGroup.blocksRaycasts = false;
    }
 
    private void Appear()
    {
        Debug.Log("APPPEAR!!!");
        CanvasGroup.alpha = 1;
        CanvasGroup.blocksRaycasts = true;
    }
}
