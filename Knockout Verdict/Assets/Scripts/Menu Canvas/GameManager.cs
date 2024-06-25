using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPaused = false;

    private GameObject Player;


    public GameObject pauseMenu;
    public GameObject gameOverUI;

    private GameObject menu;
    private GameObject optionsMenu;
    private GameObject superMenu;
    private GameObject itemsMenu;
    private GameObject weaponsMenu;
    private GameObject armorsMenu;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private AudioSource musicAudio;
    [SerializeField] private AudioSource sfxAudio;

    [SerializeField] private Button itemsBackButton;
    [SerializeField] private Button weaponsBackButton;
    [SerializeField] private Button armorsBackButton;



    private float pauseCounter =0f;

    private void Start()
    {
        try
        {
            menu = pauseMenu.transform.Find("Menu").GameObject();

            optionsMenu = menu.transform.Find("Options Menu").GameObject();

            superMenu = menu.transform.Find("Super Menu").GameObject();

            itemsMenu = menu.transform.Find("Items Menu").GameObject();

            weaponsMenu = menu.transform.Find("Weapons Menu").GameObject();

            armorsMenu = menu.transform.Find("Armors Menu").GameObject();

            Player = GameObject.FindGameObjectWithTag("Player");


            musicAudio.volume = musicSlider.value;
            sfxAudio.volume = sfxSlider.value;


        }
        catch (Exception ex) {
            Debug.Log(ex.Message);
        }

    }
    void Update()
    {
        if (pauseCounter<=0.02f && !isPaused)
        {
            pauseCounter += Time.deltaTime;
        }
        PauseGame();
    }

    void PauseGame()
    {
        if (Player)
        {
            if (Input.GetKeyDown(KeyCode.Return) && !isPaused && pauseCounter >= 0.02f)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                isPaused = true;
            }
        }
        
    }

    public void Resume()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            pauseMenu.SetActive(false);
            pauseCounter = 0f;
        }

    }


    public void showOptions()
    {
        optionsMenu.SetActive(true);
        superMenu.SetActive(false);

        
        musicSlider.Select();

    }


    public void showWeaponsInventory()
    { 
        weaponsMenu.SetActive(true);
        superMenu.SetActive(false);

        weaponsBackButton.Select();

    }

    public void showArmorsInventory()
    {
        armorsMenu.SetActive(true);
        superMenu.SetActive(false);

        armorsBackButton.Select();

    }

    public void showItemsInventory()
    {
        itemsMenu.SetActive(true);
        superMenu.SetActive(false);

        itemsBackButton.Select();
    }




    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
 }


