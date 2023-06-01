using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class ActivateTeleportationRay : MonoBehaviour
{
        public GameObject leftRay;
        public GameObject rightRay;

        public InputActionProperty leftActivate;
        public InputActionProperty rightActivate;

        public InputActionProperty leftCancel;
        public InputActionProperty rightCancel;

        //public InputActionProperty grab;

       void Update()
       {
            leftRay.SetActive(leftCancel.action.ReadValue<float>() < 0.1f && leftActivate.action.ReadValue<float>() > 0.1f);

            rightRay.SetActive(rightCancel.action.ReadValue<float>() < 0.1f && rightActivate.action.ReadValue<float>() > 0.1f);

            /*if(grab.action.ReadValue<float>() > 0.1f)
            {
            Debug.Log("grabbed");
            }*/
       }
}

