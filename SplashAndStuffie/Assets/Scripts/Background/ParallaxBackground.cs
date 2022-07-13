using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
 public ParallaxCamera parallaxCamera;
   List<ParallaxLayer> parallaxLayers = new List<ParallaxLayer>();
   private Player _player;
  
   void Start()
   {
     _player =FindObjectOfType<Player>();
       if (parallaxCamera == null)
         parallaxCamera = Camera.main.GetComponent<ParallaxCamera>();
       if (parallaxCamera != null)
         parallaxCamera.onCameraTranslate += Move;
       SetLayers();
   }
  
   void SetLayers()
   {
       parallaxLayers.Clear();
       for (int i = 0; i < transform.childCount; i++)
       {
           ParallaxLayer layer = transform.GetChild(i).GetComponent<ParallaxLayer>();
  
           if (layer != null)
           {
               parallaxLayers.Add(layer);
           }
       }
     }
     void Move(float delta)
     {
         foreach (ParallaxLayer layer in parallaxLayers)
       {
          // if(layer._startPosition.position.x < parallaxCamera.transform.position.x && layer._endPosition.position.x >parallaxCamera.transform.position.x)
           layer.Move(delta, _player);
           
       }
   }
}
