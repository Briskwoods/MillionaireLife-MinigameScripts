using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPJumpController : MonoBehaviour
{
    //public bool isDart = false;

    [SerializeField] private Transform m_throwPoint;

    [SerializeField] private float Force = 10f;

    [SerializeField] private float m_throwHeight;

    [SerializeField] private Rigidbody originalThrowable;

    [SerializeField] private Rigidbody m_ObjectToThrow;

    public float ThrowForceInZ = 50f;

    public float rotationX = 0f;
    public float rotationY = 0f;
    public float rotationZ = 0f;

    public float rotationSpeed = 10f;

    public bool canThrow = true;

    public SPGunLookAtPresident gunController;

    // Paper or Dart holder object
    public GameObject officer;

    public Transform Parent;

    public SPGameManager gameManager;
    public SPCameraController cameraController;

    public SPPResidentRestartController presidentRestartController;

    public SPGunLookAtPresident gunLookAtPresident;

    public SPChairController podium;

    [ContextMenu("Jump")]
    public void Throw(float inputForceX, float inputForceY)
    {
        switch (canThrow)
        {
            case true:

                //play jump animm

                m_ObjectToThrow = Instantiate(originalThrowable, m_throwPoint.transform.position, m_throwPoint.transform.rotation, Parent); // Instantiate Stick to throw at hand position        

                m_ObjectToThrow.AddForce((m_ObjectToThrow.transform.forward + new Vector3(inputForceX/20, inputForceY/20, ThrowForceInZ)) * Force, ForceMode.Impulse);// Add force in the Z direction (forward)        

                m_ObjectToThrow.AddRelativeTorque(new Vector3(rotationX, rotationY, rotationZ) * rotationSpeed, ForceMode.Acceleration); //Add local rotation to the dynamite

                StartCoroutine(DelayAfterThrow(2.5f));

                break;
            case false:
                break;
        }

    }

    IEnumerator DelayAfterThrow(float seconds)
    {
        //gameManager.tryCount++;
        gameManager.isDiving = true;
        cameraController.OnJump();
        gameManager.OnJump();
        gunController.Shoot();
        canThrow = false;
        m_ObjectToThrow = originalThrowable; // Control Variable
        officer.SetActive(false);
        yield return new WaitForSeconds(seconds); // Slight Delay before throwing again        

        switch (gameManager.presidentShot)
        {
            case true:
                yield return new WaitForSeconds(1f);        
                presidentRestartController.Restart();   
                podium.Restart();
                break;
            case false:
                break;
        }

        gunLookAtPresident.shotLine.SetActive(true);

        canThrow = true;
        officer.SetActive(true);
        gameManager.OnJumpEnd();
        cameraController.ReturnToOrgin();
        gameManager.CheckIfDone();
        podium.Restart();
        gameManager.presidentShot = false;

    }


    public void OnRestart()
    {
        canThrow = true;
        officer.SetActive(true);
    }
}
