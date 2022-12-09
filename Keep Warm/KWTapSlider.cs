using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KWTapSlider : MonoBehaviour
{
    public Animator sliderAnimator;
    public Slider mySlider;
    public float SliderValue;
    public GameObject myUI;
    public WrongAnswer WrongAnswer_;

    public float m_throwHeight = 10f;

    public Transform m_throwPoint;
    public Transform Parent;

    public Rigidbody originalThrowable;

    public Rigidbody dart;

    public Transform Target;

    public GameObject DartPlaceHolder;

    public float force = 10f;

    public KWMinigameController minigameController;

    public bool canThrow = true;

    public bool needsUIDelay = false;

    public void OnEnable()
    {
        sliderAnimator.speed = 1f;
        dart = originalThrowable;
    }

    private void OnDisable()
    {
        StopCoroutine(DelayAfterThrow(0f));
    }

    public void Update()
    {
        SliderValue = mySlider.value;

        if (Input.GetMouseButtonDown(0) && sliderAnimator.speed != 0)
        {
            if (SliderValue > 0.27f && SliderValue < 0.66f)
            {
                sliderAnimator.speed = 0;

                switch (canThrow)
                {
                    case true:
                        needsUIDelay = true;
                        // Throw dart here
                        dart = Instantiate(originalThrowable, m_throwPoint.transform.position, dart.transform.rotation, Parent); // Instantiate Stick to throw at hand position
                        dart.transform.LookAt(Target);
                        dart.AddForce((dart.transform.forward + new Vector3(0, m_throwHeight, 1)) * force, ForceMode.Impulse);// Add force in the Z direction (forward)        
                        dart.AddRelativeTorque(new Vector3(1, 1, 1) * 10f, ForceMode.Impulse); //Add local rotation to the dynamite
                        CheckIfRestart();

                        minigameController.throwCount += 1;
                        Vibration.VibratePop();
                        break;
                    case false:
                        break;
                }

            }
            else
            {
                switch (canThrow)
                {
                    case true:
                        needsUIDelay = false;
                        dart = Instantiate(originalThrowable, m_throwPoint.transform.position, dart.transform.rotation, Parent); // Instantiate Stick to throw at hand position
                        dart.transform.LookAt(Target);
                        dart.AddForce((dart.transform.forward + new Vector3(Random.Range(-.3f, .3f), m_throwHeight, 0.6f)) * (force - .5f), ForceMode.Impulse);// Add force in the Z direction (forward)        
                        dart.AddRelativeTorque(new Vector3(1, 1, 1) * 10f, ForceMode.Impulse); //Add local rotation to the dynamite
                        CodeManager.Instance.CashManager_Script.DecreaseCash(1000);
                        CheckIfRestart();
                        ShakeCamera();


                        break;
                    case false:
                        break;
                }

            }
        }
    }

    public void CheckIfRestart()
    {
        StartCoroutine(DelayAfterThrow(0.5f));
        switch (needsUIDelay)
        {
            case true:
                StartCoroutine(UIDelayAfterThrow(0.51f));
                break;
            case false:
                break;
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

    IEnumerator DelayAfterThrow(float seconds)
    {
        switch (this.enabled)
        {
            case true:
                canThrow = false;
                dart = originalThrowable; // Control Variable
                DartPlaceHolder.SetActive(false);
                yield return new WaitForSeconds(seconds); // Slight Delay before throwing again        
                DartPlaceHolder.SetActive(true);
                canThrow = true;
                break;
            case false:
                break;
        }


    }

    IEnumerator UIDelayAfterThrow(float seconds)
    {
        yield return new WaitForSeconds(seconds); // Slight Delay before throwing again
        myUI.SetActive(false);
    }
}
