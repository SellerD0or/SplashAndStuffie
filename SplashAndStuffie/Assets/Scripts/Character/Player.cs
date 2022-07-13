using System.Net.Mime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Player : Target
{
  [SerializeField] private Ultimate _ultimate;
      [SerializeField] private Sprite _semitransparentIconAbility;
    [SerializeField] private Sprite _semitransparentIconSkill;
   [SerializeField] private string _miniDescription;
     [SerializeField] private bool _isInFreeMode;
    [SerializeField] private int _levelOfPlayer;
    public string Items { get; set; }
    [SerializeField] private TypeOfPlayer _typeOfPlayer;
    [SerializeField] private string _description;
    public abstract Ability Ability {get;set;}
    public bool IsDead {get;set;}
    public abstract string Name {get;set;}
    public abstract Sprite IconAbility{get;set;}
    public abstract Sprite BarIcon {get;set;}
    public abstract Sprite IconSkill{get;set;}
    public abstract IHealthOutPut IHealthOutPut {get;set;}
    public abstract Sprite Icon { get; set; }
    public abstract TakerDamageVisitor TakerDamageVisitor {get;set;}
    public abstract int Damage{get;set;}
    public abstract Enemy Enemy{get;set;}
     public abstract Rigidbody2D Rigidbody2D {get;set;}
    public abstract  float Speed {get;set;}
    public abstract PlayerHealth PlayerHealth{get;set;}
    public abstract IPlayerMovement IPlayerMovement {get;set;}
    public abstract IPlayerAttackable IPlayerAttackable { get; set; }
    public abstract  CharacterChangerState CharacterChangerState { get; set; }
    public abstract bool IsMove();
    public abstract bool IsAttack();
    public abstract IPlayerAnimator IPlayerAnimator{get;set;}
    public TypeOfPlayer TypeOfPlayer { get => _typeOfPlayer; set => _typeOfPlayer = value; }
    public int LevelOfPlayer { get => _levelOfPlayer; set => _levelOfPlayer = value; }
    public bool IsInFreeMode { get => _isInFreeMode; set => _isInFreeMode = value; }
    public string Description { get => _description; set => _description = value; }
    public string MiniDescription { get => _miniDescription; set => _miniDescription = value; }
    public Sprite SemitransparentIconAbility { get => _semitransparentIconAbility; set => _semitransparentIconAbility = value; }
    public Sprite SemitransparentIconSkill { get => _semitransparentIconSkill; set => _semitransparentIconSkill = value; }
    public Ultimate Ultimate { get => _ultimate; set => _ultimate = value; }
}
