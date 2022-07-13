using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BackgroundPartOfForest : MonoBehaviour
{
    [SerializeField] private GameObject _forest;
    public event UnityAction OnTurnOff;
    public event UnityAction OnTurnOn;
   [SerializeField]  private bool _isStartedArea;

    public bool IsStartedArea { get => _isStartedArea; set => _isStartedArea = value; }

    private void Start() {
        StartCoroutine(CoolDown());
    }
    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        if (IsStartedArea == false)
        {
            TurnOff();
        }

    }
   public void TurnOff()
   {
       OnTurnOff?.Invoke();
       _forest.SetActive(false);
   }
   public void TurnOn()
   {
      OnTurnOn?.Invoke();
      Debug.Log("TUNR ON!!!");
       _forest.SetActive(true);
   }
}
