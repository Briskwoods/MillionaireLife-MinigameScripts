using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BMFMTargetController : MonoBehaviour
{
    
    public BMFMinigameController minigameController_;

    public bool isHit = false;

    public int counter = 0;

    public Slider slider;

    public int maxhits;

    public bool done = false;

    public Animator m_self;

    public string cheer = "Cheer_1"; 

    public  void Start()
    {
        slider.maxValue = maxhits;
        m_self = this.gameObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.collider.tag == "Money")
        {
            case true:
                switch (!done)
                {
                    case true:
                        Vibration.VibratePop();
                        switch (counter == 0)
                        {
                            case true:
                                m_self.Play(cheer);
                                break;
                            case false:
                                break;
                        }


                        switch (counter < maxhits)
                        {
                            case true:
                                counter++;
                                slider.DOValue(counter, 0.5f);

                                break;
                            case false:
                                counter++;
                                slider.DOValue(counter, 0.5f);
                                break;
                        }

                        switch (counter >= maxhits)
                        {
                            case true:
                                done = true;
                                CheckWin();
                                Debug.Log("Check Win");
                                break;
                            case false: break;
                        }
                        break;
                    case false:
                        break;
                }
                break;
            case false:
                break;
        }
    }

    public void CheckWin()
    {
        minigameController_.targets.Remove(this);
        minigameController_.CheckWin();
    }
}
