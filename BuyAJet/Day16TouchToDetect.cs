using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day16TouchToDetect : MonoBehaviour
{
    public Day16PlaneController Marine1;
    public Day16PlaneController Airforce1;

    public Day16PlaneSelectionManager planeSelectionManager;

    public bool isMarine1 = false;

    private void Start()
    {
        isMarine1 = planeSelectionManager.isMarineOne;

        switch (isMarine1)
        {
            case true:
                Marine1.m_flySpeed = 5;
                Marine1.m_fallSpeed = 0;
                break;
            case false:
                Airforce1.m_flySpeed = 5;
                Airforce1.m_fallSpeed = 0;
                break;
        }
       
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (isMarine1)
            {
                case true:
                    Marine1.m_flySpeed = Marine1.originalFlySpeed;
                    Marine1.m_fallSpeed = Marine1.originalFallSpeed;
                    break;
                case false:
                    Airforce1.m_flySpeed = Airforce1.originalFlySpeed;
                    Airforce1.m_fallSpeed = Airforce1.originalFallSpeed;
                    break;
            }
            gameObject.SetActive(false);
        }
    }
}
