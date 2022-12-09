using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMController : MonoBehaviour
{
    public CharacterBehaviourManager Character_;
    public List<Animator> runners = new List<Animator>();

    public List<Animator> supporters = new List<Animator>();

    public Transform MoneySpawnPoint;

    public int obstaclesHitCount = 0;
    public int maxObstaclesHitCount = 3;

    public int SupporterSize = 0;
    public int endGoal = 7;

    public PlayerMovement playerMovement;

    public List<GameObject> runnersOnPlayer;

    public List<GameObject> supportersToCollect;

    public GameObject Instructions;
    public GameObject SwipeUnderInstructions;

    public RMThrowCounterUIController runnerMinigameThrowCounterUIController;
    private void OnDisable()
    {
        //CodeManager.Instance.TriggerSecondChance_.SecondChanceUI.GetComponent<SecondChance>().AdSuccess -= onRestart;
    }

    public void CheckWin() {

        switch (SupporterSize == endGoal)
        {
            case true:
                // Haptic Feedback Added on Success - Jeff
                //CodeManager.Instance.HapticsController_.Success();
                Vibration.VibratePeek();

                Character_.SetAnimation("Dance");

                foreach (Animator runner in runners)
                {
                    runner.SetTrigger("Dance");
                }

                //Invoke("EndLevel", 1f);
                EndLevel(1f);

                break;
            case false:
                // Haptic Feedback Added on Success - Jeff
                //CodeManager.Instance.HapticsController_.Success();
                Vibration.VibratePeek();

                Character_.SetAnimation("Dance");

                foreach (Animator runner in runners)
                {
                    runner.SetTrigger("Dance");
                }

                //Invoke("EndLevel", 1f);
                EndLevel(2f);

                Debug.Log("Lose");
                break;
        }
    }

    public void CheckObstaclesHit()
    {
        switch (obstaclesHitCount == maxObstaclesHitCount)
        {
            case true:
                playerMovement.enabled = false;
                Character_.SetAnimation("Lose");

                foreach (Animator runner in runners)
                {
                    runner.SetTrigger("Lose");
                }
                RestartUIUp();
                break;
            case false:
                break;
        }
    }

    public void RestartUIUp()
    {
        // Restart UI up
        //CodeManager.Instance.TriggerSecondChance_.SecondChanceUI.GetComponent<SecondChance>().AdSuccess += onRestart;
        //CodeManager.Instance.TriggerSecondChance_.ShowUI();
    }

    [ContextMenu("Restart")]
    public void onRestart()
    {
        // Restart UI Down

        // Reset everything
        runnerMinigameThrowCounterUIController.OnRestart();
        SupporterSize = 0;
        obstaclesHitCount = 0;

        foreach(GameObject runner in runnersOnPlayer)
        {
            runner.SetActive(false);
        }

        foreach (GameObject supporter in supportersToCollect)
        {
            supporter.SetActive(true);
            supporter.GetComponent<RMRunnerTrigger>().OnRestart();
        }

        foreach(Animator supporter in supporters)
        {
            supporter.SetTrigger("Restart");
        }

        playerMovement.enabled = false;
        Character_.SetAnimation("Idle");

        playerMovement.gameObject.transform.position = playerMovement.startpos;

        Instructions.SetActive(true);
        SwipeUnderInstructions.SetActive(true);

    }

    public void EndLevel(float delay) 
    {
        ////End of Level, trigger inter
        //TTPManager.Instance.ShowInterstitialAd("AfterCollectWorkers", () =>
        //{
              CodeManager.Instance.LevelManager_Script.EndLevel(delay);

        //});
    }
}
