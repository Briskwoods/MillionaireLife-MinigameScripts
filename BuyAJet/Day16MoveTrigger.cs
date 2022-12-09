using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Day16MoveTrigger : MonoBehaviour
{
    public GameObject activePlane;

    public Day16PlaneSelectionManager PlaneSelector;

    public Transform Goal;

    public GameObject Marine1;
    public GameObject AirForce1;

    public void Start()
    {
        switch (PlaneSelector.isMarineOne)
        {
            case true:
                activePlane = Marine1;
                break;
            case false:
                activePlane = AirForce1;
                break;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag == "Plane")
        {
            case true:
               activePlane.transform.DOMove(Goal.position, 3.5f);
                break;
            case false: break;
        }
    }
}
