using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMMinigameController : MonoBehaviour
{
    public SMQueueManager queueManager;
    public Transform MoneySpawnPoint;
    public GameObject Staff;

    private void Start()
    {
        //Invoke("CallQueue", 2f);
    }

    public void CallQueue()
    {
        queueManager.CallQueue();
    }

    [ContextMenu("On End")]
    public void CheckIfOver()
    {
        switch (queueManager.noInQueue == queueManager.maxQueueSize)
        {
            case true:
                //CodeManager.Instance.EconomyManager_Script.IncreaseEconomy(200, Camera.main.WorldToScreenPoint(MoneySpawnPoint.position), 10);
                Invoke("ataffDance", 3f);
                NewLevel();
                break;
            case false:
                break;
        }
    }

    public void SpawnCash()
    {
        //CodeManager.Instance.EconomyManager_Script.IncreaseEconomy(100, Camera.main.WorldToScreenPoint(MoneySpawnPoint.position), 5);
    }
    public void ataffDance()
    {
        Staff.GetComponent<Animator>().Play("Dance");
    }
    public void NewLevel()
    {

        //Trigger inter ad
        //TTPManager.Instance.ShowInterstitialAd("AfterPlayingSearchMinigame", () =>
        //{
        //    
        //});
        Debug.Log("finished");
        CodeManager.Instance.LevelManager_Script.EndLevel(5);
    }
}
