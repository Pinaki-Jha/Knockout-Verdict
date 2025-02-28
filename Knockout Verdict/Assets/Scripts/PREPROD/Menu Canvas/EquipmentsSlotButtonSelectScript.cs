using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentsSlotButtonSelectScript : MonoBehaviour, ISelectHandler
{

    //----item description data
    public Image equipmentDescriptionImage;
    public Text equipmentDescriptionNameText;
    public Text equipmentDescriptionDescriptionText;

    [SerializeField] private EquipmentsSlotScript equipmentsSlot;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect(BaseEventData eventData)
    {
        equipmentsSlot.onItemSelected(equipmentDescriptionNameText, equipmentDescriptionDescriptionText, equipmentDescriptionImage);
    }

    
}
