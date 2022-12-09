using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LJVMBasketballMinigameController : MonoBehaviour
{
    public int throwCounter = 0;
    public int maxthrows = 3;

    public int goal = 3;
    public int currentScore = 0;

    public Transform MoneySpawnPoint;

    public ParticleSystem startBurst;

    public LJVMThrowController ThrowController_;
    public LJVMTouchController TouchController_;

    public Slider Score;

    public GameObject basketball;

    public LJVMThrowUIController throwUIController;

    public GameObject shotSlider;

    private void OnDisable()
    {
        //ControlManager.Instance.TriggerSecondChance_.SecondChanceUI.GetComponent<SecondChance>().AdSuccess -= Restart;
    }

    private void Start()
    {
        Score.value = 0;
    }
    public void CheckWin()
    {
        switch (currentScore == goal)
        {
            case true:
                shotSlider.SetActive(false);
                ThrowController_.enabled = false;
                TouchController_.enabled = false;
                Score.DOValue(currentScore, 0.5f);
                startBurst.Play();

                Invoke("SpawnCash", 0.1f);

                //Invoke("NewLevel", 1.5f);
                NewLevel(1.5f);
                break;
            case false:
                Score.DOValue(currentScore, 0.5f);
                startBurst.Play();

                Invoke("SpawnCash", 0.1f);

                break;
        }
    }

    public void CheckThrowCount()
    {
        switch (throwCounter == maxthrows)
        {
            case true:
                StartCoroutine(DelayAfterThrow(2.5f));
                break;
            case false:
                break;
        }
    }

    public void SpawnCash()
    {
        //ControlManager.Instance.EconomyManager_Script.IncreaseEconomy(100, Camera.main.WorldToScreenPoint(MoneySpawnPoint.position), 5);
        CodeManager.Instance.CashManager_Script.IncreaseCash(10000);

    }

    public void NewLevel(float delay)
    {
        //TTPManager.Instance.ShowInterstitialAd("AfterLebrawnJaymesVisit", () =>
        //{
        //    ControlManager.Instance.LevelManager_Script.NextLevel();
        //CodeManager.Instance.CashManager_Script.IncreaseCash(30000);

        CodeManager.Instance.LevelManager_Script.EndLevel(delay);
        //});
    }

    public void LevelFailed()
    {
        // Disable throwing 
        ThrowController_.enabled = false;
        TouchController_.enabled = false;
        // Bring up fail ui with retry button
        Debug.Log("UI Up");
        //ControlManager.Instance.TriggerSecondChance_.ShowUI();
        //ControlManager.Instance.TriggerSecondChance_.SecondChanceUI.GetComponent<SecondChance>().AdSuccess += Restart;
        // Hide paper
        basketball.SetActive(false);
    }


    [ContextMenu("Restart")]

    public void Restart()
    {
        throwUIController.OnRestart();
        // Enable throwing 
        ThrowController_.enabled = true;
        TouchController_.enabled = true;
        // Hide ui for retry
        Debug.Log("UI Down");
        // reset variables
        throwCounter = 0;
        currentScore = 0;
        // Set paper back to visible
        basketball.SetActive(true);
        // Reset Slider
        Score.value = 0;

    }

    IEnumerator DelayAfterThrow(float seconds)
    {
        yield return new WaitForSeconds(seconds); // Slight Delay before throwing again        
        switch (currentScore == goal)
        {
            case true:
                Debug.Log(currentScore);
                break;
            case false:
                Debug.Log(currentScore);
                LevelFailed();
                break;
        }

    }
}
