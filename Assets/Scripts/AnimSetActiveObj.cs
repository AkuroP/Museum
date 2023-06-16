using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSetActiveObj : MonoBehaviour
{
   public void DeactiveObj()
    {
        this.gameObject.SetActive(false);
    }
}
