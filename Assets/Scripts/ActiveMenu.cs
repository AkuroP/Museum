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
        {
            panel.SetActive(true);
            fxMontre.SetActive(true);

        }
        else
        {
            panel.SetActive(false);
            fxMontre.SetActive(false);
        }
    }
}
