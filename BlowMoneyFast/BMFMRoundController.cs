using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMFMRoundController : MonoBehaviour
{
    public float selfDestructTime = 5f;

    
    void OnCollisionEnter(Collision other)
    {

        switch(other.collider.tag == "Supporter")
        {
            case true:
                Debug.Log("Money Hit Target.");
                //other.gameObject.GetComponent<Day18TargetController>().IsHit();
                Destroy(gameObject); // Deletes the round            
                break;
            case false:
                StartCoroutine(SelfDestruct());
                break;
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(selfDestructTime);
        Destroy(gameObject);
    }
}
