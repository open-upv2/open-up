﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    AudioSource source;

    public void SetSource (AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }

    public void Play()
    {
        source.Play();
    }
}

public class SoundManager1 : MonoBehaviour
{
    public static SoundManager1 instacne;

    [SerializeField]
    Sound[] sounds;

    private void Awake()
    {
        if(instacne != null)
        {
            Debug.LogError("More than 1 sound manager");
        }
        else
        {
            instacne = this;
        }
    }

    private void Start()
    {
        for(int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }
    }

    public void PlaySound(string _name)
    {
        for(int i = 0; i < sounds.Length; i++)
        {
            if(sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }

        Debug.LogWarning("No sound in array");
    }
}
