using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    
    [SerializeField] int numberOfEggs;
    [SerializeField] Sprite eggSprite;
    [SerializeField] ParticleSystem FXtoPlay;

    [Header("HUD")]
    [SerializeField] List<Image> spriteList;
    [SerializeField] GameObject qCanva;
    [SerializeField] GameObject eggHUD;
    [SerializeField] GameObject artifactHUD;

    [Header("QuestListing")]
    [SerializeField] bool questEggFinished;

    [Header("List of FX")]
    [SerializeField] ParticleSystem FXegg;
    [SerializeField] ParticleSystem FXscale;

    [Header("ActualQuest")]
    [SerializeField] int actual;

    public bool QuestEggFinished { get => questEggFinished; }

    private void Start()

    {
        actual = 1; // A enlever quand il y aura le trigger de la 1ere quest avec le dialogue du dragon
        spriteList = SpriteList(eggHUD);
    }
    void Update()
    {
         switch (actual)
         {
             case 0:
                 break;
             case 1: 
                 EggCounter();
                 break;

         }
    }

    // Compte le nombre d'oeufs obtenus pour valider la quête
    void EggCounter()
    {
        for (int i = 0; i < numberOfEggs; i++)
        {
            if (spriteList[i].sprite == eggSprite)
            {
                if (i + 1 == numberOfEggs)
                {
                    questEggFinished = true;
                    FXtoPlay = FXegg;
                    actual = 0;
                    return;
                }
            }
            else
                return;
            
        }
    }

    // Crée une liste d'Image à partir des enfants d'un canvas
    List<Image> SpriteList(GameObject canvas)
    {
        List<Image> imgList = new List<Image>();
        for(int i = 0; i  < canvas.transform.childCount; i++)
        {
            GameObject child = canvas.transform.GetChild(i).gameObject;
            if(child.GetComponent<Image>() != null)
            imgList.Add(child.GetComponent<Image>());
        }
        return imgList; 
    }

    public void Feedback()
    {
        if( FXtoPlay != null)
        {
            FXtoPlay.Play();
            FXtoPlay = null;
        }
    }

    public void FinishEggQuest()
    {
        if (questEggFinished)
        {
            eggHUD.SetActive(false);
            artifactHUD.SetActive(true);
            FXtoPlay = FXscale;
        }
    }
}
