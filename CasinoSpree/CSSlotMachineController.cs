using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSSlotMachineController : MonoBehaviour
{
    public bool canPullHandle = false;

    public List<CSIndividualSlotMachineController> individualSlotMachines = new List<CSIndividualSlotMachineController>();

    public int counter = 0;


    public void Pull()
    {
        switch (counter)
        {
            case 0:
                Debug.Log("Pulled 1");
                individualSlotMachines[counter].OnPulled();
                canPullHandle = false;
                counter++;
                break;
            case 1:
                Debug.Log("Pulled 2");
                individualSlotMachines[counter].OnPulled();
                canPullHandle = false;
                counter++;
                break;
            case 2:
                Debug.Log("Pulled 3");
                individualSlotMachines[counter].OnRandomPulled();
                canPullHandle = false;
                counter++;
                break;

        }

    }
}
