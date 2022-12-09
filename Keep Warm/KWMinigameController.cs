using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class KWMinigameController : MonoBehaviour
{
    public int throwCount = 0;
    public int maxThrows = 2;

    public int goal = 1;
    public int currentScore = 0;

    public Transform MoneySpawnPoint;

    public Slider Score;

    public GameObject canvas;

    [ContextMenu("Check Win")]
    // Use at end of level
    public void CheckWin()
    {
        switch (throwCount < maxThrows)
        {
            case true:
                switch (currentScore == goal)
                {
                    case true:
                        Debug.Log(true);

                        Score.DOValue(currentScore, 0.5f);
                        CodeManager.Instance.CashManager_Script.IncreaseCash(10000);

                        //Invoke("NewLevel", 2.8f);
                        NewLevel(2.8f);
                        break;
                    case false:
                        // Retry can be placed here
                        Debug.Log(false);

                        Score.DOValue(currentScore, 0.5f);

                        CodeManager.Instance.CashManager_Script.IncreaseCash(200000);
                        break;
                }
                break;
            case false:
                switch (currentScore == goal)
                {
                    case true:
                        Debug.Log(true);

                        Score.DOValue(currentScore, 0.5f);
                        CodeManager.Instance.CashManager_Script.IncreaseCash(200000);

                        //Invoke("NewLevel", 2.8f);
                        NewLevel(2.8f);
                        break;
                    case false:
                        break;
                }
                break;
        }
    }

    public void NewLevel(float delay)
    {
        canvas.SetActive(false);
        //TTPManager.Instance.ShowInterstitialAd("AfterKeepWarmMinigame", () =>
        //{
        //    ControlManager.Instance.LevelManager_Script.NextLevel();
        CodeManager.Instance.LevelManager_Script.EndLevel(delay);
        //});
    }
    
}
