using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPGameManager : MonoBehaviour
{
    public bool isDiving = false;

    public bool presidentSaved = false;

    public bool presidentShot = false;

    public float timeScaleSlowSpeed = 0.7f;

    public float normalTimeSpeed = 1f;

    public int maxTries = 5;
    public int tryCount = 0;

    public Transform MoneySpawnPoint;

    public Transform policeParent;

    public SPJumpController jumpController;
    public SPCameraController cameraController;
    public SPTouchController touchController;

    public List<SPChairController> chairs = new List<SPChairController>();
    public void OnJump()
    {
        Time.timeScale = timeScaleSlowSpeed;
    }

    public void OnJumpEnd()
    {
        Time.timeScale = normalTimeSpeed;
    }

    public void CheckIfDone()
    {
        switch (tryCount == maxTries)
        {
            case true:
                switch (presidentSaved)
                {
                    case true:
                        //Win
                        Debug.Log("Win");
                        // Stop everything
                        jumpController.enabled = false;
                        cameraController.enabled = false;
                        touchController.enabled = false;

                        //CodeManager.Instance.EconomyManager_Script.IncreaseEconomy(200, Camera.main.WorldToScreenPoint(MoneySpawnPoint.position), 10);
                        //CodeManager.Instance.CashManager_Script.IncreaseCash(200000);

                        //Invoke("NewLevel", 2f);
                        NewLevel(2f);
                        break;
                    case false:
                        //Lose
                        Debug.Log("Lose");

                        // Stop everything
                        jumpController.enabled = false;
                        cameraController.enabled = false;
                        touchController.enabled = false;

                        RestartUIUp();

                        break;
                }
                break;

            case false:
                switch (presidentSaved)
                {
                    case true:
                        //Win
                        Debug.Log("Win");
                        // Stop everything
                        jumpController.enabled = false;
                        cameraController.enabled = false;
                        touchController.enabled = false;

                        //CodeManager.Instance.EconomyManager_Script.IncreaseEconomy(200, Camera.main.WorldToScreenPoint(MoneySpawnPoint.position), 10);
                        //CodeManager.Instance.CashManager_Script.IncreaseCash(200000);


                        //Invoke("NewLevel", 2f);
                        NewLevel(2f);
                        break;
                    case false:
                        // Next Try
                        Debug.Log("Next Try");

                        // Decreasee cash on miss
                        CodeManager.Instance.CashManager_Script.DecreaseCash(1000);

                        isDiving = false;
                        break;
                }
                break;
        }
    }


    [ContextMenu("Restart")]
    public void Restart()
    {
        Debug.Log("Restart UI Down");

        //dMThrowCounter.OnRestart();

        jumpController.enabled = enabled;
        cameraController.enabled = enabled;
        touchController.enabled = enabled;

        tryCount = 0;
        isDiving = false;
        presidentSaved = false;
        presidentShot = false;

        // Delete Officers in darts parents
        foreach (Transform officer in policeParent)
        {
            GameObject.Destroy(officer.gameObject);
        }

        // Reset the chairs
        foreach(SPChairController chair in chairs)
        {
            chair.Restart();
        }

        cameraController.OnRestart();
    }

    public void RestartUIUp()
    {
        // Restart UI up
        //CodeManager.Instance.TriggerSecondChance_.SecondChanceUI.GetComponent<SecondChance>().AdSuccess += Restart;
        //CodeManager.Instance.TriggerSecondChance_.ShowUI();
    }

    public void NewLevel(float delay)
    {
        //TTPManager.Instance.ShowInterstitialAd("AfterSaveMillionaireMinigame", () =>
        //{
        //    ControlManager.Instance.LevelManager_Script.NextLevel();
        CodeManager.Instance.LevelManager_Script.EndLevel(delay);
        //});
    }

}
