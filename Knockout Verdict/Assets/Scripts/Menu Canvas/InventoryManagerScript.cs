using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum EquipmentType
{
    None,
    Item,
    Weapon,
    Armor
};

public class InventoryManagerScript : MonoBehaviour
{

    public ItemsSlotScript[] itemSlot;
    public ItemsSO[] itemSOs;

    public EquipmentsSlotScript[] armorSlot;


    public EquipmentsSlotScript[] weaponSlot;

    public void UseItem(string itemName) { 

        for (int i = 0; i < itemSOs.Length; i++) 
        {
            if (itemSOs[i].itemName == itemName)
            {
                itemSOs[i].UseItem();
            }
        }
    }

    public void UnequipAllArmors() 
    {
        for(int i=0; i<armorSlot.Length; i++)
        {
            armorSlot[i].isEquipped = false;
            armorSlot[i].itemEquippedText.SetActive(false);
        }

    }

    public void UnequipAllWeapons()
    {
        for (int i = 0; i < weaponSlot.Length; i++)
        {
            weaponSlot[i].isEquipped = false;
            weaponSlot[i].itemEquippedText.SetActive(false);
        }

    }

    public void EquipItem(string equipmentName, EquipmentType equipmentType) { 

        Debug.Log(equipmentName + "of type " + equipmentType.ToString() + " is selected.");
    }



    public bool AddItem(string itemName, Sprite itemSprite, string itemDescription, EquipmentType equipmentType) {
        Debug.Log(itemName + " acquired");
        if (equipmentType == EquipmentType.Item)
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                if (!itemSlot[i].isFull)
                {
                    itemSlot[i].addItem(itemName, itemSprite, itemDescription, equipmentType);
                    return true;
                }
            }
        }
        else if( equipmentType == EquipmentType.Weapon)
        {
            for(int i=0; i<weaponSlot.Length; i++)
            {
                if (!weaponSlot[i].isFull) 
                {
                    weaponSlot[i].addItem(itemName, itemSprite, itemDescription, equipmentType);
                }
            }
        }
        else if (equipmentType == EquipmentType.Armor)
        {
            for (int i = 0; i < armorSlot.Length; i++)
            {
                if (!armorSlot[i].isFull)
                {
                    armorSlot[i].addItem(itemName, itemSprite, itemDescription, equipmentType);
                }
            }
        }
        return false;
    }
}
