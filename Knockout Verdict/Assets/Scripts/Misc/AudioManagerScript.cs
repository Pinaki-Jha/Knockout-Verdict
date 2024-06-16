using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [Header("----------Header File------------")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------Audio File------------")]
    public AudioClip GameBG;
    public AudioClip Jump;
    public AudioClip GunShot;
    public AudioClip Punch;
    public AudioClip Achievement;

    void Start()
    {
        MusicSource.clip = GameBG;
        MusicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
