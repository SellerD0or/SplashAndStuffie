using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayerOfTimer : MonoBehaviour, IChangedMovementEntity
{
    [SerializeField] private Timer _timer;
    private Camera _camera;
    [SerializeField] private Text _text;

    public Vector3 StartLocalScale { get ; set ; }
    public void LookAt()
    {
        
        transform.LookAt(_camera.transform.position);
       // transform.Rotate(_camera.transform.position.x,_camera.transform.position.y,90);    
        }

    public void SetNormal()
    {
       transform.localScale = new Vector3(StartLocalScale.x, StartLocalScale.y, StartLocalScale.z);
    }

    public void TurnLeft()
    {
        transform.localScale = new Vector3(-StartLocalScale.x, StartLocalScale.y,StartLocalScale.z);
    }

    public void TurnRight()
    {
       transform.localScale = new Vector3(-StartLocalScale.x, StartLocalScale.y,StartLocalScale.z);
    }

    public void TurnTop()
    {
      transform.localScale = new Vector3(StartLocalScale.x, -StartLocalScale.y,StartLocalScale.z);
    }

    private void Start() {
      
       CollectionOfChangedMovementEntities. Add(this);
        _timer.OnTimeChanged += TimeChange;
        _camera = Camera.main;
        StartLocalScale = transform.localScale;
        TurnLeft();
    }
    private void TimeChange()
    {
        _text.text =$"{_timer.CurrentMinute}:{_timer.CurrentSecond}";
    }
    
   private void Update() {
     LookAt();
   }
}
