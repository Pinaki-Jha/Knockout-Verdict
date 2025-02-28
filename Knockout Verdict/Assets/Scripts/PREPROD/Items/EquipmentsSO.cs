using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EquipmentsSO : ScriptableObject
{
    public string itemName;

    public float maxHealth, attack, bulletSpeed, defence, moveSpeed, jumpForce, firingDelay;

    public void Equip()
    {
        StatSystemScript playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<StatSystemScript>(); 
        playerStats.maxHealth += maxHealth;
        playerStats.attack += attack;
        playerStats.bulletSpeed += bulletSpeed;
        playerStats.defence += defence;
        playerStats.moveSpeed += moveSpeed;
        playerStats.jumpForce += jumpForce;
        playerStats.firingDelay += firingDelay;
        
    }

    public void UnEquip() {

        StatSystemScript playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<StatSystemScript>();
        playerStats.maxHealth -= maxHealth;
        playerStats.attack -= attack;
        playerStats.bulletSpeed -= bulletSpeed;
        playerStats.defence -= defence;
        playerStats.moveSpeed -= moveSpeed;
        playerStats.jumpForce -= jumpForce;
        playerStats.firingDelay -= firingDelay;
    }


}
