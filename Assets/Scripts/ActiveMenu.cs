using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMenu : MonoBehaviour
{
    public GameObject panel;
    public GameObject fxMontre;

    private bool panelShowed;
    private bool panelHided = true;
    [SerializeField]
    private float MontreValue;

    private float value;
    void Start()
    {
        
    }

    void Update()
    {
        if (gameObject.transform.eulerAngles.z <= 276f + value && gameObject.transform.eulerAngles.z >= 230f - value)
        {
            panel.SetActive(true);

            if (!panelShowed)
            {
                AudioManager.instance.PlayClipAt(AudioManager.instance.allAudio["SFX_OpenHUD"], this.transform.position, AudioManager.instance.soundEffectMixer, true, false);
                panelShowed = true;
                panelHided = false;
                value = MontreValue;
            }
        }
        else
        {
            if (!panelHided)
            {
                AudioManager.instance.PlayClipAt(AudioManager.instance.allAudio["SFX_CloseHUD"], this.transform.position, AudioManager.instance.soundEffectMixer, true, false);
                panelHided = true;
                panelShowed = false;
                value = 0f;
            }

            panel.SetActive(false);

        }

        if (gameObject.transform.eulerAngles.z <= 300f + value && gameObject.transform.eulerAngles.z >= 205f - value)
        {
            fxMontre.SetActive(true);
        }
        else
        {
            fxMontre.SetActive(false);
        }
    }
}
