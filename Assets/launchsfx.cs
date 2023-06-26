using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchsfx : MonoBehaviour
{
    
    public void PlaySFX(string name)
    {
        AudioManager.instance.PlayClipAt(AudioManager.instance.allAudio[name], this.transform.position, AudioManager.instance.soundEffectMixer, true, false, 1, 0.3f, 360, 1, 20);
    }
}
