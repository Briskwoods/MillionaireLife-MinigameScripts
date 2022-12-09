using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SMUButtonController : MonoBehaviour
{
    public SMUTextController textController;

    public TextMeshProUGUI captionBox1Txt;
    public TextMeshProUGUI captionBox2Txt;
    public TextMeshProUGUI captionBox3Txt;
    public TextMeshProUGUI captionBox4Txt;

    public AnimatedTyping captionBox1;
    public AnimatedTyping captionBox2;
    public AnimatedTyping captionBox3;
    public AnimatedTyping captionBox4;


    public AudioSource maleMillionaireGoodAudio1;
    public AudioSource maleMillionaireGoodAudio2;
    public AudioSource maleMillionaireGoodAudio3;
    public AudioSource maleMillionaireGoodAudio4;

    public AudioSource maleMillionaireBadAudio1;
    public AudioSource maleMillionaireBadAudio2;
    public AudioSource maleMillionaireBadAudio3;
    public AudioSource maleMillionaireBadAudio4;

    public AudioSource femaleMillionaireGoodAudio1;
    public AudioSource femaleMillionaireGoodAudio2;
    public AudioSource femaleMillionaireGoodAudio3;
    public AudioSource femaleMillionaireGoodAudio4;

    public AudioSource femaleMillionaireBadAudio1;
    public AudioSource femaleMillionaireBadAudio2;
    public AudioSource femaleMillionaireBadAudio3;
    public AudioSource femaleMillionaireBadAudio4;


    public bool isMaleMillionaire;

    public int buttonCounter = 0;

    public List<GameObject> buttons = new List<GameObject>();

    public float buttonDelay = 1.5f;

    public float millionaireAudio1Delay = 2f;
    public float millionaireAudio2Delay = 2f;
    public float millionaireAudio3Delay = 2f;
    public float millionaireAudio4Delay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        GetPresidentGender();
    }

    public void GetPresidentGender()
    {
        isMaleMillionaire = CodeManager.Instance.PlayerPrefsManager_Script.GetGender();
    }

    public void OnGoodBtn1Press()
    {
        buttonCounter++;

        switch (isMaleMillionaire)
        {
            case true:
                captionBox1Txt.text = textController.goodText1;
                maleMillionaireGoodAudio1.Play();
                captionBox1.Animate();

                //Invoke("EnableNextButton", millionaireAudio1Delay);
                break;
            case false:
                captionBox1Txt.text = textController.goodText1;
                femaleMillionaireGoodAudio1.Play();
                captionBox1.Animate();

                //Invoke("EnableNextButton", millionaireAudio1Delay);
                break;
        }
    }

    public void OnGoodBtn2Press()
    {
        buttonCounter++;

        switch (isMaleMillionaire)
        {
            case true:
                captionBox2Txt.text = textController.goodText2;
                maleMillionaireGoodAudio2.Play();
                captionBox2.Animate();

                //Invoke("EnableNextButton", millionaireAudio2Delay);
                break;
            case false:
                captionBox2Txt.text = textController.goodText2;
                femaleMillionaireGoodAudio2.Play();
                captionBox2.Animate();

                //Invoke("EnableNextButton", millionaireAudio2Delay);
                break;
        }
    }

    public void OnGoodBtn3Press()
    {
        buttonCounter++;

        switch (isMaleMillionaire)
        {
            case true:
                captionBox3Txt.text = textController.goodText3;
                maleMillionaireGoodAudio3.Play();
                captionBox3.Animate();

                //Invoke("EnableNextButton", millionaireAudio3Delay);
                break;
            case false:
                captionBox3Txt.text = textController.goodText3;
                femaleMillionaireGoodAudio3.Play();
                captionBox3.Animate();

                //Invoke("EnableNextButton", millionaireAudio3Delay);
                break;
        }
    }

    public void OnGoodBtn4Press()
    {
        buttonCounter++;

        switch (isMaleMillionaire)
        {
            case true:
                captionBox4Txt.text = textController.goodText4;
                maleMillionaireGoodAudio4.Play();
                captionBox4.Animate();
                break;
            case false:
                captionBox4Txt.text = textController.goodText4;
                femaleMillionaireGoodAudio4.Play();
                captionBox4.Animate();
                break;
        }
    }

    public void OnBadBtn1Press()
    {
        buttonCounter++;

        switch (isMaleMillionaire)
        {
            case true:
                captionBox1Txt.text = textController.badText1;
                maleMillionaireBadAudio1.Play();
                captionBox1.Animate();

                //Invoke("EnableNextButton", millionaireAudio1Delay);
                break;
            case false:
                captionBox1Txt.text = textController.badText1;
                femaleMillionaireBadAudio1.Play();
                captionBox1.Animate();

                //Invoke("EnableNextButton", millionaireAudio1Delay);
                break;
        }
    }

    public void OnBadBtn2Press()
    {
        buttonCounter++;
        switch (isMaleMillionaire)
        {
            case true:
                captionBox2Txt.text = textController.badText2;
                maleMillionaireBadAudio2.Play();
                captionBox2.Animate();

                //Invoke("EnableNextButton", millionaireAudio2Delay);
                break;
            case false:
                captionBox2Txt.text = textController.badText2;
                femaleMillionaireBadAudio2.Play();
                captionBox2.Animate();

                //Invoke("EnableNextButton", millionaireAudio2Delay);
                break;
        }
    }

    public void OnBadBtn3Press()
    {
        buttonCounter++;
        switch (isMaleMillionaire)
        {
            case true:
                captionBox3Txt.text = textController.badText3;
                maleMillionaireBadAudio3.Play();
                captionBox3.Animate();

                //Invoke("EnableNextButton", millionaireAudio3Delay);
                break;
            case false:
                captionBox3Txt.text = textController.badText3;
                femaleMillionaireBadAudio3.Play();
                captionBox3.Animate();

                //Invoke("EnableNextButton", millionaireAudio3Delay);
                break;
        }
    }


    public void OnBadBtn4Press()
    {
        buttonCounter++;
        switch (isMaleMillionaire)
        {
            case true:
                captionBox4Txt.text = textController.badText4;
                maleMillionaireBadAudio4.Play();
                captionBox4.Animate();
                break;
            case false:
                captionBox4Txt.text = textController.badText4;
                femaleMillionaireBadAudio4.Play();
                captionBox4.Animate();
                break;
        }
    }


    public void EnableNextButton()
    {
        buttons[buttonCounter].SetActive(true);
    }
}
