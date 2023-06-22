using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;
using UnityEngine.UI;
using JetBrains.Annotations;
using UnityEngine.Rendering;


public class Player : MonoBehaviour
{
    [Tooltip("Vision du joueur")]
    [Range(0f, 360f)]
    public float fov = 180f;
    // Start is called before the first frame update
    [SerializeField]

    private NavMeshObstacle navMeshObstacle;
    public NavMeshObstacle NavMeshObstacle { get { return navMeshObstacle; } set { navMeshObstacle = value; } }

    [SerializeField]
    private bool isInDimension = false;
    public bool IsInDimension { get { return isInDimension; } set { isInDimension = value; } }

    private DialogConfig currentDialog;
    public DialogConfig CurrentDialog { get {  return currentDialog; } set {  currentDialog = value; } }
    public Transform followDestination;

    public Sprite montreMapNorm;
    public Sprite montreMapOni;

    public Image montreMap;

    UnityEngine.XR.Interaction.Toolkit.TeleportationProvider yes;

    private void Start()
    {
        navMeshObstacle = this.GetComponent<NavMeshObstacle>();
        AudioManager.instance.PlayClipAt(AudioManager.instance.allAudio["OST_OniriqueV3Loop"], this.transform.position, AudioManager.instance.ostMixer, false, true);
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
