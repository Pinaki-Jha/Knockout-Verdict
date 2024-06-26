using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentsSlotScript : MonoBehaviour
{

    private InventoryManagerScript inventoryManager;
    //--item data-----//
    public string itemName;
    public Sprite itemSprite;
    public string itemDescription;
    public bool isFull;
    public bool isEquipped;
    public EquipmentType equipmentType;


    public GameObject SelectActionPanel;
    public Button equipItemButton;
    public Button dropItemButton;
    public Button backItemButton;

    //----slot data----//
    [SerializeField] private Image itemSpriteImage;
    [SerializeField] public GameObject itemButton;
    //[SerializeField] private GameObject itemButtonImage;
    //[SerializeField] private Button itemKaButton;
    public GameObject itemEquippedText;

    public Sprite defaultSpriteImage;

    public Button backButton;


    private void Start()
    {
        inventoryManager = GameObject.Find("PauseCanvas").GetComponent<InventoryManagerScript>();
        
        

        //Debug.Log(inventoryManager);
    }
    public void addItem(string itemName, Sprite itemSprite, string itemDescription, EquipmentType equipmentType) {
        
        //Debug.Log("reached here");
        this.itemName = itemName;
        //Debug.Log("reached name");
        this.itemSprite = itemSprite;
        //Debug.Log("reached sprite");
        this.itemDescription = itemDescription;
        //Debug.Log("reached description");
        this.equipmentType = equipmentType;
        //Debug.Log("reached type");


        isFull = true;
        itemButton.SetActive(true);
        //Debug.Log("reached item button");

        itemSpriteImage.sprite = itemSprite;
        //Debug.Log("reached here");



    }

    public void onItemSelected(Text itemDescriptionNameText, Text itemDescriptionDescriptionText, Image itemDescriptionImage)
    {
        itemDescriptionNameText.text = itemName;
        itemDescriptionDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = itemSprite;
    }

    public void itemEquipToggle()
    {
        
        
        if (isEquipped) 
        {
            isEquipped = false;
            itemEquippedText.SetActive(false);
            inventoryManager.UnequipItem(itemName, equipmentType);
            SelectActionPanel.SetActive(false);
            itemButton.GetComponent<Button>().Select();


        } else {
            if (equipmentType ==EquipmentType.Armor) { inventoryManager.UnequipAllArmors(); }
            else { inventoryManager.UnequipAllWeapons(); }
            inventoryManager.EquipItem(itemName, equipmentType);
            isEquipped = true;

            itemEquippedText.SetActive(true);

            SelectActionPanel.SetActive(false);
            itemButton.GetComponent<Button>().Select();
        }

    }


    public void ActionPanelActivate() { 
        SelectActionPanel.SetActive(true);
        equipItemButton.Select();

        equipItemButton.onClick.RemoveAllListeners();
        dropItemButton.onClick.RemoveAllListeners();
        backItemButton.onClick.RemoveAllListeners();


        equipItemButton.onClick.AddListener(itemEquipToggle);
        dropItemButton.onClick.AddListener(DropItem);
        backItemButton.onClick.AddListener(BackItem);



    }
    public void DropItem() 
    {
        SelectActionPanel.SetActive(false);
        isFull = false;
        isEquipped = false;
        itemEquippedText.SetActive(false);
        itemButton.SetActive(false);
        itemSpriteImage.sprite = defaultSpriteImage;
        backButton.Select();
    }
    

    public void BackItem() { 
        SelectActionPanel.SetActive(false);
        itemButton.GetComponent<Button>().Select();
    }
    
}
