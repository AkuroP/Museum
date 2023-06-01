using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Slot : MonoBehaviour
{
    public InputActionProperty grab;
    public GameObject itemInSlot;
    public Image slotImage;
    Color originalColor;

    void Start()
    {
        slotImage = GetComponentInChildren<Image>();
        originalColor = slotImage.color;
    }

    private void OnTriggerStay(Collider other)
    {
        if (itemInSlot != null) return;
        GameObject obj = other.gameObject;
        if (!isItem(obj)) return;
        if (grab.action.ReadValue<float>() > 0f)
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

    }

    public void ResetColor()
    {
        slotImage.color = originalColor;
    }
}
