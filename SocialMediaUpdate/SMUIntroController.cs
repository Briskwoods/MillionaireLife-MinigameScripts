using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SMUIntroController : MonoBehaviour
{
    public GameObject millionaire;

    public GameObject cam;

    public Transform cameraPointFinal;

    public bool isMaleMillionaire = false;

    public GameObject firstButtons;

    public SMUQueueController queueController;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("CameraIntroZoom", 1.5f);
        GetPresidentGender();
    }

    public void GetPresidentGender()
    {
        isMaleMillionaire = CodeManager.Instance.PlayerPrefsManager_Script.GetGender();
    }

    public void CameraIntroZoom()
    {
        cam.transform.DOMove(cameraPointFinal.position, 2f);
        cam.transform.DORotateQuaternion(cameraPointFinal.rotation, 2f).OnComplete(BeginLevel);
    }

    public void BeginLevel()
    {
        millionaire.SetActive(false);

        firstButtons.SetActive(true);

        queueController.OnLevelStart();
    }
}
