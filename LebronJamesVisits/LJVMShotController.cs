using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LJVMShotController : MonoBehaviour
{
    public bool isMaleMilli = false;

    public Animator maleMillionaire;
    public Animator femaleMillionaire;

    public float shotDelay;

    public string shoot = "Shoot";

    public LJVMThrowController throwController_;
    public LJVMTouchController touchController_;
    public LJVMBasketballMinigameController basketballMinigameController_;
    public LJVMThrowUIController throwUIController;

    private Vector2 direction;

    public GameObject cam;

    public Transform rotateOrigin;
    public Transform rotateTo;

    public float rotateTime = 0.5f;
    public float cameraTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        isMaleMilli = CodeManager.Instance.PlayerPrefsManager_Script.GetGender();
        //isMaleMilli = false;
    }

    public void TriggerShotJump()
    {
        switch (throwController_.canThrow)
        {
            case true:
                switch (isMaleMilli)
                {
                    case true:
                        maleMillionaire.SetTrigger(shoot);

                        Invoke("Throw", shotDelay);
                        break;
                    case false:
                        femaleMillionaire.SetTrigger(shoot);

                        Invoke("Throw", shotDelay);
                        break;
                }
                break;
            case false:
                Debug.Log("Can't throw");
                break;
        }
        
    }

    public void SetThrowDirection(float X_Dir)
    {
        direction.x = X_Dir;
    }

    public void Throw()
    {
        switch (throwController_.canThrow)
        {
            case true:
                StartCoroutine(RotateBack(cameraTime));
                throwController_.Throw(direction.x);
                //DustbinMinigameController_.throwCounter += 1;
                throwUIController.ThrowCounter();
                basketballMinigameController_.CheckThrowCount();
                break;
            case false:
                Debug.Log("Can't throw");
                break;
        }
    }

    public IEnumerator RotateBack(float seconds)
    {
        cam.transform.DORotateQuaternion(rotateTo.rotation, rotateTime);
        yield return new WaitForSeconds(seconds); // Slight Delay before throwing again        
        cam.transform.DORotateQuaternion(rotateOrigin.rotation, rotateTime);
    }
}
