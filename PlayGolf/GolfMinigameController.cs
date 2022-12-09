using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfMinigameController : MonoBehaviour
{

    public int shotNumber = 0;
    public int maxShots = 4;

    public int goal = 3;
    public int currentScore = 0;

    public Transform MoneySpawnPoint;

    public GolfMinigameSwitchController golfMinigameSwitchController;

    public GolfMinigameShotControllers shot1;
    public GolfMinigameShotControllers shot2;
    public GolfMinigameShotControllers shot3;

    public bool isRestarting = false;

    public GolfMinigameShotCountUIController golfMinigameShotCountUI;

    public void CheckWin()
    {
        switch (currentScore == goal)
        {
            case true:
                Debug.Log("Win");
                golfMinigameSwitchController.SwitchHoles();

                // Haptic Feedback Added on Success - Jeff
                //ControlManager.Instance.HapticsController_.Success();

                //Invoke("NewLevel", 1.5f);
                NewLevel(1.5f);
                break;
            case false:
                golfMinigameSwitchController.SwitchHoles();
                break;
        }

    }

    public void CheckShotCount()
    {
        switch (shotNumber == maxShots)
        {
            case true:
                switch (currentScore == goal)
                {
                    case true:
                        break;
                    case false:
                        golfMinigameSwitchController.canSwitch = false;

                        RestartUIUp();
                        break;
                }
                break;
            case false:
                break;
        }
    }

    public void RestartUIUp()
    {
        isRestarting = true;

        // Restart UI up
        //CodeManager.Instance.TriggerSecondChance_.SecondChanceUI.GetComponent<SecondChance>().AdSuccess += Restart;
        //CodeManager.Instance.TriggerSecondChance_.ShowUI();

    }


    public void Restart()
    {

        switch(currentScore == 0)
        {
            case true:
                golfMinigameShotCountUI.OnRestart();

                isRestarting = false;

                golfMinigameSwitchController.canSwitch = true;

                golfMinigameSwitchController.OnRestart();

                shotNumber = 0;
                currentScore = 0;

                shot1.EnableTapSlider();
                shot2.ResetBall();
                shot3.ResetBall();
                break;
            case false:
                isRestarting = false;

                golfMinigameSwitchController.canSwitch = true;

                golfMinigameSwitchController.OnRestart();

                shotNumber = 0;
                currentScore = 0;

                shot1.Restart();

                shot1.ResetBall();
                shot2.ResetBall();
                shot3.ResetBall();
                break;
        }       
    }

    public void SpawnCash()
    {
        //CodeManager.Instance.EconomyManager_Script.IncreaseEconomy(100, Camera.main.WorldToScreenPoint(MoneySpawnPoint.position), 5);

        CodeManager.Instance.CashManager_Script.IncreaseCash(200000);
    }

    public void NewLevel(float delay)
    {
        //Trigger inter ad
        //TTPManager.Instance.ShowInterstitialAd("AfterPlayingMiniGolf", () =>
        //{
        //    ControlManager.Instance.LevelManager_Script.NextLevel();
        CodeManager.Instance.LevelManager_Script.EndLevel(delay);

        //});
    }
}
