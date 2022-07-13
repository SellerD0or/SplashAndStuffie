using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class OtisShopMiniCharacterBoard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool _isEntered;
    [SerializeField] private OtisShopCharactersBoard _board;
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _miniBoard;
    private bool _canTouch = true;
    [SerializeField] private List<OtisShopMiniCharacterBoard> _otisShopMiniBoards;

    public bool CanTouch { get => _canTouch; set => _canTouch = value; }

    private void OnEnable()
     {
         _miniBoard.gameObject.SetActive(false);
          MoveForwmard();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
      StartCoroutine(CheckEntering());
    }
    private IEnumerator CheckEntering()
    {
        yield return new WaitForSeconds(1);
        _isEntered = true;
          if(CanTouch == true)
        {
        if(_miniBoard.gameObject.activeInHierarchy == false)
     _miniBoard.gameObject.SetActive(true);
     _animator.SetBool("IsBack",true);
     foreach (var miniBoard in _otisShopMiniBoards)
     {
         miniBoard.CanTouch = false;
         miniBoard._animator.SetBool("IsBack",true);
     }
     _board.Image.enabled = true;
     _miniBoard.SetBool("IsMoved",true);
    }
    }
    public void MoveForwmard()
    {
              _animator.SetBool("IsBack",false);
         _miniBoard.SetBool("IsMoved",false);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopCoroutine(CheckEntering());
    }
}
