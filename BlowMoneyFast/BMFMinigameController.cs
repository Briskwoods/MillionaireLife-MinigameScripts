using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMFMinigameController : MonoBehaviour
{
    public List<BMFMTargetController> targets = new List<BMFMTargetController>();

    public BMFMMoneyGunController moneyGunController;
    public BMFMGunController gunController; 

    public void CheckWin()
    {
        switch (targets.Count == 0)
        {
            case true:
                moneyGunController.enabled = false;
                gunController.enabled = false;
                //CodeManager.Instance.CashManager_Script.IncreaseCash(500000);

                //Invoke("EndLevel", 1f);
                EndLevel(1f);
                break;
            case false:
                break;
        }
    }

    public void EndLevel(float delay)
    {
        CodeManager.Instance.LevelManager_Script.EndLevel(delay);
    }
}
