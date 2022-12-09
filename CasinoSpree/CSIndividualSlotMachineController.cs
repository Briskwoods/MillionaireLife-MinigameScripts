using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSIndividualSlotMachineController : MonoBehaviour
{
    public bool isActive = false;

    public Animator m_self;

    public string pull = "Pull";

    public CSSlotMachineController slotMachineController;

    public CSSwitchController switchController;

    [SerializeField] private int firstWin = 50000;
    [SerializeField] private int secondWin = 70000;
    [SerializeField] private int thirdWin = 100000;

    public AudioSource loseSound;
    public AudioSource winSound;

    public int random = 0;

    public CSButtonController buttonController;

    void Start()
    {
        m_self = this.GetComponent<Animator>();
    }

    public void OnPulled()
    {
        m_self.SetTrigger(pull);
     
        isActive = false;
    }

    public void OnRandomPulled()
    {

        random = Random.Range(0, 3);

        switch (random)
        {
            case 0:
                m_self.SetTrigger(pull);
                m_self.SetBool("0" , true);

                isActive = false;
                break;
            case 1:
                m_self.SetTrigger(pull);
                m_self.SetBool("1", true);

                isActive = false;
                break;
            case 2:
                m_self.SetTrigger(pull);
                m_self.SetBool("2", true);

                isActive = false;
                break;
            case 3:
                m_self.SetTrigger(pull);
                m_self.SetBool("3", true);

                isActive = false;
                break;
        }

        isActive = false;
    }

    public void OnAnimationEnd()
    {
        // Give player some money based on slot machine number
        // do a check on slot machine number then remove money for respective slot machines
        switch (slotMachineController.counter)
        {
            case 1:
                CodeManager.Instance.CashManager_Script.IncreaseCash(firstWin);
                winSound.Play(1);

                break;
            case 2:
                CodeManager.Instance.CashManager_Script.IncreaseCash(secondWin);
                winSound.Play(1);

                break;
            case 3:
                CodeManager.Instance.CashManager_Script.IncreaseCash(thirdWin);
                winSound.Play(1);

                break;
        }

        Invoke("SwitchSlotMachines", 1.5f);
    }

    public void OnAnimationEndLowMoneyEarned()
    {
        CodeManager.Instance.CashManager_Script.IncreaseCash(firstWin);
        winSound.Play(1);

        Invoke("SwitchSlotMachines", 1.5f);
    }

    public void OnAnimationEndMidMoneyEarned()
    {
        CodeManager.Instance.CashManager_Script.IncreaseCash(secondWin);
        winSound.Play(1);

        Invoke("SwitchSlotMachines", 1.5f);
    }

    public void OnAnimationEndNoMoneyEarned()
    {
        loseSound.Play();

        Invoke("SwitchSlotMachines", 1.5f);
    }

    public void OnAnimationEndLose()
    {
        switchController.ZoomOutToPlayer();
        // Buttons to retry load and appear
        buttonController.LoadButtonDetails();
        // Play Aww sound
        loseSound.Play();

        Invoke("EnableButtons", 1.5f);
    }

    public void EnableButtons()
    {
        buttonController.EnableButtons();
    }


    public IEnumerator TestCycle()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Playing spin stop animation");
        OnAnimationEnd();
    }

    public void SwitchSlotMachines()
    {
        switchController.SwitchSlotMachines();
    }
}
