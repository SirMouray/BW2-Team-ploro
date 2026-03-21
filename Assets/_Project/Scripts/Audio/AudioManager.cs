using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Sounds")]
    [SerializeField] private List<Sound> sfxSounds;
    [SerializeField] private AudioClip backgroundClip;

    [Header("Sources")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource backgroundSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        PlayBackground();
    }

    private void PlayBackground()
    {
        if (backgroundClip != null && backgroundSource != null)
        {
            backgroundSource.clip = backgroundClip;
            backgroundSource.Play();
            backgroundSource.loop = true;
        }
    }

    public void PlaySFXSound(string soundToPlay)
    {
        var sound = sfxSounds.Find(t => t.soundName == soundToPlay);
        if (sound != null)
        {
            audioSource.clip = sound.audioClip;
            audioSource.Play();
        }
    }
}