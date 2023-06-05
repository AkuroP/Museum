using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpeakerData
{
    public string label;
    public int id;
    public List<Status> statuses = new();

    [System.Serializable]
    public struct Status
    {
        public enum EMOTION
        {
            NEUTRAL,
            HAPPY,
            SAD,
            ANGRY
        }

        public Sprite icon;
        public EMOTION emotion;
        public AudioClip audioClip;
    }
}
