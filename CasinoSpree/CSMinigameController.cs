using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSMinigameController : MonoBehaviour
{
    public CSSwitchController switchController;
    public CSInputReciever InputReciever;

    public void BeginLevel()
    {
        switchController.SwitchSlotMachines();
        InputReciever.enabled = true;
    }

    public void EndLevel(float delay)
    {
        Debug.Log("Level Over");
        CodeManager.Instance.LevelManager_Script.EndLevel(delay);
    }
}
