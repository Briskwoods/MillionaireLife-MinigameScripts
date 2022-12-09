using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day16CameraParentController : MonoBehaviour
{
    public GameObject m_player;
    public GameObject m_CameraParent;
    public float m_xPos = 0f;
    public float m_yPos;
    public float m_zPos;

    public float marine1Xpos = 6.5f;
    public float airforce1Xpos = 5f;

    public float marine1Ypos = 10f;
    public float airforce1Ypos = 10f;

    public float marine1Zpos = 21.44f;
    public float airforce1Zpos = 26f;

    private float CameraMaxXDirection;
    private float Percent;
    private float MaxPlayer_X = 5f;

    public Day16PlaneSelectionManager planeSelector;
    public bool isMarineOne = false;

    public GameObject Marine1;
    public GameObject Airforce1;

    public void Start()
    {
        isMarineOne = planeSelector.isMarineOne;
        CheckPlane();
    }

    public void LateUpdate()
    {
        switch (m_player != null)
        {
            case true:
                var playerpos = m_player.transform.position;
                playerpos.x = m_xPos;

                Percent = (m_player.transform.position.x / MaxPlayer_X) * CameraMaxXDirection;

                m_CameraParent.transform.position = playerpos + new Vector3(Percent, m_yPos, -m_zPos);

                break;
            case false:
                break;
        }
    }

    public void CheckPlane()
    {
        switch (isMarineOne)
        {
            case true:
                m_player = Marine1;
                m_xPos = marine1Xpos;
                m_yPos = marine1Ypos;
                m_zPos = marine1Zpos;
                break;
            case false:
                m_player = Airforce1;
                m_xPos = airforce1Xpos;
                m_yPos = airforce1Ypos;
                m_zPos = airforce1Zpos;
                break;
        }
    }
}
