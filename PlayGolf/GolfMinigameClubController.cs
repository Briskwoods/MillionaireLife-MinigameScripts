using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfMinigameClubController : MonoBehaviour
{
    public Rigidbody golfball;

    public float force = 10f;

    public GameObject myUI;

    public GolfMinigameController golfMinigameController;

    //public Transform m_shootPoint;
    //public Transform Parent;

    //public Rigidbody originalThrowable;


    [ContextMenu("Test")]
    public void OnSwing()
    {
        golfball.AddForce(golfball.transform.forward * force);
        golfball.AddRelativeTorque(new Vector3(1, 1, 1) * 10f, ForceMode.Impulse); //Add local rotation to the dynamite

        // Haptic Feedback Added on MediumImpact - Jeff
        //CodeManager.Instance.HapticsController_.MediumImpact();
        Vibration.VibratePop();
    }

    //[ContextMenu("Test II")]
    public void OnFalseSwing()
    {
        //golfball = Instantiate(originalThrowable, m_shootPoint.transform.position, golfball.transform.rotation, Parent); // Instantiate Stick to throw at hand position

        //golfball.AddForce(golfball.transform.forward + new Vector3(Random.Range(-.1f, .1f), 0f, 0f) * force);
        //golfball.AddRelativeTorque(new Vector3(1, 1, 1) * 10f, ForceMode.Impulse); //Add local rotation to the dynamite

        //// Haptic Feedback Added on MediumImpact - Jeff
        //ControlManager.Instance.HapticsController_.MediumImpact();
    }

    public void DisableAfterSwing()
    {
        this.gameObject.SetActive(false);
    }


    [ContextMenu("Test II")]
    public void EnableUI()
    {
        switch (golfMinigameController.isRestarting)
        {
            case true:
                break;
            case false:
                myUI.SetActive(true);
                break;
        }
    }
}
