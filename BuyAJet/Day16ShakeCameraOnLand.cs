using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day16ShakeCameraOnLand : MonoBehaviour
{
    public CameraShakeScript cameraShake;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag == "Plane")
        {
            case true:
                cameraShake.ShakeNow(1f);


                // Haptic Feedback Added on HeavyImpact - Jeff
                //CodeManager.Instance.HapticsController_.HeavyImpact();
                Vibration.VibratePeek();

                break;
            case false: break;
        }
    }
}
