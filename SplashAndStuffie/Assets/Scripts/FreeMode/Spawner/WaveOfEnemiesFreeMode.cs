using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveOfEnemiesFreeMode : MonoBehaviour
{
   [SerializeField] private List< WaveFreeMode> _enemies;
    public List<WaveFreeMode> Waves { get => _enemies; set => _enemies = value; }
}
