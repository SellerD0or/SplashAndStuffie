using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OtisShopPlayerBoard : OtisShopBoard
{
      [SerializeField] private Sprite[] _spritesOfstars;
        [SerializeField] private GameObject[] _stars;
        [SerializeField] private Player _player;
        private void Start() {
           for (int i = 0; i < _player.LevelOfPlayer +1; i++)
       {
           _stars[i].gameObject.SetActive(true);
       }
       for (int i = 0; i < _stars.Length; i++)
        {
           _stars[i].GetComponent<Image>().sprite = _spritesOfstars[_player.LevelOfPlayer];

        }
        }
}
