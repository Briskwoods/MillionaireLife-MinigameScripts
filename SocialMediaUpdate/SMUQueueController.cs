using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SMUQueueController : MonoBehaviour
{
   public int noInQueue = 0;
    public int maxQueueSize = 4;

    public List<GameObject> posts = new List<GameObject>();


    [ContextMenu("On Start")]
    public void OnLevelStart()
    {
        posts[noInQueue].SetActive(true);
    }


    [ContextMenu("Switch Screen")]
    public void SwitchPost()
    {
        posts[noInQueue].SetActive(false);

        noInQueue += 1;

        StartCoroutine("SecondsForSwitch");
    }


    public IEnumerator SecondsForSwitch()
    {
        yield return new WaitForSeconds(0.5f);
       
        switch (noInQueue < maxQueueSize)
        {
            case true:
                posts[noInQueue].SetActive(true);
                break;
            case false:
                break;
        }
    }
}
