using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SPIntroController : MonoBehaviour
{
    public GameObject cam;
    public Transform cameraPoint1;
    public Transform cameraPointFinal;

    public SPTrajectoryController trajectoryController;
    public SPTouchController touchController;
    public GameObject jumpController;
    public GameObject cameraController;
    public GameObject gameManager;

    public LineRenderer trajectoryLine;

    public GameObject Instructions;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CameraIntroZoom", 1.5f);
    }

    public void CameraIntroZoom()
    {
        cam.transform.DORotateQuaternion(cameraPointFinal.rotation, 2f);
        cam.transform.DOMove(cameraPointFinal.position, 2f).OnComplete(OnIntroEnd);
    }

    public void OnIntroEnd()
    {
        trajectoryController.enabled = true;
        touchController.enabled = true;

        jumpController.SetActive(true);
        cameraController.SetActive(true);
        gameManager.SetActive(true);

        trajectoryLine.enabled = true;

        Instructions.SetActive(true);
    }
}
