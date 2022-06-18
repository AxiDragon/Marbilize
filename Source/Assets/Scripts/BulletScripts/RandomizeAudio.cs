using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeAudio : MonoBehaviour
{
    AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = audioSource.pitch * Random.Range(0.8f, 1.2f);
        audioSource.volume = audioSource.volume * Random.Range(0.8f, 1.2f);
    }
}
