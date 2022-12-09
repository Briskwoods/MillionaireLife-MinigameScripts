using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfMinigameHoleController : MonoBehaviour
{
    public ParticleSystem starburst;

    public GolfMinigameController golfMinigameController;

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag == "GolfBall")
        {
            case true:
                golfMinigameController.currentScore += 1;
                other.gameObject.SetActive(false);
                golfMinigameController.CheckShotCount();
                golfMinigameController.CheckWin();
                starburst.Play();

                CodeManager.Instance.CashManager_Script.IncreaseCash(10000);
                break;
            case false:
                break;
        }
    }
}
