using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject InventoryVR;
    [SerializeField] GameObject Anchor;
    [SerializeField] bool openInvent;

    private void Start()
    {
        InventoryVR.SetActive(false);
    }

    private void Update()
    {
        if (openInvent)
        {
            InventoryVR.SetActive(true);
            InventoryVR.transform.position = Anchor.transform.position;
            InventoryVR.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);

        }
        else
            InventoryVR.SetActive(false);
    }

    public void OpenInventory()
    {
        openInvent = true;     
    }

    public void QuitInventory()
    {
        openInvent = false;
    }
}