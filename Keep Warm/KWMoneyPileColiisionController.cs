using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KWMoneyPileColiisionController : MonoBehaviour
{
    public KWMinigameController minigameController;

    public GameObject effect;

    public List<Animator> crowd = new List<Animator>();

    public string Celebrate = "Win";

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag == "KWMatch")
        {
            case true:
                collision.collider.gameObject.GetComponentInParent<Rigidbody>().isKinematic = true;
                //collision.collider.gameObject.transform.parent.localScale *=2;
                effect.SetActive(true);
                minigameController.currentScore += 1;
                minigameController.CheckWin();

                foreach (Animator individual in crowd)
                {
                    individual.Play(Celebrate);
                }

                break;
            case false:
                break;
        }
    }
}
