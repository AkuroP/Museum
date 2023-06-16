using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMenu : MonoBehaviour
{
    public GameObject panel;
    public GameObject fxMontre;
    void Start()
    {
        
    }

    void Update()
    {
        if (gameObject.transform.eulerAngles.z <= 276f && gameObject.transform.eulerAngles.z >= 230f)
            panel.SetActive(true);
        else
            panel.SetActive(false);

        if (gameObject.transform.eulerAngles.z <= 300f && gameObject.transform.eulerAngles.z >= 205f)
        {
            fxMontre.SetActive(true);
        }
        else
        {
            
            fxMontre.SetActive(false);
        }
    }
}
