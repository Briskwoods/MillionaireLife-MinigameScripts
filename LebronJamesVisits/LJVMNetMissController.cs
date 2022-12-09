using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LJVMNetMissController : MonoBehaviour
{


    //public Animator LJAnim;

    public List<Animator> crowdAnims = new List<Animator>();

    public LJVMBasketballMinigameController basketballMinigameController_;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag == "Paper")
        {
            case true:
                foreach (Animator individual in crowdAnims)
                {
                    individual.SetTrigger("Dissapoint");
                }
                break;
            case false:
                break;
        }
    }
}
