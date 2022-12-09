using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day16OceanController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag == "Plane")
        {
            case true:
                other.gameObject.GetComponent<Day16PlaneController>().m_fallSpeed = 0;
                //other.gameObject.GetComponent<Day16PlaneController>().Explode();
                break;
            case false:
                break;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag == "Plane")
        {
            case true:
                other.gameObject.GetComponent<Day16PlaneController>().m_fallSpeed =
                other.gameObject.GetComponent<Day16PlaneController>().originalFallSpeed;
                break;
            case false:
                break;

        }
    }
}
