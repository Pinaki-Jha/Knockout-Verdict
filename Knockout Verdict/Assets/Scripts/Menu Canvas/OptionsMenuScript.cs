using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Button back;

    [SerializeField]private AudioSource musicAudio;
    [SerializeField] private AudioSource sfxAudio;


    [SerializeField] private GameObject superMenu;
    [SerializeField] private Button resume;
    void Awake()
    {
        musicSlider.Select();
    }


    public void controlMusic(float value) { 
        musicAudio.volume = value;
    }

    public void controlEffects(float value)
    {
        sfxAudio.volume = value;
    }

    public void exitOptionsMenu()
    {
        superMenu.SetActive(true);
        resume.Select();
        gameObject.SetActive(false);

    }
}
