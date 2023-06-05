using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Slot : MonoBehaviour
{
    [SerializeField] InputActionProperty grab;
    [SerializeField] GameObject itemInSlot;
    [SerializeField] Image slotImage;
    Color originalColor;

    [SerializeField] bool stacked;

    void Start()
    {
        slotImage = GetComponentInChildren<Image>();
        originalColor = slotImage.color;
        stacked = false;
    }

    private void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (itemInSlot != null) return;
        GameObject obj = other.gameObject;
       
        if (!isItem(obj)) return;
        
        if (grab.action.WasReleasedThisFrame())
        {
            insertItem(obj);
        }
        
    }
    bool isItem(GameObject obj)
    {
        return obj.GetComponent<Item>();
    }

    void insertItem(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.SetParent(gameObject.transform, true);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localEulerAngles = obj.GetComponent<Item>().slotRotation;
        obj.GetComponent<Item>().inSlot = true;
        obj.GetComponent<Item>().currentSlot = this;
        itemInSlot = obj;
        slotImage.color = Color.gray;
        stacked = true;

    }

    void pickupItem(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = false;
        obj.GetComponent<Item>().inSlot = false;
        obj.GetComponent<Item>().currentSlot = null;
        itemInSlot = null;
        slotImage.color = originalColor;
        stacked = false;

    }

    public void ResetColor()
    {
        slotImage.color = originalColor;
    }
}
