using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GolfMinigameSwitchController : MonoBehaviour
{
    public GolfMinigameController golfMinigameController;

    public GameObject mainCamera;

    public GameObject hole1;
    public GameObject hole2;
    public GameObject hole3;

    public GameObject tapSliderForHole2;
    public GameObject tapSliderForHole3;

    public Transform CameraTarget1;
    public Transform CameraTarget2;

    public GolfMinigameCrowdController crowdController;

    public bool canSwitch = true;


    public void SwitchHoles()
    {
        switch (canSwitch)
        {
            case true:
                switch (golfMinigameController.currentScore)
                {
                    case 0:
                        break;
                    case 1:
                        crowdController.Dance();
                        Invoke("SwitchHole1", 2f);
                        break;
                    case 2:
                        crowdController.Dance();
                        Invoke("SwitchHole2", 2f);
                        break;
                    case 3:
                        crowdController.Dance();
                        break;
                }
                break;
            case false:
                break;
        }
    }

    public void SwitchHole1()
    {
        hole1.SetActive(false);
        hole2.SetActive(true);
        crowdController.IdleAnim();
        mainCamera.transform.DOMove(CameraTarget1.position, 3.5f);
        mainCamera.transform.DORotateQuaternion(CameraTarget1.rotation, 3.5f).OnComplete(SetSlider1Active);
    }

    public void SwitchHole2()
    {
        hole2.SetActive(false);
        hole3.SetActive(true);
        crowdController.IdleAnim();
        mainCamera.transform.DOMove(CameraTarget2.position, 3.5f);
        mainCamera.transform.DORotateQuaternion(CameraTarget2.rotation, 3.5f).OnComplete(SetSlider2Active);
    }

    public void SetSlider1Active()
    {
        tapSliderForHole2.SetActive(true);
    }

    public void SetSlider2Active()
    {
        tapSliderForHole3.SetActive(true);
    }

    public void OnRestart()
    {
        hole1.SetActive(true);
        hole2.SetActive(false);
        hole3.SetActive(false);
    }
}
