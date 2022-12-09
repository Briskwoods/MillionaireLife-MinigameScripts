using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSCameraLookAtPlayer : MonoBehaviour
{
    public GameObject m_player;
    public GameObject m_mainCamera;
    public float m_xPos = 0f;
    public float m_yPos;
    public float m_zPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_mainCamera.transform.LookAt(m_player.transform);
    }
}
