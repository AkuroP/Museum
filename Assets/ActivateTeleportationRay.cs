using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class ActivateTeleportationRay : MonoBehaviour
{
    [SerializeField] GameObject leftRay;
    [SerializeField] GameObject rightRay;

    [SerializeField] InputActionProperty leftActivate;
    [SerializeField] InputActionProperty rightActivate;

    [SerializeField] InputActionProperty leftCancel;
    [SerializeField] InputActionProperty rightCancel;

    [SerializeField] InputActionReference primary;
    [SerializeField] bool canTP;
    [SerializeField] XRRayInteractor LeftTP;
    [SerializeField] XRRayInteractor RightTP;

    //public InputActionProperty grab;
    private void Awake()
    {
        canTP = true;
    }

    void Update()
    {
        leftRay.SetActive(leftCancel.action.ReadValue<float>() < 0.1f && leftActivate.action.ReadValue<float>() > 0.1f);

        rightRay.SetActive(rightCancel.action.ReadValue<float>() < 0.1f && rightActivate.action.ReadValue<float>() > 0.1f);

        if (primary.action.WasPressedThisFrame())
        {
            Debug.Log("Primary");
            canTP = !canTP;
        }

        if (!canTP)
        {
            LeftTP.enabled = false;
            RightTP.enabled = false;
        }
        else
        {
            LeftTP.enabled = true;
            RightTP.enabled = true;
        }
           
    }
}

