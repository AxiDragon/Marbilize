using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeAudio : MonoBehaviour
{
    AudioSource audioSource;
    float startPitch, startVolume;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        startPitch = audioSource.pitch;
        startVolume = audioSource.volume;
        Randomize();
    }
    public void Randomize()
    {
        audioSource.pitch = startPitch * Random.Range(0.8f, 1.2f);
        audioSource.volume = startVolume * Random.Range(0.8f, 1.2f);
    }
}
