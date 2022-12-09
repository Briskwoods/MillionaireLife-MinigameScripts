using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LJVMNetController : MonoBehaviour
{

    //public Animator LJAnim;

    public List<Animator> crowdAnims = new List<Animator>();

    public LJVMBasketballMinigameController basketballMinigameController_;

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag == "Paper")
        {
            case true:
                //other.gameObject.GetComponent<DestroyAfterDelay>().enabled = false;
                basketballMinigameController_.currentScore += 1;
                basketballMinigameController_.CheckWin();

                //LJAnim.SetTrigger("Celebrate");
                foreach (Animator individual in crowdAnims)
                {
                    individual.SetTrigger("Celebrate");
                }

                // Haptic Feedback Added on LightImpact - Jeff
                //ControlManager.Instance.HapticsController_.LightImpact();
                Vibration.VibratePeek();

                break;
            case false:
                break;
        }
    }
}
