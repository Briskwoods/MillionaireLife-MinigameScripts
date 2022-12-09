using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SPTrajectoryController : MonoBehaviour
{
    public LineRenderer trajectoryLine;
    public SPTouchController touchController;

    public Material trajectoryLineMaterial;

    public float minXRange = 420;
    public float minYRange = 410;
    public float maxRange = 450;

    // Update is called once per frame
    void Update()
    {
        trajectoryLine.SetPosition(1, touchController.m_swipeDelta / 200);


        switch (touchController.m_swipeDelta.x < minXRange)
        {
            case true:
                trajectoryLineMaterial.DOColor(Color.red, 1);

                //switch(touchController.m_swipeDelta.x > minXRange && touchController.m_swipeDelta.x < maxRange)
                //{
                //    case true:
                //        trajectoryLineMaterial.DOColor(Color.yellow, 1);
                //        break;
                //    case false:
                //        break;
                //}


                switch (touchController.m_swipeDelta.y < minYRange)
                {
                    case true:
                        trajectoryLineMaterial.DOColor(Color.red, 1);
                        break;
                    case false:

                        break;
                }
                break;
            case false:

                trajectoryLineMaterial.DOColor(Color.yellow, 1);

                //switch (touchController.m_swipeDelta.x > minXRange && touchController.m_swipeDelta.x < maxRange)
                //{
                //    case true:
                //        trajectoryLineMaterial.DOColor(Color.yellow, 1);
                //        break;
                //    case false:
                //        break;
                //}

                switch (touchController.m_swipeDelta.y < minYRange)
                {
                    case true:
                        trajectoryLineMaterial.DOColor(Color.red, 1);
                        break;
                    case false:
                        trajectoryLineMaterial.DOColor(Color.green, 1);
                        break;
                }
                break;
        }
    }

    public void OnTouch()
    {
        trajectoryLine.enabled = true;
    }

    public void OnTouchRemove()
    {
        trajectoryLine.enabled = false;
    }
}
