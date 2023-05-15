using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class HMDInfoManager : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Is Device Active : " + XRSettings.isDeviceActive);
        Debug.Log("Device Name is : " + XRSettings.loadedDeviceName);

        if(XRSettings.loadedDeviceName == "MockHMD Display")
        {
            Debug.Log("No Headset. Using Mock HMD");
        }

        if (XRSettings.isDeviceActive)
            Debug.Log("Headset Plugged");
    }

    void Update()
    {
        
    }
}
