using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class BMFMIntroController : MonoBehaviour
{
    public GameObject instructions;
    public GameObject millionaire;

    public GameObject cam;

    public Transform cameraPoint1;
    public Transform cameraPoint2;
    public Transform cameraPointFinal;

    public bool isMaleMillionaire = false;

    public Animator dancerAnim;
    public string Idle = "Idle";
    public string Walk = "Dance";
    public string Talk = "Talking";
    public string Disappointed = "Disappointed";

    public GameObject dancer;

    public Transform dancerPoint1;

    public GameObject speechBubble;

    public AnimatedTyping speechBubbleTyping;

    [TextArea(3, 4)] public string maleMillionaireOpeningText;
    [TextArea(3, 4)] public string femeleMillionaireOpeningText;


    [TextArea(3, 4)] public string goodText1;
    [TextArea(3, 4)] public string badText1;

    [TextArea(3, 4)] public string goodText2;
    [TextArea(3, 4)] public string badText2;

    public TextMeshProUGUI speechBubbleText;

    public TextMeshProUGUI positiveButton1Text;
    public TextMeshProUGUI negativeButton1Text;

    public TextMeshProUGUI positiveButton2Text;
    public TextMeshProUGUI negativeButton2Text;

    public AudioSource dancerAudio1MaleMillionaireOpeningAudio;
    public AudioSource dancerAudio1FemaleMillionaireOpeningAudio;


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
    public float danceDelay = 2.5f;

    public float millionaireAudio1Delay = 2f;
    public float millionaireAudio2Delay = 2f;

    public CharacterBehaviourManager cBM_;

    public BMFMIntroController introController;
    public BMFMinigameController minigameController;

    public string twerk = "Twerk";
    public string chickenDance = "Chicken Dance";

    public GameObject moneyGun;

    public List<GameObject> canvases = new List<GameObject>();

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
        cam.transform.DORotateQuaternion(cameraPoint1.rotation, 2f).OnComplete(RotateDancer);
    }


    public void RotateDancer()
    {
        dancerAnim.Play(Idle);
        dancer.transform.DORotateQuaternion(dancerPoint1.rotation, 0.5f).OnComplete(EnableSpeechBubble);
    }

    public void EnableSpeechBubble()
    {
        speechBubble.SetActive(true);

        switch (isMaleMillionaire)
        {
            case true:
                speechBubbleText.text = maleMillionaireOpeningText;
                dancerAnim.Play(Talk);
                speechBubbleTyping.Animate();

                positiveButton1Text.text = goodText1;
                negativeButton1Text.text = badText1;

                dancerAudio1MaleMillionaireOpeningAudio.Play();
                //buttonCounter++;

                break;
            case false:
                speechBubbleText.text = femeleMillionaireOpeningText;
                dancerAnim.Play(Talk);
                speechBubbleTyping.Animate();

                positiveButton1Text.text = goodText1;
                negativeButton1Text.text = badText1;

                dancerAudio1FemaleMillionaireOpeningAudio.Play();
                //buttonCounter++;

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

                Invoke("LookAtMillionaireGood", millionaireAudio1Delay);
                break;
            case false:
                femaleMillionaireGoodAudio1.Play();

                Invoke("LookAtMillionaireGood", millionaireAudio1Delay);
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

                Invoke("CameraZoomOut", millionaireAudio2Delay);
                break;
            case false:
                femaleMillionaireGoodAudio2.Play();

                Invoke("CameraZoomOut", millionaireAudio2Delay);
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

                Invoke("LookAtMillionaireBad", millionaireAudio1Delay);
                break;
            case false:
                femaleMillionaireBadAudio1.Play();

                Invoke("LookAtMillionaireBad", millionaireAudio1Delay);
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


                // Player dances and level ends 
                Invoke("OnBadEnd", millionaireAudio2Delay);
                break;
            case false:
                femaleMillionaireBadAudio2.Play();

                Invoke("OnBadEnd", millionaireAudio2Delay);
                break;
        }
    }

    public void LookAtMillionaireGood()
    {
        cam.transform.DOMove(cameraPoint2.position, 2f);
        cam.transform.DORotateQuaternion(cameraPoint2.rotation, 2f).OnComplete(ChickenDanceClicked);
    }


    public void LookAtMillionaireBad()
    {
        cam.transform.DOMove(cameraPoint2.position, 2f);
        cam.transform.DORotateQuaternion(cameraPoint2.rotation, 2f).OnComplete(TwerkClicked);
    }

    public void TwerkClicked()
    {
        cBM_.SetAnimation(twerk);
        Invoke("StopDancing", danceDelay);
    }


    public void ChickenDanceClicked()
    {
        cBM_.SetAnimation(chickenDance);
        Invoke("ContinueDancingButShowButtons", danceDelay);
    }

    public void StopDancing()
    {
        cBM_.SetAnimation(Idle);
        LoadNextButtonItems();
        EnableNextButton();
    }

    public void ContinueDancingButShowButtons()
    {
        LoadNextButtonItems();
        EnableNextButton();
    }

    public void EnableNextButton()
    {
        introButtons[buttonCounter].SetActive(true);
    }

    public void LoadNextButtonItems()
    {
        switch (buttonCounter)
        {
            case 0:
                break;
            case 1:
                positiveButton2Text.text = goodText2;
                negativeButton2Text.text = badText2;
                break;
        }
    }
    
    public void CameraZoomOut()
    {
        //dancer.SetActive(false);
        cam.transform.DORotateQuaternion(cameraPointFinal.rotation, 1.5f);
        cam.transform.DOMove(cameraPointFinal.position, 1.5f).OnComplete(BeginLevel);
    }


    public void BeginLevel()
    {
        moneyGun.SetActive(true);
        millionaire.SetActive(false);
        instructions.SetActive(true);

        foreach (GameObject canvas in canvases)
        {
            canvas.SetActive(true);
        }
    }


    public void OnBadEnd()
    {
        cBM_.SetAnimation(chickenDance);
        //Invoke("EndLevel", 2f);
        EndLevel(2f);
    }

    public void EndLevel(float delay)
    {
        minigameController.EndLevel(delay);
    }
}
