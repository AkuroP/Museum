using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField] Image getSprite;
    [SerializeField] bool isArtifact;
    QuestManager questManager;

    private void Start()
    {
        questManager = GameObject.FindGameObjectWithTag("QuestManager").GetComponent<QuestManager>();
    }
    void Update()
    {
        if(!isArtifact)
        gameObject.GetComponent<Image>().sprite = getSprite.sprite;
        else
        {
            if(questManager.Artifact1)
                gameObject.GetComponent<Image>().sprite = getSprite.sprite;
        }
    }
}
