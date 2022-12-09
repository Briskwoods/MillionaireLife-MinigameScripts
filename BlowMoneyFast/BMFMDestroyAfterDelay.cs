using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMFMDestroyAfterDelay : MonoBehaviour
{
    public float selfDestructTime = 5f;


    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(selfDestructTime);
        Destroy(gameObject);
    }
}
