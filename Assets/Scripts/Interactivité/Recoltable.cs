using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Recoltable : MonoBehaviour
{
    [SerializeField] InputActionProperty stacked;
    [SerializeField] GameObject questCanvas;
    [SerializeField] GameObject eggs;
    [SerializeField] Sprite oeufSprite;
    [SerializeField] string number;

    [Space]
    [Header("Dialog")]
    //Phrase selon bon oeuf oupa
    [SerializeField] bool playDialog;
    [SerializeField] DialogController dialogController;
    [SerializeField] Entity entity;
    [SerializeField] int idToGoIfPicked;
    [SerializeField] bool returnToPreviousId;
    [Tooltip("retourne à ID precise si valeur positive")]
    [SerializeField] int returnToSpecificId = -1;

    [Header("FX")]
    [SerializeField] ParticleSystem fxRecolte;

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            if (stacked.action.WasPressedThisFrame())
            {
                fxRecolte.Play();
                Stacking();
                if (!playDialog) return;
                dialogController.ChangeIDDialogTo(idToGoIfPicked, returnToPreviousId, entity);
            }
        }
        
    }

    public void Stacking()
    {
        GameObject egg = questCanvas.GetComponentInChildren<RectTransform>().Find(number).gameObject;
        eggs = egg;
        gameObject.SetActive(false);
        eggs.GetComponent<Image>().sprite = oeufSprite;
        eggs.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f );
       // alpha.a = 255f;
    }
}
