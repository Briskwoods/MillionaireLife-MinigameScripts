using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SMUOutroController : MonoBehaviour
{
    public GameObject millionaire;

    public GameObject cam;

    public Transform cameraOriginPoint;

    public SMUMinigameController minigameController;

    [ContextMenu("End Level")]
    public void CameraZoomOut()
    {
        millionaire.SetActive(true);
        cam.transform.DOMove(cameraOriginPoint.position, 2f);
        cam.transform.DORotateQuaternion(cameraOriginPoint.rotation, 2f).OnComplete(EndLevel);
    }

    public void EndLevel()
    {
        float delay = 0;
        minigameController.EndLevel(delay);
    }
}
