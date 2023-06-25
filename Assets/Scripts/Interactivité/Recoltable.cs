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
    [SerializeField] Entity entityPlayDialog;
    [SerializeField] DialogController dialogController;
    [System.Serializable]
    public struct EntitiesConcerned
    {
        public Entity entity;
        public int idToGoIfPicked;

    }
    public EntitiesConcerned[] entitiesConcerned;
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

    /*private void OnTriggerStay(Collider other)
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
        
    }*/

    public void Stacking()
    {
        fxRecolte.Play();
        
        GameObject egg = questCanvas.GetComponentInChildren<RectTransform>().Find(number).gameObject;
        eggs = egg;
        AudioManager.instance.PlayClipAt(AudioManager.instance.allAudio["SFX_GrabItem"], this.transform.position, AudioManager.instance.soundEffectMixer, true, false, 1, 1, 360, 1, 10f);
        gameObject.SetActive(false);
        eggs.GetComponent<Image>().sprite = oeufSprite;
        eggs.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f );

        foreach(EntitiesConcerned entityConcerned in entitiesConcerned)
        {
            dialogController.ChangeIDDialogTo(entityConcerned.idToGoIfPicked, returnToPreviousId, entityConcerned.entity);
        }
        if (playDialog)dialogController.PlayDialog(entityPlayDialog);
        // alpha.a = 255f;
    }
}
