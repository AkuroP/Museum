using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialog : MonoBehaviour
{
    //controller de dialogue
    [SerializeField]
    private DialogController dialogController;

    [SerializeField]
    private Entity entity;

    //timer
    private float timer;
    [SerializeField]
    private float maxTimer;

    //type d'interaction
    public enum InteractionType
    {
        TRIGGER_ENTER,
        TRIGGER_EXIT,
        TIMER
    }

    [SerializeField]
    private InteractionType interactionType;

    [SerializeField]
    private DialogConfig dialogConcerned;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Collider>().isTrigger = true;        
    }

    // Update is called once per frame
    void Update()
    {

        if (interactionType != InteractionType.TIMER) return;
        TimerInteraction();
    }

    private void TimerInteraction()
    {
        if (timer >= maxTimer)
        {
            dialogController._dialog = dialogConcerned;
            dialogController.PlayDialog(entity);
            this.gameObject.SetActive(false);
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (interactionType != InteractionType.TRIGGER_ENTER) return;
        dialogController._dialog = dialogConcerned;
       
        entity.CurrentDialogAdvancement = entity.EntityDialog.FindIndex(it => it.Equals(dialogConcerned));
        //Debug.Log(entity.CurrentDialogAdvancement);
        
        dialogController.PlayDialog(entity);
        this.gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (interactionType != InteractionType.TRIGGER_EXIT) return;
        entity.DialogController._dialog = dialogConcerned;
        entity.DialogController.PlayDialog(entity);
        this.gameObject.SetActive(false);

    }
}
