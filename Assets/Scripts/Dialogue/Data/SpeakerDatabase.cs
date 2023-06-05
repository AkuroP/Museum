using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeakerDatabase", menuName = "New Speaker Data")]
public class SpeakerDatabase : ScriptableObject
{
    public List<SpeakerData> speakerDatas = new();
    
}
