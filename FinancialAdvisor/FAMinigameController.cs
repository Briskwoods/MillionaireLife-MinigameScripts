using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FAMinigameController : MonoBehaviour
{
    public Transform MoneySpawnPoint;

    public FAMGraphController graphController;
    public FAMButtonController buttonController;

    public GameObject Instructions;
    public GameObject SwipeUnderInstructions;

    private void OnDisable()
    {
        //CodeManager.Instance.TriggerSecondChance_.SecondChanceUI.GetComponent<SecondChance>().AdSuccess -= onRestart;
    }

    public void CheckWinLose(int profitEarned, int goal)
    {
        switch (graphController.isComplete)
        {
            case true:
                switch (profitEarned >= goal)
                {
                    case true:
                        graphController.PauseGraphMotion();
                        // Haptic Feedback Added on Success - Jeff
                        //CodeManager.Instance.HapticsController_.Success();
                        Vibration.VibratePeek();
                        //Invoke("EndLevel", 1f);
                        EndLevel(1f);

                        break;
                    case false:
                        // Haptic Feedback Added on Success - Jeff
                        //CodeManager.Instance.HapticsController_.Success();
                        Vibration.VibratePeek();

                        //Invoke("EndLevel", 1f);

                        EndLevel(1f);

                        //RestartUIUp();

                        Debug.Log("Lose");
                        break;
                }
                break;
            case false:
                switch (profitEarned >= goal)
                {
                    case true:
                        // Haptic Feedback Added on Success - Jeff
                        //CodeManager.Instance.HapticsController_.Success();
                        Vibration.VibratePeek();
                        graphController.PauseGraphMotion();

                        //Invoke("EndLevel", 1f);
                        EndLevel(1f);


                        break;
                    case false:
                        break;
                }
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
        graphController.OnRestart();
       
        //graphDot.gameObject.transform.position = graphdot.startpos;

        Instructions.SetActive(true);
        SwipeUnderInstructions.SetActive(true);

    }

    public void EndLevel(float delay)
    {
        ////End of Level, trigger inter
        //TTPManager.Instance.ShowInterstitialAd("AfterFinancialAdvisor", () =>
        //{

        CodeManager.Instance.CashManager_Script.IncreaseCash(graphController.totalProfit);
        CodeManager.Instance.LevelManager_Script.EndLevel(delay);

        //});
    }
}
