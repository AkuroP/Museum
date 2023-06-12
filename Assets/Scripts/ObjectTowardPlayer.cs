using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTowardPlayer : MonoBehaviour
{
    [SerializeField]
    private bool lockRotaToY;
    private void Start()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
    // Update is called once per frame
    private void Update()
    {
        this.transform.LookAt(Camera.main.transform);
        if (!lockRotaToY) return;
        this.transform.eulerAngles = new Vector3 (0, this.transform.eulerAngles.y, 0);
    }
}
