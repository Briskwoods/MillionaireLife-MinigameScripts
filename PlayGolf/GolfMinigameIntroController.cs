using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GolfMinigameIntroController : MonoBehaviour
{
    public GameObject m_mainCamera;

    public Transform m_cameraTarget1;

    public GameObject m_firstSlider;

    public GameObject m_presidents;

    public GameObject m_firstGolfClub;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("IntroSequence", 2f);
        
    }

    public void IntroSequence()
    {
        m_mainCamera.transform.DOMove(m_cameraTarget1.position, 2.5f).OnComplete(DisableAndEnable);
        Invoke("DisablePresidentAndEnableClub", 2f);
        Invoke("RotateCamera", 2f);
    }

    public void DisableAndEnable()
    {
        m_firstSlider.SetActive(true);
    }

    public void DisablePresidentAndEnableClub()
    {

        m_presidents.SetActive(false);
        m_firstGolfClub.SetActive(true);
    }

    public void RotateCamera()
    {
        m_mainCamera.transform.DORotateQuaternion(m_cameraTarget1.rotation, 1f);
    }
}
