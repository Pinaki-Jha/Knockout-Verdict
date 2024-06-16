using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuValueScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Text entityName;
    public Text attack;
    public Text defence;
    public Text speed;
    public Text health;

    public StatSystemScript playerStats;
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<StatSystemScript>();        
    }

    void Update()
    {
        if (gameObject.activeSelf)
        {
            entityName.text = playerStats.entityName;
            attack.text = playerStats.attack.ToString();
            defence.text = playerStats.defence.ToString();
            speed.text = playerStats.moveSpeed.ToString();
            health.text = playerStats.currentHealth.ToString() + " / " + playerStats.maxHealth.ToString();
        }
    }

    
}
