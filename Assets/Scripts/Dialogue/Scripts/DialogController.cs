using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using static UnityEngine.EventSystems.EventTrigger;
using System.Security.Permissions;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Rendering;

public class DialogController : MonoBehaviour
{

    //public Text txtSentence;

    public int _idCurrentSentence = 0;

    public DialogConfig _dialog;
    public AudioSource _audioSource;
    [SerializeField] InputActionReference skipDialogInput;
    private InputAction nextDialog;

    private Entity entityConcerned;

    private Player player;

    [SerializeField]
    private Material normalMat;
    [SerializeField]
    private Material dimensionMat;

    [Header("Movements")]
    [SerializeField] ActionBasedContinuousMoveProvider moveS;

    [SerializeField]
    private bool canTalk;
    private bool onTalk;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    } 

    private void OnEnable()
    {
        //if(_dialog == null)return;
        //PlayDialog(_dialog);
        nextDialog = skipDialogInput;
        nextDialog.Enable();
        nextDialog.performed += NextDialog;
    }

    private void OnDisable()
    {
        nextDialog.Disable();
    }

    public void PointerGetEntity(Entity entity)
    {
        canTalk = true;
        entityConcerned = entity;
    }

    public void PointerClearEntity()
    {
        canTalk = false;
        if(!onTalk)entityConcerned = null;
    }

    public void VRPlayDialog()
    {
        if (!canTalk || entityConcerned == null) return;
        PlayDialog(entityConcerned);
    }


    public void PlayDialog(Entity entity)
    {
        onTalk = true;
        if (entity == null) return;
        _dialog = entity.EntityDialog[entity.CurrentDialogAdvancement];
        if (player.CurrentDialog == null) return;
        
        CloseDialog();
        player.CurrentDialog = null;

        if(entityConcerned == null)entityConcerned = entity;
        
        //stop time
        //Time.timeScale = 1f;
    
        //activate dialog
        gameObject.SetActive(true);

        _dialog.firstCharTxt.transform.parent.gameObject.SetActive(true);
        /*txtNameLeft.text = actualDialog.nameLeft;
        imgSpriteLeft.sprite = actualDialog.spriteLeft;

        txtNameRight.text = actualDialog.nameRight;
        imgSpriteRight.sprite = actualDialog.spriteRight;*/
        RefreshBox();
    }

    private void RefreshBox()
    {
        DialogConfig.SentenceConfig sentence = _dialog.sentenceConfig[_idCurrentSentence];

        /*switch(sentence.position)
        {
            case DialogConfig.SentenceConfig.POSITION.LEFT :
                txtNameLeft.color = Color.white;
                txtNameRight.color = Color.clear;

                imgSpriteLeft.color = Color.white;
                imgSpriteRight.color = Color.gray;
            break;

            case DialogConfig.SentenceConfig.POSITION.RIGHT :
                txtNameLeft.color = Color.clear;
                txtNameRight.color = Color.white;

                imgSpriteLeft.color = Color.gray;
                imgSpriteRight.color = Color.white;
            break;
        }*/

        switch(sentence.whoTalk)
        {
            case DialogConfig.SentenceConfig.CHARACTER.FIRSTCHAR:
                _dialog.firstCharTxt.transform.parent.gameObject.SetActive(true);
                
                _dialog.firstCharTxt.text = sentence.sentence;
                if(player.IsInDimension)_dialog.firstCharTxt.transform.parent.GetComponent<Renderer>().material = dimensionMat;
                else _dialog.firstCharTxt.transform.parent.GetComponent<Renderer>().material = normalMat;
                //Debug.Log(_dialog.firstCharTxt.transform.parent.name);

                if (_dialog.secondCharTxt != null) _dialog.secondCharTxt.transform.parent.gameObject.SetActive(false);
            break;
            case DialogConfig.SentenceConfig.CHARACTER.SECONDCHAR:
                _dialog.secondCharTxt.transform.parent.gameObject.SetActive(true);

                _dialog.secondCharTxt.text = sentence.sentence;
                if (player.IsInDimension) _dialog.secondCharTxt.transform.parent.GetComponent<Renderer>().material = normalMat;
                else _dialog.secondCharTxt.transform.parent.GetComponent<Renderer>().material = dimensionMat;
                

                if(_dialog.firstCharTxt != null) _dialog.firstCharTxt.transform.parent.gameObject.SetActive(false);
                
        break;
        }

        if(sentence.animName.Length > 0)
        {
            switch(sentence.animType)
            {
                case DialogConfig.SentenceConfig.AnimType.FLOAT:
                    sentence.animator.SetFloat(sentence.animName, sentence.floatValue);
                break;

                case DialogConfig.SentenceConfig.AnimType.INT:
                    sentence.animator.SetInteger(sentence.animName, sentence.intValue);
                break;

                case DialogConfig.SentenceConfig.AnimType.BOOL:
                    sentence.animator.SetBool(sentence.animName, sentence.boolValue);
                break;
                case DialogConfig.SentenceConfig.AnimType.TRIGGER:
                    sentence.animator.SetTrigger(sentence.animName);
                break;
            }
        }

        //stop actual audio
        if (sentence.sfx == null) return;
       
        AudioManager.instance.PlayClipAt(AudioManager.instance.allAudio[sentence.sfx.name], entityConcerned.transform.position, AudioManager.instance.soundEffectMixer, true, false, 1, 1, 360, 1, 10f);
        //Debug.Log("YYE");
    }

    public void NextSentence()
    {
        if(_dialog == null)return;
        _idCurrentSentence++;
        
        if (_idCurrentSentence < _dialog.sentenceConfig.Count) RefreshBox();
        else CloseDialog();


    }

    public void CloseDialog()
    {
        onTalk = false;
        foreach (DialogConfig.SentenceConfig.DialogEntitiesConcerned entity in _dialog.sentenceConfig[_dialog.sentenceConfig.Count - 1].entities)
        {
            if (_dialog.sentenceConfig[_dialog.sentenceConfig.Count - 1].increment)entity.entity.CurrentDialogAdvancement = entity.entitiesGoToID - 1;
        }

        //resume time
        //Time.timeScale = 0f;
        //reset dialog var and close gameobject
        //this.gameObject.SetActive(false);

        moveS.moveSpeed = 5;
        _dialog.firstCharTxt.transform.parent.gameObject.SetActive(false);
        if(_dialog.secondCharTxt != null) _dialog.secondCharTxt.transform.parent.gameObject.SetActive(false);
        if(_dialog.sentenceConfig[_dialog.sentenceConfig.Count - 1].playNextDialog)
        {
            PlayDialog(entityConcerned);
            return;
        }
        _idCurrentSentence = 0;
        entityConcerned = null;
        _dialog = null;
    }

    public void NextDialog(InputAction.CallbackContext ctx)
    {
        if (_dialog == null && canTalk && !onTalk)
        {
            VRPlayDialog();
            return;
        }
        else if(_dialog == null && !canTalk && onTalk) return;
        NextSentence();

    }

    public void ChangeIDDialogTo(int idToGo, bool returnToPreviousId, Entity entity, int returnToSpecificId = -1)
    {
        int localID = entity.CurrentDialogAdvancement;

        entity.CurrentDialogAdvancement = idToGo;
        PlayDialog(entity);
        if(returnToPreviousId)entity.CurrentDialogAdvancement = localID;
        if (returnToSpecificId > -1) entity.CurrentDialogAdvancement = returnToSpecificId;
    }

}
