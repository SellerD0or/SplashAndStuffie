using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorPlayer3D : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private IconOfCreatedPlayer3D _iconOfCreatedPlayer3D;
    public void OnClick()
    {
        _iconOfCreatedPlayer3D.Create(_player);
        
    }
}
