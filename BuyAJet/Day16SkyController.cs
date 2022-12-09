using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day16SkyController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag == "Plane")
        {
            case true:
                other.gameObject.GetComponent<Day16PlaneController>().m_riseSpeed = 0;
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
                other.gameObject.GetComponent<Day16PlaneController>().m_riseSpeed =
                other.gameObject.GetComponent<Day16PlaneController>().originalRiseSpeed;
                break;
            case false:
                break;

        }
    }
}
