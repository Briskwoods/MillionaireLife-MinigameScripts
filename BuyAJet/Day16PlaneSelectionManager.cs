using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day16PlaneSelectionManager : MonoBehaviour
{
    public GameObject Marine1;
    public GameObject AirForce1;


    public bool isMarineOne = false;


    public void SelectMarineOne()
    {
        Marine1.SetActive(true);
        isMarineOne = true;
        AirForce1.SetActive(false);
    }


    public void SelectAirForceOne()
    {
        isMarineOne = false;
        Marine1.SetActive(false);
        AirForce1.SetActive(true);
    }
}
