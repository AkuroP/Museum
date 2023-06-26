using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetourDebut : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")other.transform.position = Vector3.zero;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") other.transform.position = Vector3.zero;
    }
}
