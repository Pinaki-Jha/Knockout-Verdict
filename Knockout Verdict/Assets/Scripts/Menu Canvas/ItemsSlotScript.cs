using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemsSlotScript : MonoBehaviour
{

    private InventoryManagerScript inventoryManager;
    //--item data-----//
    public string itemName;
    public Sprite itemSprite;
    public string itemDescription;
    public bool isFull;


    public GameObject SelectActionPanel;
    public Button useItemButton;
    public Button dropItemButton;
    public Button backItemButton;

    //----slot data----//
    [SerializeField] private Image itemSpriteImage;
    [SerializeField] public GameObject itemButton;
    //[SerializeField] private GameObject itemButtonImage;
    //[SerializeField] private Button itemKaButton;

    public Sprite defaultSpriteImage;

    public Button backButton;


    private void Start()
    {
        inventoryManager = GameObject.Find("PauseCanvas").GetComponent<InventoryManagerScript>();
        
        

        //Debug.Log(inventoryManager);
    }
    public void addItem(string itemName, Sprite itemSprite, string itemDescription, EquipmentType equipmentType) {
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        this.itemDescription = itemDescription;

        
        isFull = true;
        itemButton.SetActive(true);

        itemSpriteImage.sprite = itemSprite;
        


    }

    public void onItemSelected(Text itemDescriptionNameText, Text itemDescriptionDescriptionText, Image itemDescriptionImage)
    {
        itemDescriptionNameText.text = itemName;
        itemDescriptionDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = itemSprite;
    }

   

    public void ActionPanelActivate() { 
        SelectActionPanel.SetActive(true);
        useItemButton.Select();

        useItemButton.onClick.AddListener(UseItem);
        dropItemButton.onClick.AddListener(DropItem);
        backItemButton.onClick.AddListener(BackItem);



    }
    public void DropItem() 
    {
        SelectActionPanel.SetActive(false);
        isFull = false;
        itemButton.SetActive(false);
        itemSpriteImage.sprite = defaultSpriteImage;
        backButton.Select();
    }
    public void UseItem() 
    {
        SelectActionPanel.SetActive(false);
        inventoryManager.UseItem(itemName);
        isFull = false;
        itemButton.SetActive(false);
        itemSpriteImage.sprite = defaultSpriteImage;
        backButton.Select();   
    }

    public void BackItem() { 
        SelectActionPanel.SetActive(false);
        itemButton.GetComponent<Button>().Select();
    }
    
}
