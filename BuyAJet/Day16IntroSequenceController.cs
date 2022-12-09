using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Day16IntroSequenceController : MonoBehaviour
{
    public GameObject m_buttons;

    public CharacterBehaviourManager characterBehaviourManager;

    public Animator Officer1;
    public Animator Officer2;
    public Animator Officer3;
    public Animator Officer4;

    public Transform startGoal;
    public Transform WalkInTarget;

    public Transform Officer1Goal;
    public Transform Officer2Goal;
    public Transform Officer3Goal;
    public Transform Officer4Goal;

    public Transform CameraTarget;

    public GameObject President;

    public GameObject OfficerOne;
    public GameObject OfficerTwo;
    public GameObject OfficerThree;
    public GameObject OfficerFour;

    public GameObject Camera;

    // Start is called before the first frame update
    void Start()
    { 
        //characterBehaviourManager.SetAnimation("Walking");
        IntroSequenceStart();
    }

    
    void OnEnable()
    {
        //characterBehaviourManager.SetAnimation("Walking");

    }

    public void IntroSequenceStart()
    {
        characterBehaviourManager.SetAnimation("Walking");

        Officer1.Play("Walking");
        Officer2.Play("Walking");
        Officer3.Play("Walking");
        Officer4.Play("Walking");

        President.transform.DOMove(startGoal.position, 3.5f).OnComplete(RotatePresident);

        Camera.transform.DOMove(WalkInTarget.position, 3.5f);

        OfficerOne.transform.DOMove(Officer1Goal.position, 3.5f);
        OfficerTwo.transform.DOMove(Officer2Goal.position, 3.5f);
        OfficerThree.transform.DOMove(Officer3Goal.position, 3.5f);
        OfficerFour.transform.DOMove(Officer4Goal.position, 3.5f);
    }


    public void RotatePresident()
    {
        characterBehaviourManager.SetAnimation("Idle");

        Officer1.Play("Idle");
        Officer2.Play("Idle");
        Officer3.Play("Idle");
        Officer4.Play("Idle");

        President.transform.DORotateQuaternion(startGoal.rotation, 1f).OnComplete(MoveCameraToPresidentPOV);

        OfficerOne.transform.DORotateQuaternion(Officer1Goal.rotation, 3.5f);
        OfficerTwo.transform.DORotateQuaternion(Officer2Goal.rotation, 3.5f);
        OfficerThree.transform.DORotateQuaternion(Officer3Goal.rotation, 3.5f);
        OfficerFour.transform.DORotateQuaternion(Officer4Goal.rotation, 3.5f);
    }

    public void MoveCameraToPresidentPOV()
    {
        Camera.transform.DOMove(CameraTarget.position, 2f);
        Camera.transform.DORotateQuaternion(CameraTarget.rotation, 1f).OnComplete(EnableOnWalkIn);

    }

    public void EnableOnWalkIn()
    {
        m_buttons.SetActive(true);
    }
}
