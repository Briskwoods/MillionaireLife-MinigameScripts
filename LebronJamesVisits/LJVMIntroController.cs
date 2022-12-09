using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class LJVMIntroController : MonoBehaviour
{
    public GameObject instructions;

    public GameObject cam;

    public Transform cameraPoint1;
    public Transform cameraPointFinal;

    public Animator lJAnim;
    public string Idle = "Idle";
    public string Walk = "Walking";
    public string Talk = "Talking";
    public string Disappointed = "Disappointed";

    public GameObject lJ;

    public Transform lJPoint1;
    public Transform lJPoint2;

    public GameObject speechBubble;

    public AnimatedTyping speechBubbleTyping;

    [TextArea(3, 4)] public string maleMillionaireOpeningText;
    [TextArea(3, 4)] public string femeleMillionaireOpeningText;

    [TextArea(3, 4)] public string lJText1;
    [TextArea(3, 4)] public string lJText2;
    [TextArea(3, 4)] public string lJText3;

    [TextArea(3, 4)] public string goodText1;
    [TextArea(3, 4)] public string badText1;

    [TextArea(3, 4)] public string goodText2;
    [TextArea(3, 4)] public string badText2;

    [TextArea(3, 4)] public string goodText3;
    [TextArea(3, 4)] public string badText3;

    public TextMeshProUGUI speechBubbleText;

    public TextMeshProUGUI positiveButton1Text;
    public TextMeshProUGUI negativeButton1Text;


    public TextMeshProUGUI positiveButton2Text;
    public TextMeshProUGUI negativeButton2Text;

    public TextMeshProUGUI positiveButton3Text;
    public TextMeshProUGUI negativeButton3Text;

    public AudioSource maleMillionaireOpeningAudio;
    public AudioSource femaleMillionaireOpeningAudio;

    public AudioSource lJAudio1;
    public AudioSource lJAudio2;
    public AudioSource lJAudio3;


    public AudioSource maleMillionaireGoodAudio1;
    public AudioSource maleMillionaireGoodAudio2;
    public AudioSource maleMillionaireGoodAudio3;

    public AudioSource maleMillionaireBadAudio1;
    public AudioSource maleMillionaireBadAudio2;
    public AudioSource maleMillionaireBadAudio3;

    public AudioSource femaleMillionaireGoodAudio1;
    public AudioSource femaleMillionaireGoodAudio2;
    public AudioSource femaleMillionaireGoodAudio3;

    public AudioSource femaleMillionaireBadAudio1;
    public AudioSource femaleMillionaireBadAudio2;
    public AudioSource femaleMillionaireBadAudio3;


    public bool isMaleMillionaire;

    public GameObject IntroScene;
    public GameObject ShootBasketsScene;

    public ButtonDetails adButton;

    public int buttonCounter = 0;

    public List<GameObject> buttons = new List<GameObject>();

    public float buttonDelay = 1.5f;

    public float millionaireAudio1Delay = 2f;
    public float millionaireAudio2Delay = 2f;
    public float millionaireAudio3Delay = 2f;

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
        cam.transform.DORotateQuaternion(cameraPoint1.rotation, 2f).OnComplete(BeginLevel);
    }

    public void BeginLevel()
    {
        lJAnim.Play(Walk);
        lJ.transform.DOMove(lJPoint1.position, 2f).OnComplete(RotateStaff);
    }


    public void RotateStaff()
    {
        lJAnim.Play(Idle);
        lJ.transform.DORotateQuaternion(lJPoint1.rotation, 0.5f).OnComplete(EnableSpeechBubble);
    }

    public void EnableSpeechBubble()
    {
        speechBubble.SetActive(true);

        switch (isMaleMillionaire)
        {
            case true:
                speechBubbleText.text = maleMillionaireOpeningText;
                lJAnim.Play(Talk);
                speechBubbleTyping.Animate();

                positiveButton1Text.text = goodText1;
                negativeButton1Text.text = badText1;

                maleMillionaireOpeningAudio.Play();
                //buttonCounter++;

                break;
            case false:
                speechBubbleText.text = femeleMillionaireOpeningText;
                lJAnim.Play(Talk);
                speechBubbleTyping.Animate();

                positiveButton1Text.text = goodText1;
                negativeButton1Text.text = badText1;

                femaleMillionaireOpeningAudio.Play();
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
                speechBubbleText.text = lJText1;
                lJAnim.Play(Talk);
                speechBubbleTyping.Animate();

                positiveButton2Text.text = goodText2;
                negativeButton2Text.text = badText2;

                lJAudio1.Play();
                break;
            case 2:
                speechBubbleText.text = lJText2;
                lJAnim.Play(Talk);
                speechBubbleTyping.Animate();

                //adButton.MakeThisButtonAnAd();

                positiveButton3Text.text = goodText3;
                negativeButton3Text.text = badText3;

                lJAudio2.Play();

                break;

            case 3:
                speechBubbleText.text = lJText3;
                lJAnim.Play(Talk);
                speechBubbleTyping.Animate();

                lJAudio3.Play();
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

    public void OnGoodBtn3Press()
    {
        buttonCounter++;

        switch (isMaleMillionaire)
        {
            case true:
                maleMillionaireGoodAudio3.Play();

                Invoke("LoadNextButtonItems", millionaireAudio3Delay);
                break;
            case false:
                femaleMillionaireGoodAudio3.Play();

                Invoke("LoadNextButtonItems", millionaireAudio3Delay);
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

    public void OnBadBtn3Press()
    {
        buttonCounter++;
        switch (isMaleMillionaire)
        {
            case true:
                maleMillionaireBadAudio3.Play();

                Invoke("LoadNextButtonItems", millionaireAudio3Delay);
                break;
            case false:
                femaleMillionaireBadAudio3.Play();

                Invoke("LoadNextButtonItems", millionaireAudio3Delay);
                break;
        }
    }


    public void EnableNextButton()
    {
        buttons[buttonCounter].SetActive(true);
    }


    public void OnClickOfButton()
    {
        buttonCounter++;
        LoadNextButtonItems();
    }


    public void OnSpeechEnd()
    {
        lJAnim.Play(Walk);
        speechBubble.SetActive(false);
        lJ.transform.DORotateQuaternion(lJPoint2.rotation, 0.5f).OnComplete(StaffWalkOff);
    }

    public void StaffWalkOff()
    {
        lJ.transform.DOMove(lJPoint2.position, 2f).OnComplete(CameraZoomOut);
    }

    public void CameraZoomOut()
    {
        lJ.SetActive(false);
        cam.transform.DOMove(cameraPointFinal.position, 1.5f).OnComplete(OnIntroEnd);
    }

    public void OnIntroEnd()
    {
        ShootBasketsScene.SetActive(true);
        IntroScene.SetActive(false);
    }

    public void OnNegativeChosen()
    {
        lJAnim.Play(Disappointed);
        //Invoke("EndLevel", 2.5f);
        EndLevel(2.5f);
    }

    public void EndLevel(float delay)
    {
        //CodeManager.Instance.LevelManager_Script.NextLevel();
        CodeManager.Instance.LevelManager_Script.EndLevel(delay);
    }
}
