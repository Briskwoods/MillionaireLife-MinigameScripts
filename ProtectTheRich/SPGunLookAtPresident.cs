using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SPGunLookAtPresident : MonoBehaviour
{
    public Transform president;

    public Rigidbody bullet;
    public Rigidbody bulletOrigin;

    public GameObject bulletObj;
    public GameObject bulletObjOrigin;

    public Transform shootPoint;
    public Transform endPoint;

    public float moveTime = 5f;

    public Transform bulletParent;

    public float shotSpeed = 50f;

    public GameObject shotLine;
    // Start is called before the first frame update
    void Start()
    {
        LookAtPresident();
    }

    [ContextMenu("Aim")]
    public void LookAtPresident()
    {
        this.transform.LookAt(president);
    }

    [ContextMenu("Shoot")]
    public void Shoot()
    {
        //bullet = Instantiate(bulletOrigin, shootPoint.transform.position, shootPoint.transform.rotation, bulletParent); // Instantiate Stick to throw at hand position        

        //bullet.AddForce(bullet.transform.forward  * shotSpeed, ForceMode.Impulse);// Add force in the Z direction (forward)        

        bulletObj = Instantiate(bulletObjOrigin, shootPoint.transform.position, shootPoint.transform.rotation, bulletParent);

        bulletObj.transform.DOMove(endPoint.position, moveTime);

        shotLine.SetActive(false);
    }
}
