using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAMInputReciever : MonoBehaviour
{
    [HideInInspector] public GameObject selectedObject;

    [HideInInspector] public bool m_isDragging;

    public List<FAMIndividualButtonController> buttons = new List<FAMIndividualButtonController>();

    public FAMButtonController buttonController;

    public GameObject buyButton;
    public GameObject sellButton;

    private void Update()
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


        switch (m_isDragging)
        {
            case true:
                switch (selectedObject == null)
                {
                    case true:
                        RaycastHit hit = CastRay();

                        switch (hit.collider != null)
                        {
                            case true:
                                switch (hit.collider.CompareTag("FAMButton"))
                                {
                                    case true:
                                        selectedObject = hit.collider.gameObject;
                                        switch (selectedObject.GetComponent<FAMIndividualButtonController>().canBeClicked)
                                        {
                                            case true:
                                                switch (selectedObject == buyButton)
                                                {
                                                    case true:
                                                        buttonController.OnBuy();
                                                        break;
                                                    case false:
                                                        break;
                                                }
                                                switch (selectedObject == sellButton)
                                                {
                                                    case true:
                                                        buttonController.OnSell();
                                                        break;
                                                    case false:
                                                        break;
                                                }

                                                break;
                                            case false:
                                                break;
                                        }
                                        break;
                                    case false: break;
                                }

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

                switch (selectedObject != null)
                {
                    case true:
                        selectedObject = null;
                        Cursor.visible = true;
                        break;
                    case false: break;
                }
                break;
        }

        switch (selectedObject != null)
        {
            case true:
                m_isDragging = false;
                break;
            case false: break;
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
}
