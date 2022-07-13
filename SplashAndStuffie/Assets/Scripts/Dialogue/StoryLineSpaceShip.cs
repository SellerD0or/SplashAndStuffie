using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryLineSpaceShip : Dialogue, ICreatableArrow
{
      
    [SerializeField] private bool _havePlanet;
    [SerializeField] private TextMessage _textMessage;
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _blast;
     [SerializeField] private ChangerOfMessages _changer;
     [SerializeField] private GameObject _planet;
    private void Start() 
    {
        if (_havePlanet)
        {
            _planet.SetActive(true);
        }
       StartCoroutine(AppearArrow());
   }
   private void OnDisable() {
       if(_havePlanet)
       {
     _background.SetActive(true);
     _blast.SetActive(true);
       }
   }
    public IEnumerator AppearArrow()
    {
       yield return new WaitForSeconds(5);
       _changer.gameObject.SetActive(true);
       _changer.Appear(this);
    }
 
}
