using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(UnityArmatureComponent))]
public class StorySeller : MonoBehaviour
{
    
 private UnityArmatureComponent _sellerAnimator;
 private int _countToBlink;
 private int _reachedCount;
 [SerializeField] private List<string> _names;
 private string _currentName;
public event UnityAction OnPutHelmetOn;
    public UnityArmatureComponent SellerAnimator { get => _sellerAnimator; set => _sellerAnimator = value; }
public int BlinkNumber { get; set; } =1;
public int IdleNumber { get; set; } =0;
    public bool IsBuilding { get => _isBuilding; set => _isBuilding = value; }
    public bool IsWornHelmet {get;set;} = false;
    private bool _isBuilding;
    private float _waitTime;
    private void Start() {
     SellerAnimator = GetComponent<UnityArmatureComponent>();
     StartCoroutine(CoolDown());
 }
 public void StartCoolDown() => StartCoroutine(CoolDown());
 private IEnumerator CoolDown()
 {
     yield return new WaitForSeconds(4);
     if(_reachedCount >= _countToBlink)
     {
         if(_isBuilding)
      _currentName =   _names[3];
      else
      _currentName = _names[1];
     }
     else
     {
                  if(_isBuilding)
      _currentName =   _names[2];
      else
      _currentName = _names[0];
     }
     _reachedCount++;
     Debug.Log(_currentName);
     if(IsWornHelmet == false)
     {
     SellerAnimator.animation.FadeIn(_currentName);
     _waitTime = 4;
     }
     else
     {
    SellerAnimator.animation.FadeIn("helmet_on");
    _waitTime = 2;
    OnPutHelmetOn?.Invoke();
     }
     StartCoroutine(CoolDown());
 }
 public void StopCoolDown() 
 {
     _reachedCount =0;
     _countToBlink =0;
      StopCoroutine(CoolDown());
 }
}
