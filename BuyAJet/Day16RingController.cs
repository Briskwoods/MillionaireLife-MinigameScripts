using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day16RingController : MonoBehaviour
{
    public Day16Controller Day16;

    public ParticleSystem Starburst;

    public int counter = 0;

    public Transform CashPoint;

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag == "Plane")
        {
            case true:
                Day16.rings.Remove(this);
                //Day16.CheckWin();
                switch (counter == 0)
                {
                    case true:
                        Starburst.Play();
                        EffectsAndVibration();
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

    public void EffectsAndVibration() 
    {
        //CodeManager.Instance.EconomyManager_Script.IncreaseEconomy(200, CashPoint.position, 10);

        // Haptic Feedback Added on LightImpact - Jeff
        //CodeManager.Instance.HapticsController_.LightImpact();
        CodeManager.Instance.CashManager_Script.IncreaseCash(10000);
    }
}
