using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMenu : MonoBehaviour
{
    public GameObject panel;
    void Start()
    {
        
    }

    void Update()
    {
        if (gameObject.transform.eulerAngles.z <= 276f && gameObject.transform.eulerAngles.z >= 252f)
        {
            panel.SetActive(true);
        }
        else
            panel.SetActive(false);
    }
}
