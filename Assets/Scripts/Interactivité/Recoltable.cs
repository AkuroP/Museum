using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Recoltable : MonoBehaviour
{
    [SerializeField] InputActionProperty stacked;
    [SerializeField] GameObject questCanvas;
    [SerializeField] GameObject eggs;
    [SerializeField] Sprite oeufSprite;
    [SerializeField] string number;
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
                Stacking();
            }
        }
        
    }

    public void Stacking()
    {
        GameObject egg = questCanvas.GetComponentInChildren<RectTransform>().Find(number).gameObject;
        eggs = egg;
        gameObject.SetActive(false);
        eggs.GetComponent<Image>().sprite = oeufSprite;
    }
}
