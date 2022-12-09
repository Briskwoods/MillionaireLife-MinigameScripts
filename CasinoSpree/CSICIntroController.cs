using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CSICIntroController : MonoBehaviour
{
    public GameObject millionaire;
    //public GameObject instructions;

    public GameObject cam;

    public Transform cameraPoint1;
    public Transform cameraPointFinal;

    public Transform millionairePoint1;
    public Transform millionairePoint2;

    public bool isMaleMillionaire = false;

    public CharacterBehaviourManager millionaireAnim;

    public string Idle = "Idle";
    public string Walk = "Walking";

    public CSMinigameController minigameController;
    public CSCameraLookAtPlayer lookAtPlayerScript_;
    public CSInputReciever inputReciever;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("MillionaireWalkIn", 1.5f);
        GetPresidentGender();
    }

    public void GetPresidentGender()
    {
        isMaleMillionaire = CodeManager.Instance.PlayerPrefsManager_Script.GetGender();
    }

    public void MillionaireWalkIn()
    {
        cam.transform.DOMove(cameraPoint1.position, 2f);

        millionaireAnim.SetAnimation(Walk);
        millionaire.transform.DOMove(millionairePoint1.position, 2f).OnComplete(RotateMillionaire);
    }


    public void RotateMillionaire()
    {
        //cam.transform.DORotateQuaternion(cameraPoint1.rotation, .5f);

        millionaireAnim.SetAnimation(Idle);
        millionaire.transform.DORotateQuaternion(millionairePoint1.rotation, 0.5f).OnComplete(WalkToSlotMachines);
    }

    public void WalkToSlotMachines()
    {
        cam.transform.DOMove(cameraPointFinal.position, 2f);

        millionaireAnim.SetAnimation(Walk);
        millionaire.transform.DOMove(millionairePoint2.position, 2f).OnComplete(BeginLevel);
    }

    public void BeginLevel()
    {
        millionaireAnim.SetAnimation(Idle);
        lookAtPlayerScript_.enabled = false;
        minigameController.BeginLevel();
        Invoke("ShowInstructions", 1.5f);
    }

    public void ShowInstructions()
    {
        inputReciever.enabled = true;
    }
}
