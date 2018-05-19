using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Audio/New Sound Effect")]
public class SoundEffect : ScriptableObject
{
    public AudioClip clip;

    public float volumeMin = 1;
    public float volumeMax = 1;

    public float pitchMin = 1;
    public float pitchMax = 1;

    public void Play(AudioSource source)
    {
        source.Stop();  
        source.volume = Random.Range(volumeMin, volumeMax);
        source.pitch = Random.Range(pitchMin, pitchMax);
        source.clip = clip;
        source.Play();
    }
}
