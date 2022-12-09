using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMRunnerTrigger : MonoBehaviour
{
    public int count = 0;

    public GameObject objectToEnable;
    public Animator selfAnim;

    public RMController RunnerMinigameController_;

    public Vector3 startPosition;


    private void Start()
    {
        selfAnim = this.gameObject.GetComponent<Animator>();
        startPosition = this.transform.localPosition;
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.collider.tag == "Player")
        {
            case true:
                //Disable gamebject after enabling child on player

                objectToEnable.SetActive(true);
                selfAnim.SetTrigger("Disappear");

                CodeManager.Instance.CashManager_Script.IncreaseCash(10000);

                switch (count == 0)
                {
                    case true:
                        RunnerMinigameController_.SupporterSize += 1;
                        count++;
                        break;
                    case false: break;
                }
                break;
            case false: break;
        }
    }

    public void OnRestart()
    {
        this.transform.localPosition = startPosition;
    }

    public void DisableOnAnimationEnd()
    {
        this.gameObject.SetActive(false);
    }
}
