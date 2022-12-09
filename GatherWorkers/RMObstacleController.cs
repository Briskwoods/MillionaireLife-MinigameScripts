using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMObstacleController : MonoBehaviour
{
    public CameraShakeScript CameraShakeScript_;
    public RMCameraController RunnerMinigameCameraController_;
    public RMController RunnerMinigameController_;

    public RMThrowCounterUIController uIController;

    public float shakeTime;

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag == "Player")
        {
            case true:
                StartCoroutine(ShakeCamera());

                RunnerMinigameController_.obstaclesHitCount += 1;
                //uIController.ThrowCounter();
                RunnerMinigameController_.CheckObstaclesHit();

                // Haptic Feedback Added on Warning - Jeff
                //CodeManager.Instance.HapticsController_.Warning();
                Vibration.VibratePop();

                break;
            case false:
                break;
        }
    }

    public IEnumerator ShakeCamera()
    {
        CameraShakeScript_.ShakeNow(shakeTime);
        yield return new WaitForSeconds(1f);
        StopCoroutine(ShakeCamera());
    }
}