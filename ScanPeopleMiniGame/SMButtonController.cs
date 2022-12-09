using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using EPOOutline;

public class SMButtonController : MonoBehaviour
{
    public GameObject characterBeingSearched;

    public Transform loseWalkAwayPoint;
    public Transform winWalkAwayPoint;
    public Transform winWalkAwayPoint2;
    public Transform PolicePosititon;
    public Transform StopPoint2;
    public GameObject renderCam;
    public Animator staffAnim;
    public GameObject staff;
    public AudioClip punchSound;
    public AudioSource audioSource;
    public SMIntroSequenceController sequenceController;
    public SMQueueManager queueManager;

    public List<GameObject> buttons = new List<GameObject>();

    public SMMinigameController minigameController;

    [ContextMenu("On Approval")]
    public void OnApproval()
    {
        characterBeingSearched.GetComponent<Animator>().Play("HappyWalk");
        characterBeingSearched.transform.DORotateQuaternion(winWalkAwayPoint.rotation, 0.4f).OnComplete(OnApprovalWalkOff);
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
    }

    [ContextMenu("On Disapproval")]
    public void OnDisapproval()
    {
        staff.transform.DOMove(StopPoint2.position, 2f).OnComplete(Kick);
        staffAnim.Play("Walking");
        characterBeingSearched.transform.DORotateQuaternion(loseWalkAwayPoint.rotation, 0.4f);
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
    }
    public void OnDisapproval2()
    {
        characterBeingSearched.GetComponent<Animator>().Play("Fall");
        characterBeingSearched.transform.DOMove(loseWalkAwayPoint.position, 1.5f).OnComplete(OnDisapprovalWalkOff);
        Invoke("WalkBack",2f);

    }
    public void OnApprovalWalkOff()
    {
        characterBeingSearched.transform.DOMove(winWalkAwayPoint.position, 1.5f).OnComplete(OnApprovalWalkOff2);
        renderCam.SetActive(false);
        minigameController.CheckIfOver();
    }
    public void Kick()
    {
        staffAnim.Play("UpperCut");
        Invoke("SlapSound", 0.2f);
        Invoke("OnDisapproval2",0.5f);

    }
    public void SlapSound()
    {

        audioSource.PlayOneShot(punchSound);
    }
    public void WalkBack()
    {
        staff.transform.DOMove(PolicePosititon.position, 1.5f).OnComplete(FinishWalkBack);
        staff.transform.DORotateQuaternion(loseWalkAwayPoint.rotation, 0.4f);
        staffAnim.Play("Walking");
    }
    public void FinishWalkBack()
    {
        staff.transform.DORotateQuaternion(PolicePosititon.rotation, 0.4f);
        //characterBeingSearched.SetActive(false);
        staffAnim.Play("Idle");
    }
    public void OnApprovalWalkOff2()
    {
        characterBeingSearched.transform.DOMove(winWalkAwayPoint2.position, 3f).OnComplete(CallQueue);
        characterBeingSearched.transform.DORotateQuaternion(winWalkAwayPoint2.rotation, 0.4f);


    }

    public void OnDisapprovalWalkOff()
    {
        characterBeingSearched.transform.DOMove(loseWalkAwayPoint.position, 1.5f).OnComplete(CallQueue);
        renderCam.SetActive(false);
        minigameController.CheckIfOver();
    }

    public void CallQueue()
    {
        characterBeingSearched.GetComponent<Outlinable>().enabled = false;
        characterBeingSearched.SetActive(false);
        characterBeingSearched = null;
        queueManager.CallQueue();
    }
}
