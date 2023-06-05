using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    /*public Text txtNameLeft;
    public Text txtNameRight;
    public Image imgSpriteLeft;
    public Image imgSpriteRight;

    public Text txtSentence;

    public int _idCurrentSentence = 0;

    public DialogConfig _dialog;
    public AudioSource _audioSource;

    private void OnEnable()
    {
        if(_dialog == null)return;
        PlayDialog(_dialog);
    }


    public void PlayDialog(DialogConfig actualDialog)
    {
        //stop time
        Time.timeScale = 1f;
    
        //activate dialog
        gameObject.SetActive(true);

        txtNameLeft.text = actualDialog.nameLeft;
        imgSpriteLeft.sprite = actualDialog.spriteLeft;

        txtNameRight.text = actualDialog.nameRight;
        imgSpriteRight.sprite = actualDialog.spriteRight;

        RefreshBox();
    }

    //refresh box franco
    private void RefreshBox()
    {
        DialogConfig.SentenceConfig sentence = _dialog.sentenceConfig[_idCurrentSentence];
        DialogConfig.SpeakerConfig speaker = _dialog.speakers[0];

        switch(speaker.position)
        {
            case DialogConfig.SpeakerConfig.POSITION.LEFT :
                txtNameLeft.color = Color.white;
                txtNameRight.color = Color.clear;

                imgSpriteLeft.color = Color.white;
                imgSpriteRight.color = Color.gray;
            break;

            case DialogConfig.SpeakerConfig.POSITION.RIGHT :
                txtNameLeft.color = Color.clear;
                txtNameRight.color = Color.white;

                imgSpriteLeft.color = Color.gray;
                imgSpriteRight.color = Color.white;
            break;
        }

        txtSentence.text = sentence.sentence;

        //stop actual audio
        if(_audioSource == null)return;
        _audioSource.Stop();
        
        //set next audio
        _audioSource.clip = sentence.audioClip;
        
        //play next audio
        _audioSource.Play();
    }

    private void RefreshBox()
    {
        DialogConfig.SentenceConfig sentence = _dialog.sentenceConfig[_idCurrentSentence];

        switch(sentence.position)
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
        }

        txtSentence.text = sentence.sentence;

        //stop actual audio
        if(_audioSource == null)return;
        _audioSource.Stop();
        
        //set next audio
        _audioSource.clip = sentence.audioClip;
        
        //play next audio
        _audioSource.Play();
    }

    public void NextSentence()
    {
        if(_dialog == null)return;
        _idCurrentSentence++;

        if(_idCurrentSentence < _dialog.sentenceConfig.Count)RefreshBox();
        else CloseDialog();
    }

    public void CloseDialog()
    {
        //resume time
        Time.timeScale = 0f;

        //reset dialog var and close gameobject
        this.gameObject.SetActive(false);
        _idCurrentSentence = 0;
        _dialog = null;
    }*/

     public Text txtNameLeft;
    public Text txtNameRight;
    public Image imgSpriteLeft;
    public Image imgSpriteRight;

    public Text txtSentence;

    public int _idCurrentSentence = 0;

    public DialogConfig _dialog;
    public AudioSource _audioSource;

    private void OnEnable()
    {
        if(_dialog == null)return;
        PlayDialog(_dialog);
    }


    public void PlayDialog(DialogConfig actualDialog)
    {
        //stop time
        Time.timeScale = 1f;
    
        //activate dialog
        gameObject.SetActive(true);

        txtNameLeft.text = actualDialog.nameLeft;
        imgSpriteLeft.sprite = actualDialog.spriteLeft;

        txtNameRight.text = actualDialog.nameRight;
        imgSpriteRight.sprite = actualDialog.spriteRight;

        RefreshBox();
    }

    private void RefreshBox()
    {
        DialogConfig.SentenceConfig sentence = _dialog.sentenceConfig[_idCurrentSentence];

        switch(sentence.position)
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
        }

        txtSentence.text = sentence.sentence;

        //stop actual audio
        if(_audioSource == null)return;
        _audioSource.Stop();
        
        //set next audio
        _audioSource.clip = sentence.audioClip;
        
        //play next audio
        _audioSource.Play();
    }

    public void NextSentence()
    {
        if(_dialog == null)return;
        _idCurrentSentence++;

        if(_idCurrentSentence < _dialog.sentenceConfig.Count)RefreshBox();
        else CloseDialog();
    }

    public void CloseDialog()
    {
        //resume time
        Time.timeScale = 0f;

        //reset dialog var and close gameobject
        this.gameObject.SetActive(false);
        _idCurrentSentence = 0;
        _dialog = null;
    }

}
