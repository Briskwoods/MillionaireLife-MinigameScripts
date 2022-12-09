using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using EPOOutline;

public class SMQueueManager : MonoBehaviour
{
    public int noInQueue = 0;
    public int maxQueueSize = 6;

    public List<GameObject> searchablePeople = new List<GameObject>();
    public List<Animator> searchablePeopleAnims = new List<Animator>();

    public Transform walkPoint;

    public Transform stopPoint;
   

    public SMButtonController buttonController;

    public GameObject renderCam;

    public List<GameObject> buttons = new List<GameObject>();

    public SMScanablesController scanablesController;

    public List<Outlinable> outlinables = new List<Outlinable>();

    [ContextMenu("Call Queue")]

    public void Start()
    {
        //renderCam.SetTargetBuffers(tex.colorBuffer, tex.depthBuffer);
    }
    public void CallQueue()
    {
        scanablesController.CheckIfGoodOrBad();
        searchablePeopleAnims[noInQueue].Play("Walking");  
        buttonController.characterBeingSearched = searchablePeople[noInQueue];
        searchablePeople[noInQueue].transform.DOMove(walkPoint.position, noInQueue).OnComplete(TurnToStopPoint2);
        //searchablePeople[noInQueue].transform.DORotateQuaternion(stopPoint.parent.rotation, 3f);
    }
    public void TurnToStopPoint2()
    {
        searchablePeople[noInQueue].transform.DOMove(stopPoint.position, 1.5f).OnComplete(HandsUp);
        searchablePeople[noInQueue].transform.DORotateQuaternion(walkPoint.rotation, 0.4f);
    }

    public void HandsUp()
    {
        renderCam.SetActive(enabled);
        outlinables[noInQueue].enabled = true;
        searchablePeople[noInQueue].transform.DORotateQuaternion(stopPoint.rotation , 1f);
        searchablePeopleAnims[noInQueue].Play("SMHandsUp");

        foreach(GameObject button in buttons)
        {
            button.SetActive(true);
        }
        noInQueue += 1;
    }
}
