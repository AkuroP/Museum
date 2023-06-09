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

        public Material dialogMat;

        public bool increment;

        //public TextMeshPro txtChar;
    }

    [Header("Perso")]

    public string nameFirstChar;
    public string nameSecondChar;

    public TextMeshPro firstCharTxt;
    public TextMeshPro secondCharTxt;

    public bool onDialog;

    /*public TextMeshPro txtFirstChar;
    public TextMeshPro txtSecondChar;*/

    [Header("Sentences")]
    public List<SentenceConfig> sentenceConfig;
}
