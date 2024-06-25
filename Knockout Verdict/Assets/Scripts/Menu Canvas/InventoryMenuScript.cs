using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject superMenu;
    [SerializeField] private Button resume;
    [SerializeField] private Button back;
    


    void Awake()
    {
        back.Select();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void exitInventoryMenu()
    {
        superMenu.SetActive(true);
        resume.Select();
        gameObject.SetActive(false);

    }

}
