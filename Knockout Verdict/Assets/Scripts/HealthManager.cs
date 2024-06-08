using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public StatSystemScript playerStats;    //max health and current health in that script
    public Image healthBar;


    // Start is called before the first frame update
    void Start()
    {
        playerStats.currentHealth = playerStats.maxHealth;    //set the current health equal to the max health
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(playerStats.currentHealth / playerStats.maxHealth, 0, 1);
    }


    public void Heal(int amount)
    {
        playerStats.currentHealth = Mathf.Clamp(playerStats.currentHealth + amount, 0, playerStats.maxHealth);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MedKit"))
        {
            Heal(1); // Adjust the heal amount as needed
            Destroy(collision.gameObject);
        }
    }

}
