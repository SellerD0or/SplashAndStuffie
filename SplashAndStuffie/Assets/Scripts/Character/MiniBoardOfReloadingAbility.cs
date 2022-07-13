using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class MiniBoardOfReloadingAbility : MonoBehaviour
{
    public event UnityAction OnReload;
   [SerializeField] private Animator _animator;

    public Animator Animator { get => _animator; set => _animator = value; }
    public float TimeForRemoving { get; set; }
    public float TimeForAdding { get; set; }
    public bool IsFull { get => _isFull; set => _isFull = value; }

    [SerializeField] private Image _image;
    private bool _isFull;
    [SerializeField] private float _speed = 2;
    private float _lowerNumber =0,_highestNumber = 1;
    public void UseAbility()
    {
        Invoke(nameof(FinillyUseAbility),TimeForAdding);
    }
    private void FinillyUseAbility()
    {
        IsFull = false;
        _lowerNumber = 0;
    }
    public void RemoveAbility()
    {
        Invoke(nameof(FinillyRemove),TimeForRemoving);
    }
    private void FinillyRemove()
    {
        IsFull = true;
        _highestNumber = 1;
        // Animator.SetBool("IsFull",false);
    }
    private void Update() {
        if (IsFull)
        {
            if(_highestNumber > 0)
            {
              _highestNumber -= Time.deltaTime / _speed; 
            _image.fillAmount = _highestNumber;
            }
        }
        else
        {
        if(_lowerNumber < 1)
            {
              _lowerNumber+= Time.deltaTime / _speed; 
            _image.fillAmount = _lowerNumber;
            }
        }
    }
    public void Reload(float fillAmount)
    {
        _image.fillAmount = fillAmount;
        if (_image.fillAmount == 1)
        {
            OnReload?.Invoke();
        }
    }
}
