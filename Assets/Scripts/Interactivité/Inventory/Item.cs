using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Item : MonoBehaviour
{
    public bool inSlot;
    public Vector3 slotRotation = Vector3.zero;
    public Slot currentSlot;
    public InputActionProperty grabRelease;

    private void OnTriggerStay(Collider other)
    {
        if (inSlot && other.CompareTag("Hand"))
        {
            if (grabRelease.action.WasPressedThisFrame())
            {
            Debug.Log("frite");
            Grabbed();
            }
        }
    }
    public void Grabbed()
    {
        if (inSlot)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            //gameObject.GetComponentInParent<Slot>().itemInSlot = null;
            gameObject.transform.parent = null;
            inSlot = false;
            currentSlot.ResetColor();
            currentSlot = null;
        }
    }
}
