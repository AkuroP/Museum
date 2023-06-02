using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Recoltable : MonoBehaviour
{
    public InputActionProperty stacked;
    public GameObject anchor;
    public GameObject HUD;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            if (stacked.action.WasPressedThisFrame())
            {
                Debug.Log("Stacked");
                Stacking();
            }
        }
        
    }

    public void Stacking()
    {
        gameObject.SetActive(false);
        HUD.SetActive(true);
    }
}
