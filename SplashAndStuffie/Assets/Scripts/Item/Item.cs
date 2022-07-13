using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ArtifactInfo))]
public abstract class Item : MonoBehaviour
{
  [SerializeField] private string _fullName;
  [SerializeField] private string _name;
  [SerializeField] private Sprite _sprite;
  public abstract ArtifactInfo ArtifactInfo{get;set;}
  public abstract ArtifactRarity Rarity{ get; set;}
    public Sprite Sprite { get => _sprite; set => _sprite = value; }
    public string Name { get => _name; set => _name = value; }
    public string FullName { get => _fullName; set => _fullName = value; }

    private void Start() {
    ArtifactInfo = GetComponent<ArtifactInfo>();
  }
}
