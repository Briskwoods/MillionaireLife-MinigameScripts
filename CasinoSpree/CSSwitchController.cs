using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CSSwitchController : MonoBehaviour
{
    public GameObject cam;

    public GameObject instructions;

    public List<Transform> cameraPoints = new List<Transform>();
    public List<CSIndividualSlotMachineController> slotMachines = new List<CSIndividualSlotMachineController>();

    public Transform lookAtPlayerPoint;

    [SerializeField] private int counter = 0;

    public CSSlotMachineController slotMachineController;

    public CSOutroController outroController;

    public CharacterBehaviourManager _cbm;
    public string Dissapointed = "Sad";
    public string idle = "Idle";


    [ContextMenu("Switch")]
    public void SwitchSlotMachines()
    {
        switch (slotMachineController.counter)
        {
            case 0:
                // Nothing
                Debug.Log("First Switch");

                cam.transform.DORotateQuaternion(cameraPoints[counter].rotation, 1.5f);
                cam.transform.DOMove(cameraPoints[counter].position, 1.5f).OnComplete(OnSwitchComplete);
                counter++;
                break;
            case 1:
                // Switch to second
                Debug.Log("Second Switch");
                cam.transform.DORotateQuaternion(cameraPoints[counter].rotation, 1.5f);
                cam.transform.DOMove(cameraPoints[counter].position, 1.5f).OnComplete(OnSwitchComplete);
                counter++;
                break;
            case 2:
                // Switch to third
                Debug.Log("Third Switch");
                _cbm.SetAnimation(idle);

                cam.transform.DORotateQuaternion(cameraPoints[counter].rotation, 1.5f);
                cam.transform.DOMove(cameraPoints[counter].position, 1.5f).OnComplete(OnSwitchComplete);
                counter++;
                break;
            case 3:
                // End
                Debug.Log("End Level");
                outroController.OnOutroCalled();
                break;
        }
    }

    public void OnSwitchComplete()
    {
        Debug.Log("Switch Complete");
        instructions.SetActive(true);

        slotMachineController.canPullHandle = true;
        slotMachines[slotMachineController.counter].isActive = true;
    }


    public void ZoomOutToPlayer()
    {
        // Zoom out to see player
        Debug.Log("Zoom to see player");
        _cbm.SetAnimation(Dissapointed);
        cam.transform.DORotateQuaternion(lookAtPlayerPoint.rotation, 1.5f);
        cam.transform.DOMove(lookAtPlayerPoint.position, 1.5f);
    }

}
