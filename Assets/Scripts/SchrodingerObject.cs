using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchrodingerObject : MonoBehaviour
{
    private Vector3 dir;
    private Renderer ObjectRenderer;
    private Collider col;
    private Player player;
    public bool deactiveCollider = true;

    // Start is called before the first frame update
    private void Start()
    {
        ObjectRenderer = this.GetComponent<Renderer>();
        col = this.GetComponent<Collider>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        //calculate direction of object
        dir = this.transform.position - Camera.main.transform.position;

        /*
            Active Object renderer in Camera view
        */

        //if(!ObjectRenderer.enabled)return;
        if(Vector3.Angle(dir, Camera.main.transform.forward) > player.fov)
        {
            ObjectRenderer.enabled = true;
            if(deactiveCollider && col != null)col.enabled = true;
        
        }

        /*
            Deactive object renderer when not in camera view 
        */
        if(Vector3.Angle(dir, Camera.main.transform.forward) > player.fov)
        {
            if(ObjectRenderer.isVisible)return;
            ObjectRenderer.enabled = false;
            if(deactiveCollider && col != null)col.enabled = false;
        }
        else
        {
            ObjectRenderer.enabled = true;
            if(deactiveCollider && col != null)col.enabled = true;

        }
    }

    private void OnBecameInvisible()
    {
        Debug.Log($"{this.name} became invisible");
        //ObjectRenderer.enabled = false;
    }

    private void OnBecameVisible()
    {
        Debug.Log($"{this.name} became visible !");
        //ObjectRenderer.enabled = true;
    }
}
