using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{
    [Header("----------Header File------------")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------Audio File------------")]
    public AudioClip Clicks;
    public AudioClip MenuBG;

    void Start()
    {
        MusicSource.clip = MenuBG;
        MusicSource.Play();
    }

}
