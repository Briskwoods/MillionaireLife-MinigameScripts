using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SPCameraController : MonoBehaviour
{
    public GameObject cam;

    public Transform cameraTarget;

    public Transform originalCameraPos;

    public float jumpCameraSpeed;
    public float returnCameraSpeed;

    public SPJumpController jumpController;


    [ContextMenu("OnJump")]
    public void OnJump() 
    {
        cam.transform.DOMove(cameraTarget.position, jumpCameraSpeed);
        cam.transform.DORotateQuaternion(cameraTarget.rotation, jumpCameraSpeed);
    }


    public void ReturnToOrgin()
    {
        cam.transform.DOMove(originalCameraPos.position, returnCameraSpeed);
        cam.transform.DORotateQuaternion(originalCameraPos.rotation, returnCameraSpeed);
    }


    public void OnRestart()
    {
        cam.transform.DOMove(originalCameraPos.position, returnCameraSpeed);
        cam.transform.DORotateQuaternion(originalCameraPos.rotation, returnCameraSpeed).OnComplete(RestartJumpController);
    }

    public void RestartJumpController()
    {
        jumpController.OnRestart();
    }
}
