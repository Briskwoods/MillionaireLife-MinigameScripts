using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GolfMinigameTapSlider : MonoBehaviour
{
    public Animator sliderAnimator;
    public Slider mySlider;
    public float SliderValue;
    public GameObject myUI;
    public WrongAnswer WrongAnswer_;

    public Animator golfClub;

    public GolfMinigameController golfMinigameController;

    public GolfMinigameShotCountUIController golfMinigameShotCountUI;

    public void OnEnable()
    {
        sliderAnimator.speed = 1f;
    }

    public void Update()
    {
        SliderValue = mySlider.value;

        if (Input.GetMouseButtonDown(0) && sliderAnimator.speed != 0) 
        {
            if (SliderValue > 0.27f && SliderValue < 0.66f)
            {
                golfMinigameController.shotNumber += 1;
                golfMinigameShotCountUI.ThrowCounter();
                sliderAnimator.speed = 0;
                myUI.SetActive(false);
                golfClub.SetTrigger("Swing");

                // Haptic Feedback Added on Tap - Jeff
                //CodeManager.Instance.HapticsController_.Selection();
            }
            else
            {
                golfClub.SetTrigger("SwingII");
                //StartCoroutine(EnableAfterDelay());
                //golfMinigameController.shotNumber += 1;
                golfMinigameShotCountUI.ThrowCounter();
                golfMinigameController.CheckShotCount();
                ShakeCamera();
                myUI.SetActive(false);

                // lose money
                CodeManager.Instance.CashManager_Script.DecreaseCash(1000);

            }
        }
    }

    public void ShakeCamera() 
    {
        Vibration.Vibrate();
        CancelInvoke("DisableCamera");
        WrongAnswer_.enabled = true;
        WrongAnswer_.TriggerWrongTap();
        Invoke("DisableCamera", 0.6f);
    }

    public void DisableCamera() 
    {
        WrongAnswer_.enabled = false;
    }
}
