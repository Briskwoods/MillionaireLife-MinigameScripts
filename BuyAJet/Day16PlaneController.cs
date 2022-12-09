using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Day16PlaneController : MonoBehaviour
{
    public float m_flySpeed;
    public float m_riseSpeed;
    public float m_fallSpeed;

    public float originalFlySpeed;
    public float originalFallSpeed;
    public float originalRiseSpeed;

    public bool m_isDragging;

    public ParticleSystem Explosion;

    public GameObject PlaneObject;

    public Vector3 startPosition;

    public bool canMove = true;

    public Day16Controller day16Controller;

    private void Start()
    {
        originalFlySpeed = m_flySpeed;
        originalFallSpeed = m_fallSpeed;
        originalRiseSpeed = m_riseSpeed;

        startPosition = this.transform.position;
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
                Reset();
                break;
            case false:
                break;
        }
        #endregion

        #region Mobile Controls
        switch (Input.touches.Length > 0)
        {
            case true:
                switch (Input.touches[0].phase == TouchPhase.Began)
                {
                    case true:
                        m_isDragging = true;
                        break;
                    case false:
                        break;
                }
                switch (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                {
                    case true:
                        m_isDragging = false;
                        Reset();
                        break;
                    case false:
                        break;
                }
                break;
            case false:
                break;
        }
        #endregion


        switch (canMove)
        {
            case true:

                transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.forward * 10, m_flySpeed * Time.deltaTime);

                switch (m_isDragging)
                {
                    case true:
                        // Plane rotates up
                        transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.up * m_riseSpeed), m_flySpeed * Time.deltaTime);
                        transform.LookAt(Vector3.up * 2 * Time.deltaTime);
                        //transform.DORotateQuaternion(Quaternion.Euler(60, 180, 0), 5);
                        break;
                    case false:
                        // plane rotates down
                        transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.down * m_fallSpeed), m_flySpeed * Time.deltaTime);
                        //transform.DORotateQuaternion(Quaternion.Euler(-60, 180, 0), 5);
                        transform.LookAt(Vector3.down * 2 * Time.deltaTime);
                        break;
                }
                break;
            case false:
                break;
        }
       
    }


    public void Explode()
    {
        PlaneObject.SetActive(false);
        Explosion.Play();
        canMove = false;
        Invoke("UIUp", 1f);
    }

    public void UIUp()
    {
        day16Controller.RestartUIUp();
    }

    public void LateUpdate()
    {
       
    }

    private void Reset()
    {
        //m_startTouch = m_swipeDelta = Vector2.zero;
        m_isDragging = false;
    }
}
