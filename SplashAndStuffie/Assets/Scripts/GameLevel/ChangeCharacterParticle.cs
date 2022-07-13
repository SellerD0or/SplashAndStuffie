using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacterParticle : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> _particleSystems;
    [SerializeField] private int _countOfParticle;
   private void Start() {
       foreach (var item in _particleSystems)
       {
          // item.Stop();
       }
      StartCoroutine(Play());
   }
   private IEnumerator Play()
   {

       _particleSystems[_countOfParticle].gameObject.SetActive(true);
       _countOfParticle++;
      yield return new WaitForSeconds(2);
       Debug.Log("cool");
       if (_countOfParticle < _particleSystems.Count)
       {
           StartCoroutine(Play());
       }
       else
       {
           foreach (var item in _particleSystems)
       {
          item.gameObject.SetActive(false);
       }
       }
       
   }
}
