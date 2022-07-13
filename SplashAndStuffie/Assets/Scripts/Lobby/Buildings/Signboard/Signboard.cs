using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CanvasGroup))]
public abstract class Signboard : MonoBehaviour
{
  [SerializeField] private Redactor _redactor;
  private bool _canPress = true;
  [SerializeField] private GameObject _icon;
public Settings Settings { get; set; }  
public CanvasGroup CanvasGroup{get;set;}
    public GameObject Icon { get => _icon; set => _icon = value; }
    public bool CanPress { get => _canPress; set => _canPress = value; }
    public Redactor Redactor { get => _redactor; set => _redactor = value; }

    public abstract void Open();
  private void Start() {
    Settings =FindObjectOfType<Settings>();
      CanvasGroup =GetComponent<CanvasGroup>();
  }
}
