using UnityEngine.Audio;
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

    private void Start()
    {
        MusicSource.clip = GameBG;
        MusicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
