using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class Player : MonoBehaviour
{
    [Tooltip("Vision du joueur")]
    [Range(0f, 360f)]
    public float fov = 180f;
    // Start is called before the first frame update
    [SerializeField]

    private NavMeshAgent navMeshAgent;
    public NavMeshAgent NavMeshAgent { get { return navMeshAgent; } set { navMeshAgent = value; } }

    [SerializeField]
    private bool isInDimension = false;
    public bool IsInDimension { get { return isInDimension; } set { isInDimension = value; } }

    private DialogConfig currentDialog;
    public DialogConfig CurrentDialog { get {  return currentDialog; } set {  currentDialog = value; } }

    private void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        
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
