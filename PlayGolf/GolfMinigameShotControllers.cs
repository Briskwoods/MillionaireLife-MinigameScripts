using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GolfMinigameShotControllers : MonoBehaviour
{
    public GameObject m_mainCamera;

    public Transform m_shotCameraTarget;

    public GolfMinigameGolfballController golfball;

    public GameObject golfballGO;

    public GameObject holeTapSlider;

    [ContextMenu("Reset Shot")]
    public void Restart()
    {
        m_mainCamera.transform.DOMove(m_shotCameraTarget.position, 3.5f).OnComplete(EnableTapSlider);
        m_mainCamera.transform.DORotateQuaternion(m_shotCameraTarget.rotation, 3.5f);
    }

    public void EnableTapSlider()
    {
        golfball.Restart();
        golfballGO.SetActive(true);
        holeTapSlider.SetActive(true);
    }

    public void DisableTapSlider()
    {
        holeTapSlider.SetActive(false);
    }

    [ContextMenu("Reset Ball")]
    public void ResetBall()
    {
        golfball.Restart();
        golfballGO.SetActive(true);
    }
}
