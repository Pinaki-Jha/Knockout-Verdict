using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemsSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public void UseItem() { 
        if(statToChange==StatToChange.health)
        {
            StatSystemScript playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<StatSystemScript>();
            if (playerStats.currentHealth + amountToChangeStat > playerStats.maxHealth)
            {
                playerStats.currentHealth = playerStats.maxHealth;
            }
            else 
            { 
                playerStats.currentHealth += amountToChangeStat;
            }
            

        }
    }


    public enum StatToChange { 

        none,
        health,
        attack,
        defence,
        speed,
        lives
    
    };
}
