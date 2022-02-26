using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SoundClass
{
    public string name;
    public AudioClip clip;
    [HideInInspector] public AudioSource source;

    [Range(0f, 1f)]
    public float volume;
    public float pitch;

}
