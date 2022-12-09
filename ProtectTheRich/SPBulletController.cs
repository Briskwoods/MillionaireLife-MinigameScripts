using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPBulletController : MonoBehaviour
{
    public SPGameManager gameManager;

    public float explosionForce = 50f;
    public float explosionHeight = 50f;
    public float explosionRadius = 50f;

    public ParticleSystem starburst;

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.collider.tag == "SPOfficer")
        {
            case true:
                gameManager.presidentSaved = true;

                //add particle effects
                starburst.Play();
                //add force to rigidbody of officer
                collision.collider.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionHeight, explosionRadius, ForceMode.Impulse);

                collision.collider.GetComponent<SPParticleController>().PlayPS();

                Destroy(this.gameObject);

                break;
            case false:
                break;
        }

        switch (collision.collider.tag == "SPMillionaire")
        {
            case true:
                gameManager.presidentSaved = false;
                gameManager.presidentShot = true;

                //add particle effects
                starburst.Play();

                // Disable president animator
                collision.collider.GetComponentInParent<Animator>().enabled = false;

                //add force to rigidbody of officer
                collision.collider.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionHeight, explosionRadius, ForceMode.Impulse);

                collision.collider.GetComponentInParent<SPParticleController>().PlayPS();

                Destroy(this.gameObject);

                break;
            case false:
                break;
        }
    }
}
