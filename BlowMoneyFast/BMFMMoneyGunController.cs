using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BMFMMoneyGunController : MonoBehaviour
{
    // Raycast Control Variable
    [SerializeField] private Camera m_mainCamera;

    // Hand Control Variables
    [SerializeField] private GameObject m_gun;

    [Range(1, 100)]
    [SerializeField] private int m_handSpeed = 75;

    private Vector3 m_originalPosition;

    public bool m_isDragging;

    public BMFMGunController gun;

    public Transform Target;

   
    public Vector3 Offset;

    void Start()
    {
        m_originalPosition = transform.position;
        m_gun.transform.position = m_originalPosition;

    }

    // Update is called once per frame
    void Update()
    {
        #region PC Controls
        //PC Controls Test Code, uncoomment if you wish to Test with a mouse instead of Unity Remote 5

        switch (Input.GetMouseButtonDown(0))
        {
            case true:
                m_isDragging = true;
                break;
            case false:
                break;
        }

        switch (Input.GetMouseButtonUp(0))
        {
            case true:
                m_isDragging = false;
                break;
            case false:
                break;
        }
        #endregion

        // Hand Follows Mouse Movement
        Ray ray = m_mainCamera.ScreenPointToRay(Input.mousePosition + Offset);
        switch (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            case true:
                m_gun.transform.position = Vector3.MoveTowards(m_gun.transform.position, raycastHit.point, m_handSpeed);
                //m_gun.transform.LookAt(Target.localPosition);
                //Debug.Log(Input.mousePosition);
                //m_gun.transform.DORotateQuaternion(, 1f);
                break;
            case false: break;
        }

        switch (m_isDragging)
        {
            case true:
                gun.Shoot();
                
                break;
            case false:
                break;
        }
    }
}
