using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LJVMThrowController : MonoBehaviour
{
    public bool isDart = false;

    [SerializeField] private Transform m_throwPoint;

    [SerializeField] private float Force = 10f;

    public float ThrowForceInZ = 50f;

    [SerializeField] private float m_throwHeight;

    [SerializeField] private Rigidbody originalThrowable;

    [SerializeField] private Rigidbody m_ObjectToThrow;

    public bool canThrow = true;

    // Paper or Dart holder object
    public GameObject basketball;

    public bool isMaleMilli = false;

    public GameObject maleMillionaireBasketball;
    public GameObject femaleMillionaireBasketball;

    public Transform Parent;

    private void Start()
    {
        isMaleMilli = CodeManager.Instance.PlayerPrefsManager_Script.GetGender();
        //isMaleMilli = false;
    }

    public void Throw(float inputForceX, float inputForceY)
    {
        switch (canThrow)
        {
            case true:
                switch (isDart)
                {
                    case true:
                        m_ObjectToThrow = Instantiate(originalThrowable, m_throwPoint.transform.position, m_ObjectToThrow.transform.rotation, Parent); // Instantiate Stick to throw at hand position        
                        break;
                    case false:
                        m_ObjectToThrow = Instantiate(originalThrowable, m_throwPoint.transform.position, m_throwPoint.transform.rotation, Parent); // Instantiate Stick to throw at hand position        
                        break;
                }

                m_ObjectToThrow.AddForce((m_ObjectToThrow.transform.forward + new Vector3(inputForceX, m_throwHeight, ThrowForceInZ)) * Force, ForceMode.Impulse);// Add force in the Z direction (forward)        
                switch (isDart)
                {
                    case true:
                        break;
                    case false:
                        m_ObjectToThrow.AddRelativeTorque(new Vector3(1, 1, 1) * 10f, ForceMode.Impulse); //Add local rotation to the dynamite
                        break;
                }
                StartCoroutine(DelayAfterThrow(2.5f));
                break;
            case false:
                break;
        }

    }

    public void Throw(float inputForceX)
    {
        switch (canThrow)
        {
            case true:
                switch (isDart)
                {
                    case true:
                        m_ObjectToThrow = Instantiate(originalThrowable, m_throwPoint.transform.position, m_ObjectToThrow.transform.rotation, Parent); // Instantiate Stick to throw at hand position        
                        break;
                    case false:
                        m_ObjectToThrow = Instantiate(originalThrowable, m_throwPoint.transform.position, m_throwPoint.transform.rotation, Parent); // Instantiate Stick to throw at hand position        
                        break;
                }

                m_ObjectToThrow.AddForce((m_ObjectToThrow.transform.forward + new Vector3(inputForceX, m_throwHeight, ThrowForceInZ)) * Force, ForceMode.Impulse);// Add force in the Z direction (forward)        
                switch (isDart)
                {
                    case true:
                        break;
                    case false:
                        m_ObjectToThrow.AddRelativeTorque(new Vector3(1, 1, 1) * 10f, ForceMode.Impulse); //Add local rotation to the dynamite
                        break;
                }
                StartCoroutine(DelayAfterThrow(2.5f));
                break;
            case false:
                break;
        }

    }

    IEnumerator DelayAfterThrow(float seconds)
    {
        canThrow = false;
        m_ObjectToThrow = originalThrowable; // Control Variable
        //basketball.SetActive(false);

        switch (isMaleMilli)
        {
            case true:
                maleMillionaireBasketball.SetActive(false);
                break;
            case false:
                femaleMillionaireBasketball.SetActive(false);
                break;
        }
        yield return new WaitForSeconds(seconds); // Slight Delay before throwing again        
        canThrow = true;

        //basketball.SetActive(true);
        switch (isMaleMilli)
        {
            case true:
                maleMillionaireBasketball.SetActive(true);
                break;
            case false:
                femaleMillionaireBasketball.SetActive(true);
                break;
        }
    }
}
