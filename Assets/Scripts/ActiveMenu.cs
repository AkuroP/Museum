using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMenu : MonoBehaviour
{
    public GameObject panel;
    public GameObject fxMontre;

    private bool panelShowed;
    private bool panelHided;
    void Start()
    {
        
    }

    void Update()
    {
        if (gameObject.transform.eulerAngles.z <= 276f && gameObject.transform.eulerAngles.z >= 230f)
        {
            panel.SetActive(true);
            
            if (!panelShowed) AudioManager.instance.PlayClipAt(AudioManager.instance.allAudio["SFX_OpenHUD"], this.transform.position, AudioManager.instance.soundEffectMixer, true, false);
            panelShowed = true;
            panelHided = false;
        }
        else
        {
            if (!panelHided) AudioManager.instance.PlayClipAt(AudioManager.instance.allAudio["SFX_CloseHUD"], this.transform.position, AudioManager.instance.soundEffectMixer, true, false);
            panelHided = true;
            panelShowed = false;
            panel.SetActive(false);

        }

        if (gameObject.transform.eulerAngles.z <= 300f && gameObject.transform.eulerAngles.z >= 205f)
        {
            fxMontre.SetActive(true);
        }
        else
        {
            fxMontre.SetActive(false);
        }
    }
}
