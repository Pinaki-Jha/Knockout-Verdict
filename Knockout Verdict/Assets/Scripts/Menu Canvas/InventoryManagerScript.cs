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
    public WeaponsSOLibrary weaponSOLib;
    public ArmorSOLibrary armorSOLib;
    
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
            if (armorSlot[i].isEquipped)
            {
                UnequipItem(armorSlot[i].itemName, EquipmentType.Armor);
                armorSlot[i].isEquipped = false;
                armorSlot[i].itemEquippedText.SetActive(false);
            }
        }

    }

    public void UnequipAllWeapons()
    {
        for (int i = 0; i < weaponSlot.Length; i++)
        {
            if (weaponSlot[i].isEquipped)
            {
                UnequipItem(weaponSlot[i].itemName, EquipmentType.Weapon);
                weaponSlot[i].isEquipped = false;
                weaponSlot[i].itemEquippedText.SetActive(false);
            }
        }

    }

    public void EquipItem(string equipmentName, EquipmentType equipmentType)
    {

        Debug.Log(equipmentName + "of type " + equipmentType.ToString() + " is now equipped.");

        if (equipmentType == EquipmentType.Weapon)
        {
            for (int i = 0; i < weaponSOLib.weaponSOs.Length; i++)
            {
                if (weaponSOLib.weaponSOs[i].itemName == equipmentName)
                {
                    weaponSOLib.weaponSOs[i].Equip();
                }
            }
        }
        else if (equipmentType == EquipmentType.Armor)
        {
            for (int i = 0; i < armorSOLib.armorSOs.Length; i++)
            {
                if (armorSOLib.armorSOs[i].itemName == equipmentName)
                {
                    armorSOLib.armorSOs[i].Equip();
                }
            }
        }
    }

    public void UnequipItem(string equipmentName, EquipmentType equipmentType) { 
        Debug.Log(equipmentName + "of type" + equipmentType.ToString() + " is now unequipped.");
        if (equipmentType == EquipmentType.Weapon)
        {
            for (int i = 0; i < weaponSOLib.weaponSOs.Length; i++)
            {
                if (weaponSOLib.weaponSOs[i].itemName == equipmentName)
                {
                    weaponSOLib.weaponSOs[i].UnEquip();
                }
            }
        }
        else if (equipmentType == EquipmentType.Armor)
        {
            for (int i = 0; i < armorSOLib.armorSOs.Length; i++)
            {
                if (armorSOLib.armorSOs[i].itemName == equipmentName)
                {
                    armorSOLib.armorSOs[i].UnEquip();
                }
            }

        }

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
                    return true;
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
                    return true;
                }
            }
        }
        return false;
    }
}
