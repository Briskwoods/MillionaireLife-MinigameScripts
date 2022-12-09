using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using EPOOutline;

public class SMIntroSequenceController : MonoBehaviour
{
    public GameObject cam;
    public Transform cameraPoint1;
    public Transform cameraPointFinal;

    public Animator staffAnim;
    public string Idle = "Idle";
    public string Walk = "Walking";
    public string Talk = "Talking";
    public GameObject staff;
    public Transform staffPoint1;
    public Transform staffPoint2;

    public GameObject speechBubble;
    public AnimatedTyping speechBubbleTyping;
    [TextArea(3, 4)] public string MrPresidentspeechText;
    [TextArea(3, 4)] public string MrsPresidentspeechText;
    public TextMeshProUGUI textMeshText;

    public AudioSource mrPresident;
    public AudioSource mrsPresident;

    public bool isMalePresident;

    public GameObject IntroScene;

    public SMQueueManager queueManager;

    public List<Outlinable> outlinables = new List<Outlinable>();

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CameraIntroZoom", 1.5f);
        GetPresidentGender();
    }

    public void GetPresidentGender()
    {
        isMalePresident = CodeManager.Instance.LevelManager_Script.isMan;
    }

    public void CameraIntroZoom()
    {
        cam.transform.DORotateQuaternion(cameraPoint1.rotation, 2f);
        cam.transform.DOMove(cameraPoint1.position, 2f).OnComplete(BeginLevel);
    }

    public void BeginLevel()
    {
        staffAnim.Play(Walk);
        staff.transform.DOMove(staffPoint1.position, 2f).OnComplete(RotateStaff);
    }


    public void RotateStaff()
    {
        staffAnim.Play(Idle);
        staff.transform.DORotateQuaternion(staffPoint1.rotation, 0.5f).OnComplete(EnableSpeechBubble);
    }

    public void EnableSpeechBubble()
    {
        speechBubble.SetActive(true);

        switch (isMalePresident)
        {
            case true:
                textMeshText.text = MrPresidentspeechText;
                staffAnim.Play(Talk);
                speechBubbleTyping.Animate();
                mrPresident.Play();
                break;
            case false:
                textMeshText.text = MrsPresidentspeechText;
                staffAnim.Play(Talk);
                speechBubbleTyping.Animate();
                mrsPresident.Play();
                break;
        }
        Invoke("OnSpeechEnd", 6f);
    }

    public void OnSpeechEnd()
    {
        staffAnim.Play(Walk);
        speechBubble.SetActive(false);
        staff.transform.DORotateQuaternion(staffPoint2.rotation, 0.5f).OnComplete(StaffWalkOff);
    }

    public void StaffWalkOff()
    {
        staff.transform.DOMove(staffPoint2.position, 2f).OnComplete(CameraZoomOut);
    }

    public void CameraZoomOut()
    {
        staff.SetActive(false);
        cam.transform.DORotateQuaternion(cameraPointFinal.rotation, 1.5f);
        cam.transform.DOMove(cameraPointFinal.position, 1.5f).OnComplete(OnIntroEnd);
    }

    public void OnIntroEnd()
    {
        queueManager.CallQueue();
        foreach (Outlinable outlinable in outlinables)
        {
            outlinable.enabled = true;
        }
    }
}
