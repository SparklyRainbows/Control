﻿using System;
using UnityEngine.Audio;
using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Sound {
    #region Variables
    [SerializeField]
    [Tooltip("Name of the sound clip")]
    private string name;

    [SerializeField]
    [Tooltip("The actual audio file")]
    private AudioClip clip;

    [SerializeField]
    [Tooltip("Volume slider that can be adjusted from 0 to 1")]
    [Range(0f, 1f)]
    private float volume;

    [SerializeField]
    [Tooltip("Pitch slider for effects")]
    [Range(.1f, 3f)]
    private float pitch;

    [SerializeField]
    [Tooltip("Check the box to enable looping")]
    private bool loop;

    [SerializeField]
    private AudioSource source;
    #endregion

    #region Accessors
    public string Name {
        get {
            return name;
        }
        set {
            name = value;
        }
    }

    public AudioClip Clip {
        get {
            return clip;
        }
        set {
            clip = value;
        }
    }

    public float Volume {
        get {
            return volume;
        }
        set {
            volume = value;
        }
    }

    public float Pitch {
        get {
            return pitch;
        }
        set {
            pitch = value;
        }
    }

    public bool Loop {
        get {
            return loop;
        }
        set {
            loop = value;
        }
    }

    public AudioSource Source {
        get {
            return source;
        }
        set {
            source = value;
        }
    }
    #endregion
}


public class AudioManager : MonoBehaviour {
    private bool sfxOff;
    
    public AudioClip musicLoop;
    private AudioSource source;

    #region Variables
    [SerializeField]
    [Tooltip("The list of sounds to be played")]
    private Sound[] sounds;
    #endregion

    #region Initialization
    void Awake() {
        DontDestroyOnLoad(gameObject);

        for (int i = 0; i < sounds.Length; i++) {
            Sound s = sounds[i];
            AudioSource source = gameObject.AddComponent<AudioSource>();
            sounds[i].Source = source;
            sounds[i].Source.clip = s.Clip;
            sounds[i].Source.volume = s.Volume;
            sounds[i].Source.pitch = s.Pitch;
            sounds[i].Source.loop = s.Loop;
        }
    }

    private void Start() {
        source = GetComponent<AudioSource>();
        StartCoroutine(PlayMusic());
    }
    #endregion

    #region Play Sounds
    public void Play(string name) {
        if (sfxOff) {
            return;
        }

        Sound s = Array.Find(sounds, sounds => sounds.Name == name);

        if (s.Source == null) {
            Debug.LogWarning("SFX not found: " + name);
            return;
        }

        s.Source.Play();
    }
    #endregion

    public void ToggleMusic() {
        source.volume = source.volume == 0 ? 1 : 0;
    }

    public void ToggleSfx() {
        sfxOff = !sfxOff;
    }

    private IEnumerator PlayMusic() {
        source.Play();
        yield return new WaitWhile(() => source.isPlaying);
        source.clip = musicLoop;
        source.Play();
        source.loop = true;
    }
}