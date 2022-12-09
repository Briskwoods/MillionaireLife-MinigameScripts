using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPChairController : MonoBehaviour
{
    public Vector3 originalPosition;
    public Vector3 originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = this.transform.localPosition;
        originalRotation = this.transform.localEulerAngles;

    }
    [ContextMenu("Test")]
    public void Restart()
    {
        this.gameObject.transform.localPosition = originalPosition;
        this.transform.localEulerAngles = originalRotation;
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}
