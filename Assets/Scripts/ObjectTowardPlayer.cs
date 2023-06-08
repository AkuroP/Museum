using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTowardPlayer : MonoBehaviour
{
    private void Start()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
    // Update is called once per frame
    private void Update()
    {
        this.transform.LookAt(Camera.main.transform);

    }
}
