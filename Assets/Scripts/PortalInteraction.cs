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

    private Vector3 r_portalInitialPos;
    private Vector3 l_portalInitialPos;

    [SerializeField]
    private Transform rHand;
    [SerializeField]
    private Transform lHand;


    [SerializeField]
    private bool r_IsGrabbing;
    [SerializeField]
    private bool l_IsGrabbing;

    [Tooltip("90/270° = true, 0/180° = false")]
    [SerializeField]
    private bool horizontalDir;
    
    [SerializeField]
    private Material nextWorldSkyBoxMat;

    private Player player;

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

    private void Start()
    {
        lHand = Camera.main.transform.parent.GetChild(1);
        rHand = Camera.main.transform.parent.GetChild(2);
        r_portalInitialPos = r_InterActualPos.transform.position;
        l_portalInitialPos = l_InterActualPos.transform.position;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

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
        if(horizontalDir)l_InterActualPos.transform.position = new Vector3(l_InterActualPos.transform.position.x, l_InterActualPos.transform.position.y, lHand.transform.position.z);
        else l_InterActualPos.transform.position = new Vector3(lHand.transform.position.x, l_InterActualPos.transform.position.y, l_InterActualPos.transform.position.z);
    }
    private void RTrackHand()
    {
        if (!r_IsGrabbing) return;
        if (horizontalDir) r_InterActualPos.transform.position = new Vector3(r_InterActualPos.transform.position.x, r_InterActualPos.transform.position.y, rHand.transform.position.z);
        else r_InterActualPos.transform.position = new Vector3(rHand.transform.position.x, r_InterActualPos.transform.position.y, r_InterActualPos.transform.position.z);
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
        r_InterActualPos.GetComponent<MeshRenderer>().enabled = false;
        l_InterActualPos.GetComponent<MeshRenderer>().enabled = false;
        portalOpen = true;
        yield return new WaitForSeconds(time);
        RenderSettings.skybox = nextWorldSkyBoxMat;
        r_InterActualPos.GetComponent<MeshRenderer>().enabled = true;
        l_InterActualPos.GetComponent<MeshRenderer>().enabled = true;
        player.IsInDimension = !player.IsInDimension;
        centerPortal.Stop();
        startingWorld.SetActive(false);
        destinationWorld.SetActive(true);
        portalOpen = false;
        portal.localScale = portalInitialScale;
        
        //reset portal pos
        r_InterActualPos.transform.position = r_portalInitialPos;
        l_InterActualPos.transform.position = l_portalInitialPos;
    }

}

