using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class StatSystemScript : MonoBehaviour
{

    public string entityName = "Jaata Ka Chhora";
    public float maxHealth = 100f;
    public float currentHealth;
    public float attack = 0.5f;
    public float bulletSpeed = 30f;
    public float defence = 0f;
    public float moveSpeed = 5.5f;
    public float jumpForce = 28f;
    public float firingDelay = 0.25f;
    public bool isAlive = true;

    public GameObject healthBar;

    private float hbaTime = 2f;
    private float hbaCounter = 0;
    private float maxHealthBar;
    private float healthBarPos;

    public GameManagerScript gameManager;
    private bool isDead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private float numOfFlashes;
    private SpriteRenderer spriteRend;

    private Coroutine invincibilityCoroutine;

    /*This script will hold all of the stat variables and functions
    of all of the interactable characters.
    Stat variables will basically be variables and functions that are common for
    all characters and/or can change based on certain conditions*/

    void Start()
    {
        
        if (gameObject.CompareTag("Player"))
        {
            spriteRend = gameObject.transform.Find("Sprite").GameObject().GetComponent<SpriteRenderer>();

            PlayerBaseStatsScript playerBaseStats = gameObject.GetComponent<PlayerBaseStatsScript>();

            entityName = playerBaseStats.getPlayerName;
            maxHealth = playerBaseStats.getPlayerBaseMaxHealth;
            attack = playerBaseStats.getPlayerBaseAttack;
            bulletSpeed = playerBaseStats.getPlayerBaseBulletSpeed;
            defence = playerBaseStats.getPlayerBaseDefence;
            moveSpeed = playerBaseStats.getPlayerBaseMoveSpeed;
            jumpForce = playerBaseStats.getPlayerBaseJumpForce;
            firingDelay = playerBaseStats.getPlayerBaseFiringDelay;
        }
        else
        {
            spriteRend = gameObject.GetComponent<SpriteRenderer>();    //isko hata dena baad mein aur ek mein hee kar dena after making enemy sprites
        }

        currentHealth = maxHealth;      //set the current health equal to the max health
        maxHealthBar = healthBar.transform.localScale.x;
        healthBarPos = healthBar.transform.localPosition.x;



    }

    void Update()
    {
        if (healthBar.activeSelf)
        {
            DeactivateHealthBar();
        }
        Death();
    }

    private void OnTriggerEnter2D(Collider2D collision)                //when collision with a bullet
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletScript bulletScript = collision.gameObject.GetComponent<BulletScript>();

            if (bulletScript.shooter == gameObject)                    //check for friendly fire.
            {
                Debug.Log(entityName + "shot self");
            }

            else
            {
                currentHealth -= bulletScript.damage - defence;

                if (currentHealth > 0 && gameObject.layer==7)
                {
                    invincibilityCoroutine = StartCoroutine(Invulnerability());  //call for I-Frames
                }

                if (!healthBar.activeSelf)
                { 
                    healthBar.SetActive(true); 
                    hbaCounter = 0; 
                }
                else 
                {
                    hbaCounter = 0; 
                }
                float percentHealth = currentHealth / maxHealth;

                healthBar.transform.localScale = new Vector3(maxHealthBar * percentHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
                healthBar.transform.localPosition = new Vector3(healthBarPos, healthBar.transform.localPosition.y, healthBar.transform.localPosition.z);
                Debug.Log("Damage Taken by " + entityName);
            }
        }
    }

    private void DeactivateHealthBar()
    {
        if (hbaCounter >= hbaTime)
        {
            healthBar.SetActive(false);
            hbaCounter = 0f;
        }
        else
        {
            hbaCounter += Time.deltaTime;
        }
    }

    void Death()
    {
        if (currentHealth <= 0 && !isDead)      //Check for dead player.
        {  
            isDead = true;
            name = gameObject.name;
            Debug.Log(name + " killed");
            isAlive = false;
            if (gameObject.CompareTag("Player"))
            {
                gameManager.GameOver();
            }
            Destroy(gameObject);
        }
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(7, 9, true);
        for (int i = 0; i < numOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(0.3f);
            spriteRend.color = new Color(1, 1, 1, 1f);
            yield return new WaitForSeconds(0.3f);
        }
        Physics2D.IgnoreLayerCollision(7, 9, false);
    }
}




