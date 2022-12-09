using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMThrowCounterUIController : MonoBehaviour
{
    public RMController runnerMinigameController;

    public List<GameObject> cancels;

    public void ThrowCounter()
    {
        switch (runnerMinigameController.obstaclesHitCount)
        {
            case 1:
                cancels[0].SetActive(true);
                break;
            case 2:
                cancels[1].SetActive(true);
                break;
            case 3:
                cancels[2].SetActive(true);
                break;
        }
    }

    public void OnRestart()
    {
        foreach (GameObject cancel in cancels)
        {
            cancel.SetActive(false);
        }
    }
}
