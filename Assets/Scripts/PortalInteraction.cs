using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PortalInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject linkedPortal;

    [SerializeField]
    private GameObject startingWorld;

    [SerializeField]
    private GameObject destinationWorld;

    [SerializeField]
    private GameObject l_InterMaxPos;
    [SerializeField]
    private GameObject l_InterMinPos;
    [SerializeField]
    private GameObject l_InterActualPos;



    [SerializeField]
    private GameObject r_InterMaxPos;
    [SerializeField]
    private GameObject r_InterMinPos;
    [SerializeField]
    private GameObject r_InterActualPos;
    

    [SerializeField]
    private bool portalOpen;

    [SerializeField]
    private ParticleSystem centerPortal;

    [SerializeField]
    private Transform portal;

    [SerializeField]
    private Vector3 portalInitialScale;
    [SerializeField]
    private Vector3 portalTargetScale;

    [SerializeField]
    private Transform rHand;
    [SerializeField]
    private Transform lHand;


    [SerializeField]
    private bool r_IsGrabbing;
    [SerializeField]
    private bool l_IsGrabbing;

    public void LOnRelease()
    {
        l_IsGrabbing = false;
    }

    public void LOnGrab()
    {
        l_IsGrabbing = true;
    }

    public void ROnRelease()
    {
        r_IsGrabbing = false;
    }

    public void ROnGrab()
    {
        r_IsGrabbing = true;
    }

    private void Update()
    {
        LTrackHand();
        RTrackHand();
        Open_Portal();
    }

    private void LTrackHand()
    {
        if (!l_IsGrabbing) return;
        l_InterActualPos.transform.position = new Vector3(lHand.position.x, l_InterActualPos.transform.position.y, l_InterActualPos.transform.position.z);
    }
    private void RTrackHand()
    {
        if (!r_IsGrabbing) return;
        r_InterActualPos.transform.position = new Vector3(rHand.position.x, r_InterActualPos.transform.position.y, r_InterActualPos.transform.position.z);
    }


    private void Open_Portal()
    {
        if (!r_IsGrabbing || !l_IsGrabbing) return;
        if (portalOpen) return;

        if(portal.localScale.x >= portalTargetScale.x)
        {
            centerPortal.Play();
            StartCoroutine(DimensionChange(5f));
            return;
        }
        else portal.localScale = new Vector3(Vector3.Distance(r_InterMinPos.transform.position, r_InterActualPos.transform.position) * this.transform.localScale.x, portal.localScale.y, portal.localScale.z);
        
    }
    public IEnumerator DimensionChange(float time)
    {
        r_InterActualPos.transform.position = new Vector3(r_InterMinPos.transform.position.x + 0.01f, r_InterMinPos.transform.position.y, r_InterMinPos.transform.position.z);
        l_InterActualPos.transform.position = new Vector3(l_InterMinPos.transform.position.x - 0.01f, l_InterMinPos.transform.position.y, l_InterMinPos.transform.position.z);
        r_InterActualPos.GetComponent<MeshRenderer>().enabled = false;
        l_InterActualPos.GetComponent<MeshRenderer>().enabled = false;
        portalOpen = true;
        yield return new WaitForSeconds(time);
        r_InterActualPos.GetComponent<MeshRenderer>().enabled = true;
        l_InterActualPos.GetComponent<MeshRenderer>().enabled = true;
        centerPortal.Stop();
        startingWorld.SetActive(false);
        destinationWorld.SetActive(true);
        portalOpen = false;
        portal.localScale = portalInitialScale;
    }

}

