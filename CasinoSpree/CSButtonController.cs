using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CSButtonController : MonoBehaviour
{
    public bool isMaleMillionaire = false;

    [TextArea(3, 4)]
    public string goodBtnWords;
    [TextArea(3, 4)]
    public string badBtnWords;

    public TextMeshProUGUI goodBtnText;
    public TextMeshProUGUI badBtnText;

    public AudioSource goodBtnAudioMM;
    public AudioSource badBtnAudioMM;
    public AudioSource goodBtnAudioFM;
    public AudioSource badBtnAudioFM;

    public CSSwitchController switchController;
    public CSOutroController outroController;

    public float goodAudioDelay = 2f;
    public float badAudioDelay = 2f;

    public GameObject buttons;

    void Start()
    {
        isMaleMillionaire = CodeManager.Instance.PlayerPrefsManager_Script.GetGender();
    }

    public void EnableButtons()
    {
        buttons.SetActive(true);
    }

    public void LoadButtonDetails()
    {
        goodBtnText.SetText(goodBtnWords);
        badBtnText.SetText(badBtnWords);
    }

    public void GoodClicked()
    {
        switch (isMaleMillionaire)
        {
            case true:
                goodBtnAudioMM.Play();
                break;
            case false:
                goodBtnAudioFM.Play();
                break;
        }

        Invoke("TryThirdSlotMachine", goodAudioDelay);
    }

    public void BadClicked()
    {

        switch (isMaleMillionaire)
        {
            case true:
                badBtnAudioMM.Play();
                break;
            case false:
                badBtnAudioFM.Play();
                break;
        }

        Invoke("CallLoseOutro", badAudioDelay);
    }


    public void TryThirdSlotMachine()
    {
        switchController.SwitchSlotMachines();
    }

    public void CallLoseOutro()
    {
        outroController.OnLoseOutroCalled();
    }
}
