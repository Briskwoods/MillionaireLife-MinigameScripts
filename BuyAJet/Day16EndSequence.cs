using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Day16EndSequence : MonoBehaviour
{
    public GameObject activePlane;

    public bool isMarineOne = false;

    public Day16PlaneSelectionManager PlaneSelector;

    public GameObject Marine1;
    public GameObject AirForce1;

    public Transform Goal1;
    public Transform Goal2;
    public Transform Goal3;
    public Transform Goal4;

    public void CheckIfDone()
    {
        isMarineOne = PlaneSelector.isMarineOne;

        switch (isMarineOne)
        {
            case true:
                activePlane = Marine1;
                break;
            case false:
                activePlane = AirForce1;
                break;
        }

        activePlane.transform.DOMove(Goal1.position, 3.5f);
    }
}
