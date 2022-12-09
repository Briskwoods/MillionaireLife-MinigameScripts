using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day16SFController : MonoBehaviour
{
    public GameObject choosePlane;
    public GameObject planeFlying;

    public void OnFadeIn()
    {
        choosePlane.SetActive(false);
        //planeFlying.SetActive(true);
    }

    public void OnFadeOut()
    {
        choosePlane.SetActive(false);
        planeFlying.SetActive(true);
    }
}
