using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class KWIntroController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cam;

    public Transform cameraPoint1;
    public Transform cameraPointFinal;

    public GameObject speechBubble;

    public AnimatedTyping speechBubbleTyping;

    public TextMeshProUGUI speechBubbleText;

    public bool isMaleMillionaire;

    public GameObject TapTimerMechanic1;

    public int buttonCounter = 0;

    [TextArea(3, 4)] public string maleMillionaireOpeningText;
    [TextArea(3, 4)] public string femeleMillionaireOpeningText;

    public AudioSource maleMillionaireOpeningAudio;
    public AudioSource femaleMillionaireOpeningAudio;

    public TextMeshProUGUI positiveButton1Text;
    public TextMeshProUGUI negativeButton1Text;

    [TextArea(3, 4)] public string goodText1;
    [TextArea(3, 4)] public string badText1;

    public AudioSource maleMillionaireGoodAudio1;
    public AudioSource maleMillionaireBadAudio1;

    public AudioSource femaleMillionaireGoodAudio1;
    public AudioSource femaleMillionaireBadAudio1;

    public GameObject firewoodPile;
    public GameObject moneyPile;

    public List<GameObject> buttons = new List<GameObject>();

    public float buttonDelay = 1.5f;

    public float millionaireAudio1Delay = 2f;
    
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
        cam.transform.DORotateQuaternion(cameraPoint1.rotation, 2f).OnComplete(EnableSpeechBubble);
    }

    public void EnableSpeechBubble()
    {
        speechBubble.SetActive(true);

        switch (isMaleMillionaire)
        {
            case true:
                speechBubbleText.text = maleMillionaireOpeningText;
                speechBubbleTyping.Animate();

                positiveButton1Text.text = goodText1;
                negativeButton1Text.text = badText1;

                maleMillionaireOpeningAudio.Play();
                break;
            case false:
                speechBubbleText.text = femeleMillionaireOpeningText;
                speechBubbleTyping.Animate();

                positiveButton1Text.text = goodText1;
                negativeButton1Text.text = badText1;

                femaleMillionaireOpeningAudio.Play();
                break;
        }
    }

    public void OnGoodBtn1Press()
    {
        switch (isMaleMillionaire)
        {
            case true:
                maleMillionaireGoodAudio1.Play();
                BurnFirewood();

                Invoke("OnSpeechEnd", millionaireAudio1Delay);
                break;
            case false:
                femaleMillionaireGoodAudio1.Play();
                BurnFirewood();

                Invoke("OnSpeechEnd", millionaireAudio1Delay);
                break;
        }
    }

    public void OnBadBtn1Press()
    {
        switch (isMaleMillionaire)
        {
            case true:
                maleMillionaireBadAudio1.Play();
                BurnMoney();

                Invoke("OnSpeechEnd", millionaireAudio1Delay);
                break;
            case false:
                femaleMillionaireBadAudio1.Play();
                BurnMoney();

                Invoke("OnSpeechEnd", millionaireAudio1Delay);
                break;
        }
    }
    public void EnableNextButton()
    {
        buttons[buttonCounter].SetActive(true);
    }

    public void BurnFirewood()
    {
        firewoodPile.SetActive(true);
    }

    public void BurnMoney()
    {
        moneyPile.SetActive(true);
    }

    public void OnSpeechEnd()
    {
        speechBubble.SetActive(false);
        CameraZoomOut();
    }

    public void CameraZoomOut()
    {
        cam.transform.DORotateQuaternion(cameraPointFinal.rotation, 1.5f);

        cam.transform.DOMove(cameraPointFinal.position, 1.5f).OnComplete(OnIntroEnd);
    }

    public void OnIntroEnd()
    {
        TapTimerMechanic1.SetActive(true);
    }
}
