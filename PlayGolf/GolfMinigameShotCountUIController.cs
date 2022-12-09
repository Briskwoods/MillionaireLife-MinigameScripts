using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfMinigameShotCountUIController : MonoBehaviour
{
    public GolfMinigameController golfMinigameController;

    public List<GameObject> cancels;

    public void ThrowCounter()
    {
        switch (golfMinigameController.shotNumber)
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
            case 4:
                cancels[3].SetActive(true);
                break;
            case 5:
                cancels[4].SetActive(true);
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
