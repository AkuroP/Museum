using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    
    [SerializeField] int numberOfEggs;
    [SerializeField] List<Image> spriteList;
    [SerializeField] GameObject qCanva;
    [SerializeField] Sprite eggSprite;
    [Header("QuestListing")]
    [SerializeField] bool questEggDone;

    public bool QuestEggDone { get => questEggDone; }

    private void Start()

    {
        //SpriteList(qCanva);
        spriteList = SpriteList(qCanva);
    }
    void Update()
    {
        EggCounter();        
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
                    questEggDone = true;
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
}
