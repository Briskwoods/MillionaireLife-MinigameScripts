using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMDetectFirstTouch : MonoBehaviour
{
    public PlayerMovement playerMovement;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerMovement.enabled = true;
            gameObject.SetActive(false);
        }
    }
}