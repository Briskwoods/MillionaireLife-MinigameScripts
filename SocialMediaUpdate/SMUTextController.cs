using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;


public class SMUTextController : MonoBehaviour
{
    [TextArea(3, 4)] public string goodText1;
    [TextArea(3, 4)] public string badText1;

    [TextArea(3, 4)] public string goodText2;
    [TextArea(3, 4)] public string badText2;

    [TextArea(3, 4)] public string goodText3;
    [TextArea(3, 4)] public string badText3;

    [TextArea(3, 4)] public string goodText4;
    [TextArea(3, 4)] public string badText4;

    public TextMeshProUGUI goodButton1Txt;
    public TextMeshProUGUI badButton1Txt;
    public TextMeshProUGUI goodButton2Txt;
    public TextMeshProUGUI badButton2Txt;
    public TextMeshProUGUI goodButton3Txt;
    public TextMeshProUGUI badButton3Txt;
    public TextMeshProUGUI goodButton4Txt;
    public TextMeshProUGUI badButton4Txt;

    // Start is called before the first frame update
    void Start()
    {
        LoadTexts();
    }

    public void LoadTexts()
    {
        goodButton1Txt.SetText(goodText1);
        badButton1Txt.SetText(badText1);
        goodButton2Txt.SetText(goodText2);
        badButton2Txt.SetText(badText2);
        goodButton3Txt.SetText(goodText3);
        badButton3Txt.SetText(badText3);
        goodButton4Txt.SetText(goodText4);
        badButton4Txt.SetText(badText4);
        }


}
