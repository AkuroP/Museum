using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class QuestManager : MonoBehaviour
{
    
    [SerializeField] int numberOfEggs;
    [SerializeField] Sprite eggSprite;
    [SerializeField] ParticleSystem FXtoPlay;
    [SerializeField] GameObject animEcaille;
    [Header("Player")]
    [SerializeField] ActionBasedContinuousMoveProvider movements;
    [SerializeField] XRBaseController RightController;
    [SerializeField] XRBaseController LeftController;

    [Header("HUD")]
    [SerializeField] List<Image> spriteList;
    [SerializeField] GameObject eggHUD;
    [SerializeField] GameObject artifactHUD;
    [SerializeField] GameObject allEggs;

    [Header("QuestListing")]
    [SerializeField] bool questEggFinished;
    [SerializeField] bool artifact1;

    [Header("List of FX")]
    [SerializeField] ParticleSystem FXegg;
    [SerializeField] ParticleSystem FXscale;
    [SerializeField] Animator endQuestAnim;
    [SerializeField] GameObject anim;

    [Header("ActualQuest")]
    [SerializeField] int actual;

    [Header("Entity")]
    [SerializeField] List<Entity> allEntity;

    public Entity.ENTITYTAG[] questTag;
    public bool QuestEggFinished { get => questEggFinished; }
    public bool Artifact1 { get => artifact1;}

    private void Start()

    {
        endQuestAnim = anim.GetComponent<Animator>();
        actual = 1; // A enlever quand il y aura le trigger de la 1ere quest avec le dialogue du dragon
        spriteList = SpriteList(eggHUD);
        

        //Prend tout les npc de la scene
        //les assignent dans allEntity
        //GameObject[] npc = GameObject.FindGameObjectsWithTag("NPC");
        //Debug.Log(npc.Length);
        /*foreach (var entity in npc)
        {
            allEntity.Add(entity.GetComponent<Entity>());
        }*/
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
            //Debug.Log(i);
            if (spriteList[i].sprite == eggSprite)
            {
                if (i + 1 == numberOfEggs)
                {
                    Debug.Log("YU");
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
            artifact1 = true;
            eggHUD.SetActive(false);
            artifactHUD.SetActive(true);
            FXtoPlay = FXscale;
            allEggs.SetActive(false);
            //endQuestAnim.SetBool("FinishQuest", true);
            movements.moveSpeed = 0;


            RightController.SendHapticImpulse(0.7f, 0.7f);
            LeftController.SendHapticImpulse(0.7f, 0.7f);

            AudioManager.instance.PlayClipAt(AudioManager.instance.allAudio["SFX_AllQuestItemsCollected"], this.transform.position, AudioManager.instance.soundEffectMixer, true, false, 1, 1, 360, 1, 10f);
            //avance dialogue des entites concerne
            /*foreach (Entity npc in allEntity)
            {
                foreach(Entity.ENTITYTAG qTag in questTag)
                {
                    if(npc.entityTag == qTag)
                    {
                        npc.CurrentDialogAdvancement += 1;
                    }
                }
            }*/
        }
    }

    public void PlaceArtifact()
    {
        if (artifact1)
        {
            animEcaille.SetActive(true);
            RightController.SendHapticImpulse(0.5f, 0.5f);

        }
    }
}
