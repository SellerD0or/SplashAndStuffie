using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypeOfDroppedStar
{
    Item,
    OneStars,
    TwoStars,
    ThreeStars,
    FourStars
}
public class DroppedStar : MonoBehaviour
{
    [SerializeField] private starFxController _starFx;
    [SerializeField] private TypeOfDroppedStar _typeOfDroppedStar;
[SerializeField] private List<Material> _itemMaterialsOfstars;
[SerializeField] private List<Material> _playerMaterialsStars;
  [SerializeField] private List<ParticleSystem> _particleSystems;
  [SerializeField] private GameObject[] _stars;
    public TypeOfDroppedStar TypeOfDroppedStar { get => _typeOfDroppedStar; set => _typeOfDroppedStar = value; }
    public void SetParticleSystems(int length)
  {
      bool isThreeStar = length == 2;
      _starFx.ea = length + 1;
      if (length == 0)
      {
          length = 1;
      }
      else
      {
          length*= 2;
      }
     
      if(_typeOfDroppedStar == TypeOfDroppedStar.Item)
      {
          if(isThreeStar)
          {
   for (int i = 0; i < _particleSystems.Count; i++)
      {
              _particleSystems[i].GetComponent<ParticleSystemRenderer>().material = _itemMaterialsOfstars[5];
              Debug.LogError(_particleSystems[i] +" CHANNGE STAR TO " + _itemMaterialsOfstars[i]);
      }
          }
          else
          {
              
      for (int i = 0; i < _particleSystems.Count; i++)
      {
              _particleSystems[i].GetComponent<ParticleSystemRenderer>().material = _itemMaterialsOfstars[i];
      }
          }
            _starFx.Reset();
      }
      else 
      {
             for (int i = 0; i < _particleSystems.Count; i++)
       {
              _particleSystems[i].GetComponent<ParticleSystemRenderer>().material = _playerMaterialsStars[0];
       }
            _starFx.Reset();
       }
      }

  }
