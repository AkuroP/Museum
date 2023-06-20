using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogConfig : MonoBehaviour
{


    [System.Serializable]
    public struct SentenceConfig
    {

        [TextArea] public string sentence;

        public enum CHARACTER
        {
            FIRSTCHAR,
            SECONDCHAR
        }


        public CHARACTER whoTalk;

        public AudioClip sfx;

        public bool increment;

        [System.Serializable]
        public struct DialogEntitiesConcerned
        {
            public Entity entity;
            public int entitiesGoToID;
        }

        public DialogEntitiesConcerned[] entities;

        public bool playNextDialog;

        [Space]
        [Header("Animation")]
        public Animator animator;
        public string animName;
        public enum AnimType
        {
            FLOAT,
            INT,
            BOOL,
            TRIGGER
        }

        public AnimType animType;

        public float floatValue;
        public int intValue;
        public bool boolValue;


        //public TextMeshPro txtChar;
    }

    [Header("Perso")]

    public string nameFirstChar;
    public string nameSecondChar;

    public TextMeshPro firstCharTxt;
    public TextMeshPro secondCharTxt;

    /*public TextMeshPro txtFirstChar;
    public TextMeshPro txtSecondChar;*/

    [Header("Sentences")]
    public List<SentenceConfig> sentenceConfig;
}
