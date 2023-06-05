using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogConfig : MonoBehaviour
{

    //franco
    /*[System.Serializable]
    public struct SpeakerConfig
    {
        public enum POSITION
        {
            LEFT,
            MIDDLE,
            RIGHT
        }


        public POSITION position;
        public SpeakerData speakerData;

        public SpeakerDatabase database;

        public void SetPosition(POSITION newPos)
        {
            position = newPos;
        }
    }

    public List<SpeakerConfig> speakers = new();


    [System.Serializable]
    public struct SentenceConfig
    {
        [TextArea] public string sentence;
        public AudioClip audioClip;
    }

    [Header("Perso")]
    public List<SpeakerDatabase> speakerDatabase = new();

    

    [Header("Sentences")]
    public List<SentenceConfig> sentenceConfig = new();*/


    [System.Serializable]
    public struct SentenceConfig
    {

        [TextArea] public string sentence;

        public enum POSITION
        {
            LEFT,
            RIGHT
        }


        public POSITION position;

        public AudioClip audioClip;
    }

    [Header("Perso")]

    public string nameLeft;
    public string nameRight;

    public Sprite spriteLeft;
    public Sprite spriteRight;

    [Header("Sentences")]
    public List<SentenceConfig> sentenceConfig;
}
