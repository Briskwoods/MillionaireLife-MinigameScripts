using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LJVMBasketballDestroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag == "Paper")
            {
                case true:
                Destroy(collision.collider.gameObject);
                    break;
                case false:
                    break;
            }
        }
}
