using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day16Controller : MonoBehaviour
{
    public List<Day16RingController> rings = new List<Day16RingController>();
    public List<Day16RingController> ringsReserve = new List<Day16RingController>();

    public Day16PlaneSelectionManager planeSelectionManager;

    public Transform MoneySpawnPoint;

    public Day16PlaneController marine1;
    public Day16PlaneController airforce1;

    public GameObject Instructions;

    public void CheckWin()
    {
        switch (rings.Count == 0)
        {
            case true:
                Debug.Log("Win!");
                //CodeManager.Instance.EconomyManager_Script.IncreaseEconomy(50, MoneySpawnPoint.position, 22);
                CodeManager.Instance.CashManager_Script.IncreaseCash(200000);

                break;
            case false: break;
        }
    }

    public void RestartUIUp()
    {
        //CodeManager.Instance.TriggerSecondChance_.ShowUI();
        //CodeManager.Instance.TriggerSecondChance_.SecondChanceUI.GetComponent<SecondChance>().AdSuccess += Restart;
    }

    [ContextMenu("Restart")]
    public void Restart()
    {
        switch(planeSelectionManager.isMarineOne)
        {
            case true:
                marine1.gameObject.transform.position = marine1.startPosition;
                marine1.canMove = true;
                marine1.PlaneObject.SetActive(true);
                break;
            case false:
                airforce1.gameObject.transform.position = airforce1.startPosition;
                airforce1.canMove = true;
                airforce1.PlaneObject.SetActive(true);
                break;
        }

        rings.Clear();
        rings = ringsReserve;

        foreach(Day16RingController ring in rings)
        {
            ring.counter = 0;
        }

        Instructions.SetActive(true);
    }
    private void OnDisable()
    {
        //CodeManager.Instance.TriggerSecondChance_.SecondChanceUI.GetComponent<SecondChance>().AdSuccess -= Restart;
    }
}
