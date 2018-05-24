using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    public SoundEffect sfx;

    AudioSource source;


    private void OnEnable()
    {
        if(source == null)
            source = GetComponent<AudioSource>();

        sfx.Play(source);
    }
}
