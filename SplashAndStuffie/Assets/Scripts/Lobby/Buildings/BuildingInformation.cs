using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
public class BuildingInformation : MonoBehaviour
{

    [SerializeField] private Sprite _sprite;
   [SerializeField] private UnityArmatureComponent _unityArmatureComponent;
   [SerializeField] private string _nameOfIdleAnimation = "idle";
   [SerializeField] private string _nameOfMovementAnimation;
    public UnityArmatureComponent UnityArmatureComponent { get => _unityArmatureComponent; set => _unityArmatureComponent = value; }
    public string NameOfIdleAnimation { get => _nameOfIdleAnimation; set => _nameOfIdleAnimation = value; }
    public string NameOfMovementAnimation { get => _nameOfMovementAnimation; set => _nameOfMovementAnimation = value; }
    public Sprite Sprite { get => _sprite; set => _sprite = value; }
}
