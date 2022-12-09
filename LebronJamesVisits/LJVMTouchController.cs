using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LJVMTouchController : MonoBehaviour
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

    public Vector2 m_startPosition;
    public Vector2 m_endPosition;
    private Vector2 m_swipeDelta;

    public LJVMThrowController throwController_;
    public LJVMBasketballMinigameController basketballMinigameController_;
    public LJVMThrowUIController throwUIController;

    public LJVMShotController shotController;


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

        // Calculate the distance
        m_swipeDelta = Vector2.zero;

        switch (m_isDragging)
        {
            case true:
                switch (Input.touches.Length > 0)
                {
                    case true:
                        m_swipeDelta = Input.touches[0].position - m_startPosition;
                        break;
                    case false:
                        break;
                }
                switch (Input.GetMouseButton(0))
                {
                    case true:
                        m_swipeDelta = (Vector2)Input.mousePosition - m_startPosition;
                        break;
                    case false:
                        break;
                }
                break;
            case false:
                break;
        }

        // Checking if deadzone was crossed.
        switch (m_swipeDelta.magnitude > 80)
        {
            //Detect direction
            case true:
                m_endPosition = Input.mousePosition;

                direction = m_endPosition - m_startPosition;

                //Debug.Log(direction);

                // Ok so with direction the only value that matters is the x in this case. Height will always be used as a constant in throw controller, whilst the function works, cleaner code would dictate just using what is needed, therefore Throw(X_Input) makes more sense.
                // We use throw(x,y) when we need the Y input for height.
                /*Also now knowing that direction controls the x axis in this we can make this easier by 
                 a. using a switch statement to make the range of direction.x a steady value as long as its in range
                 b. Setting direction.x to just be a static non changing value
                 c. Setting direction.x to be an exposed variable that can be altered in engine by the developer
                 */


                switch(0 < Mathf.Abs(direction.x) && Mathf.Abs(direction.x) < 15f)
                {
                    case true:
                        direction.x = 0;
                        Debug.Log(direction);
                        break;
                    case false:
                        break;
                }

                switch (direction.x >= 15f)
                {
                    case true:
                        direction.x = 5f;
                        Debug.Log(direction);
                        break;
                    case false:
                        break;
                }
                switch (direction.x <= -15f)
                {
                    case true:
                        direction.x = -5f;
                        Debug.Log(direction);
                        break;
                    case false:
                        break;
                }

                shotController.SetThrowDirection(direction.x);

                shotController.TriggerShotJump();

               //switch (throwController_.canThrow)
               // {
               //     case true:
               //         throwController_.Throw(direction.x);
               //         //DustbinMinigameController_.throwCounter += 1;
               //         throwUIController.ThrowCounter();
               //         basketballMinigameController_.CheckThrowCount();
               //         break;
               //     case false:
               //         Debug.Log("Can't throw");
               //         break;
               // }


                Reset();
                break;
            case false:
                break;
        }

    }

    private void Reset()
    {
        //m_startTouch = m_swipeDelta = Vector2.zero;
        m_isDragging = false;
    }
}
