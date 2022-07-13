using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolume : MonoBehaviour
{
    private AudioSource _audioSours;
    private void Start() {
        _audioSours = GetComponent<AudioSource>();
        _audioSours.volume = PlayerPrefs.GetFloat("MusicVolume");
    }
}
