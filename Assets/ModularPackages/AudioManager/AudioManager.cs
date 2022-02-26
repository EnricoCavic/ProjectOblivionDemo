using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public SoundClass[] sounds;

    private void Awake() 
    {
        foreach(SoundClass _sound in sounds)
        {
            _sound.source = gameObject.AddComponent<AudioSource>();
            _sound.source.clip = _sound.clip;
            _sound.source.volume = _sound.volume;
            _sound.source.pitch = _sound.pitch;

        }
    }

    public void Play(string _name)
    {
        SoundClass _sound = Array.Find<SoundClass>(sounds, sound => sound.name == _name);
        _sound.source.Play();
    }

    public void Stop(string _name)
    {
        SoundClass _sound = Array.Find<SoundClass>(sounds, sound => sound.name == _name);
        _sound.source.Stop();
    }


}
