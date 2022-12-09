using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class FAMIntroController : MonoBehaviour
{
    public GameObject instructions;
    public GameObject millionaire;

    public GameObject cam;

    public Transform cameraPoint1;
    public Transform cameraPointFinal;

    public bool isMaleMillionaire = false;

    public List<Animator> buttons = new List<Animator>();

    public Animator staffAnim;
    public string Idle = "Idle";
    public string Walk = "Walking";
    public string Talk = "Talking";
    public string Disappointed = "Disappointed";

    public GameObject staff;

    public Transform staffPoint1;
    public Transform staffPoint2;

    public GameObject speechBubble;

    public AnimatedTyping speechBubbleTyping;

    [TextArea(3, 4)] public string maleMillionaireOpeningText;
    [TextArea(3, 4)] public string femeleMillionaireOpeningText;

    [TextArea(3, 4)] public string staffText1;
    [TextArea(3, 4)] public string staffText2;

    [TextArea(3, 4)] public string goodText1;
    [TextArea(3, 4)] public string badText1;

    [TextArea(3, 4)] public string goodText2;
    [TextArea(3, 4)] public string badText2;

    public TextMeshProUGUI speechBubbleText;

    public TextMeshProUGUI positiveButton1Text;
    public TextMeshProUGUI negativeButton1Text;


    public TextMeshProUGUI positiveButton2Text;
    public TextMeshProUGUI negativeButton2Text;

    public AudioSource staffAudio1MaleMillionaireOpeningAudio;
    public AudioSource staffAudio1FemaleMillionaireOpeningAudio;

    public AudioSource staffAudio2;
    public AudioSource staffAudio3;

    public AudioSource maleMillionaireGoodAudio1;
    public AudioSource maleMillionaireGoodAudio2;

    public AudioSource maleMillionaireBadAudio1;
    public AudioSource maleMillionaireBadAudio2;

    public AudioSource femaleMillionaireGoodAudio1;
    public AudioSource femaleMillionaireGoodAudio2;

    public AudioSource femaleMillionaireBadAudio1;
    public AudioSource femaleMillionaireBadAudio2;

    public int buttonCounter = 0;

    public List<GameObject> introButtons = new List<GameObject>();

    public float buttonDelay = 1.5f;

    public float millionaireAudio1Delay = 2f;
    public float millionaireAudio2Delay = 2f;

    public GameObject graphObjs;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CameraIntroZoom", 1.5f);
        GetPresidentGender();
    }

    public void GetPresidentGender()
    {
        isMaleMillionaire = CodeManager.Instance.PlayerPrefsManager_Script.GetGender();
        //isMaleMillionaire = true;
    }

    public void CameraIntroZoom()
    {
        cam.transform.DOMove(cameraPoint1.position, 2f);
        cam.transform.DORotateQuaternion(cameraPoint1.rotation, 2f).OnComplete(StaffWalkIn);
    }


    public void RotateStaff()
    {
        staffAnim.Play(Idle);
        staff.transform.DORotateQuaternion(staffPoint1.rotation, 0.5f).OnComplete(EnableSpeechBubble);
    }

    public void EnableSpeechBubble()
    {
        speechBubble.SetActive(true);

        switch (isMaleMillionaire)
        {
            case true:
                speechBubbleText.text = maleMillionaireOpeningText;
                staffAnim.Play(Talk);
                speechBubbleTyping.Animate();

                positiveButton1Text.text = goodText1;
                negativeButton1Text.text = badText1;

                staffAudio1MaleMillionaireOpeningAudio.Play();
                //buttonCounter++;

                break;
            case false:
                speechBubbleText.text = femeleMillionaireOpeningText;
                staffAnim.Play(Talk);
                speechBubbleTyping.Animate();

                positiveButton1Text.text = goodText1;
                negativeButton1Text.text = badText1;

                staffAudio1FemaleMillionaireOpeningAudio.Play();
                //buttonCounter++;

                break;
        }
    }

    //[ContextMenu("Load Next Btn")]
    public void LoadNextButtonItems()
    {
        switch (buttonCounter)
        {
            case 0:
                break;
            case 1:
                speechBubbleText.text = staffText1;
                staffAnim.Play(Talk);
                speechBubbleTyping.Animate();

                positiveButton2Text.text = goodText2;
                negativeButton2Text.text = badText2;

                staffAudio2.Play();
                break;
            case 2:
                speechBubbleText.text = staffText2;
                staffAnim.Play(Talk);
                speechBubbleTyping.Animate();

                staffAudio3.Play();
                break;
        }
    }


    public void OnGoodBtn1Press()
    {
        buttonCounter++;

        switch (isMaleMillionaire)
        {
            case true:
                maleMillionaireGoodAudio1.Play();

                Invoke("LoadNextButtonItems", millionaireAudio1Delay);
                break;
            case false:
                femaleMillionaireGoodAudio1.Play();

                Invoke("LoadNextButtonItems", millionaireAudio1Delay);
                break;
        }
    }

    public void OnGoodBtn2Press()
    {
        buttonCounter++;

        switch (isMaleMillionaire)
        {
            case true:
                maleMillionaireGoodAudio2.Play();

                Invoke("LoadNextButtonItems", millionaireAudio2Delay);
                break;
            case false:
                femaleMillionaireGoodAudio2.Play();

                Invoke("LoadNextButtonItems", millionaireAudio2Delay);
                break;
        }
    }

    public void OnBadBtn1Press()
    {
        buttonCounter++;

        switch (isMaleMillionaire)
        {
            case true:
                maleMillionaireBadAudio1.Play();

                Invoke("LoadNextButtonItems", millionaireAudio1Delay);
                break;
            case false:
                femaleMillionaireBadAudio1.Play();

                Invoke("LoadNextButtonItems", millionaireAudio1Delay);
                break;
        }
    }

    public void OnBadBtn2Press()
    {
        buttonCounter++;
        switch (isMaleMillionaire)
        {
            case true:
                maleMillionaireBadAudio2.Play();

                Invoke("LoadNextButtonItems", millionaireAudio2Delay);
                break;
            case false:
                femaleMillionaireBadAudio2.Play();

                Invoke("LoadNextButtonItems", millionaireAudio2Delay);
                break;
        }
    }


    public void EnableNextButton()
    {
        introButtons[buttonCounter].SetActive(true);
    }


    public void OnClickOfButton()
    {
        buttonCounter++;
        LoadNextButtonItems();
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
        cam.transform.DOMove(cameraPointFinal.position, 1.5f).OnComplete(BeginLevel);
    }


    public void StaffWalkIn()
    {
        staffAnim.Play(Walk);
        staff.transform.DOMove(staffPoint1.position, 2f).OnComplete(RotateStaff);
    }

    public void BeginLevel()
    {
        graphObjs.SetActive(true);
        instructions.SetActive(true);
        millionaire.SetActive(false);

        foreach (Animator button in buttons)
        {
            button.SetTrigger("Next");
            button.gameObject.GetComponent<FAMIndividualButtonController>().canBeClicked = true;
        };
    }

}
