using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPTouchController : MonoBehaviour
{
    #region Unused Variable
    private bool m_tap;
    private bool m_swipeLeft;
    private bool m_swipeRight;
    private bool m_swipeUp;
    private bool m_swipeDown;
    #endregion

    #region Private Bools

    public bool m_isDragging;
    #endregion

    private Vector2 direction;
    private float m_startMoveDistance;

    [HideInInspector] public Vector2 m_startPosition;
    [HideInInspector] public Vector2 m_endPosition;
    public Vector2 m_swipeDelta;

    public float swipeDeltaXConstraintMax = 650f;
    public float swipeDeltaXConstraintMin = 400f;
    public float swipeDeltaYConstraintMax = 450f;
    public float swipeDeltaYConstraintMin = 350f;

    public SPJumpController jumpController;

    public SPTrajectoryController trajectoryController;
    public int switchCount = 0;

    public Animator officerAnim;

    // Update is called once per frame
    void Update()
    {
        m_tap = m_swipeLeft = m_swipeRight = m_swipeUp = m_swipeDown = false;

        

        #region PC Controls
        //PC Controls Test Code, uncoomment if you wish to Test with a mouse instead of Unity Remote 5

        switch (Input.GetMouseButtonDown(0))
        {
            case true:
                m_isDragging = true;
                m_tap = true;
                m_startPosition = Input.mousePosition;
                break;
            case false:
                break;
        }

        switch (Input.GetMouseButtonUp(0))
        {
            case true:
                m_endPosition = Input.mousePosition;
                switch (jumpController.canThrow)
                {
                    case true:
                        switch(m_swipeDelta.x > swipeDeltaXConstraintMin)
                        {
                            case true:
                                switch(m_swipeDelta.y > swipeDeltaYConstraintMin)
                                {
                                    case true:
                                        jumpController.Throw(Mathf.Abs(m_swipeDelta.x), Mathf.Abs(m_swipeDelta.y));
                                        break;
                                    case false:
                                        break;
                                }
                                break;
                            case false:
                                break;
                        }
                        break;
                    case false:
                        Debug.Log("Can't throw");
                        break;
                }
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
                        m_tap = true;
                        m_startPosition = Input.touches[0].position;
                        break;
                    case false:
                        break;
                }
                switch (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                {
                    case true:
                        m_endPosition = Input.mousePosition;
                        switch (jumpController.canThrow)
                        {
                            case true:
                                //jumpController.Throw(Mathf.Abs(m_swipeDelta.x), Mathf.Abs(m_swipeDelta.y));

                                switch (m_swipeDelta.x > swipeDeltaXConstraintMin)
                                {
                                    case true:
                                        switch (m_swipeDelta.y > swipeDeltaYConstraintMin)
                                        {
                                            case true:
                                                Debug.Log(m_swipeDelta);
                                                jumpController.Throw(Mathf.Abs(m_swipeDelta.x), Mathf.Abs(m_swipeDelta.y));
                                                break;
                                            case false:
                                                break;
                                        }
                                        break;
                                    case false:
                                        break;
                                }
                                break;
                            case false:
                                Debug.Log("Can't throw");
                                break;
                        }
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

        // Calculate the distance
        m_swipeDelta = Vector2.zero;

        switch (m_isDragging)
        {
            case true:

                switch (switchCount == 0)
                {
                    case true:
                        switchCount++;
                        trajectoryController.OnTouch();
                        officerAnim.SetTrigger("Crouch");
                        break;
                    case false:
                        break;
                }

                switch (Input.touches.Length > 0)
                {
                    case true:
                        m_swipeDelta = Input.touches[0].position - m_startPosition;
                        switch (m_swipeDelta.x > swipeDeltaXConstraintMax)
                        {
                            case true:
                                m_swipeDelta.x = swipeDeltaXConstraintMax;
                                break;
                            case false:
                                break;
                        }

                        switch (m_swipeDelta.x < swipeDeltaXConstraintMin)
                        {
                            case true:
                                m_swipeDelta.x = swipeDeltaXConstraintMax;
                                break;
                            case false:
                                break;
                        }

                        switch (m_swipeDelta.y > swipeDeltaYConstraintMax)
                        {
                            case true:
                                m_swipeDelta.y = swipeDeltaYConstraintMax;
                                break;
                            case false:
                                break;
                        }

                        switch (m_swipeDelta.y < swipeDeltaYConstraintMin)
                        {
                            case true:
                                m_swipeDelta.y = swipeDeltaYConstraintMin;
                                break;
                            case false:
                                break;
                        }
                        break;
                    case false:
                        break;
                }

                switch (Input.GetMouseButton(0))
                {
                    case true:
                        m_swipeDelta = (Vector2)Input.mousePosition - m_startPosition;

                        switch (m_swipeDelta.x > swipeDeltaXConstraintMax)
                        {
                            case true:
                                m_swipeDelta.x = swipeDeltaXConstraintMax;
                                break;
                            case false:
                                break;
                        }

                        switch (m_swipeDelta.x < swipeDeltaXConstraintMin)
                        {
                            case true:
                                m_swipeDelta.x = swipeDeltaXConstraintMax;
                                break;
                            case false:
                                break;
                        }

                        switch (m_swipeDelta.y > swipeDeltaYConstraintMax)
                        {
                            case true:
                                m_swipeDelta.y = swipeDeltaYConstraintMax;
                                break;
                            case false:
                                break;
                        }

                        switch (m_swipeDelta.y < swipeDeltaYConstraintMin)
                        {
                            case true:
                                m_swipeDelta.y = swipeDeltaYConstraintMin;
                                break;
                            case false:
                                break;
                        }

                        break;
                    case false:
                        break;
                }
                break;
            case false:
                switch (switchCount == 1)
                {
                    case true:
                        switchCount--;
                        trajectoryController.OnTouchRemove();
                        officerAnim.SetTrigger("Idle");

                        break;
                    case false:
                        break;
                }
                break;
        }
    }

    private void Reset()
    {
        m_isDragging = false;
        m_swipeDelta = Vector2.zero;
    }
}
