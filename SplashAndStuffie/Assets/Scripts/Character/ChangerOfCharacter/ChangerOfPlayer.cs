using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ChangerOfPlayer : MonoBehaviour, IPointerClickHandler
{
  //  public abstract HealthOutput HealthOutput {get;set;}
  public abstract bool IsChoosen {get;set;}
  public abstract Player Player {get;set;}
  public abstract GetterPlayer GetterPlayer {get;set;}
  public abstract void ChangeCharacter(bool _isNormal);

    public abstract void OnPointerClick(PointerEventData eventData);
}
