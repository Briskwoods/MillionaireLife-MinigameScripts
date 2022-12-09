using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfMinigameGolfballController : MonoBehaviour
{
    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.localPosition;
    }

    [ContextMenu("Test")]
    public void Restart()
    {
        this.gameObject.transform.localPosition = startPosition;
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
    }
}
