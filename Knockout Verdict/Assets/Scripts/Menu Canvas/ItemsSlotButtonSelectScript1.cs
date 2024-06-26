using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemsSlotButtonSelectScript : MonoBehaviour, ISelectHandler
{

    //----item description data
    public Image itemDescriptionImage;
    public Text itemDescriptionNameText;
    public Text itemDescriptionDescriptionText;

    [SerializeField] private ItemsSlotScript itemsSlot;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect(BaseEventData eventData)
    {
        itemsSlot.onItemSelected(itemDescriptionNameText, itemDescriptionDescriptionText, itemDescriptionImage);
    }

    
}
