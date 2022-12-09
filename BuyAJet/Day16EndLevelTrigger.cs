using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day16EndLevelTrigger : MonoBehaviour
{
    public Day16EndSequence endSequence;


    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag == "Plane")
        {
            case true:
                other.gameObject.GetComponent<Day16PlaneController>().enabled = false;
                endSequence.CheckIfDone();
                break;
            case false: break;
        }
    }

   
}
