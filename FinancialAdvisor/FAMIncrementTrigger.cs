using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAMIncrementTrigger : MonoBehaviour
{
    public bool isIncreasing = false;
    public FAMGraphController graphController;

    public int counter = 0;

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag == "FAMGraphDot")
        {
            case true:
                switch (counter == 0)
                {
                    case true:
                        graphController.isIncreasing = isIncreasing;
                        counter++;
                        break;
                    case false:
                        break;
                }
                break;
            case false:
                break;
        }
    }
}
