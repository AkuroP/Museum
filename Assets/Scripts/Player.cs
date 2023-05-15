using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("Vision du joueur")]
    [Range(0f, 360f)]
    public float fov = 180f;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))this.transform.Rotate(Vector3.down, 50 * Time.deltaTime);
        else if(Input.GetKey(KeyCode.RightArrow))this.transform.Rotate(Vector3.up, 50 * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        /*
            Indicate FOV of Camera
        */
        //Cercle
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, 1);
        
        //Rayon droit
        Gizmos.color = Color.red;
        Quaternion quaternion = Quaternion.AngleAxis(fov / 2, Vector3.up);
        Vector3 yes = quaternion * this.transform.forward;
        Gizmos.DrawRay(this.transform.position, yes * 10);
        
        //Rayon gauche
        Quaternion quaternion2 = Quaternion.AngleAxis(fov / 2, Vector3.down);
        Vector3 yes2 = quaternion2 * this.transform.forward;
        Gizmos.DrawRay(Camera.main.transform.position, yes2 * 10);
    }
}
