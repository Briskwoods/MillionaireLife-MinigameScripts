using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class FAMGraphController : MonoBehaviour
{ 
    public Rigidbody graphDot;

    public Vector3[] pathWaypoints;

    public float graphTime = 10f;

    public int startAmount = 100;
    public int originalStartAmount;

    //public int absCashValue = 0;              // This is the absolute value of how much the money is increased and decreased by

    public int increaseBy = 1;

    public bool isPaused = true;

    public float timeBetweenIncrement = 1f;

    public bool isIncreasing = true;

    public TextMeshProUGUI currentAmountTxt;

    public Slider goalSlider;

    public int goal;

    public int sliderCurrentValue = 0;

    public TextMeshProUGUI sliderGoalText;

    public FAMGraphController graphController;

    public int currentProfit = 0;
    public int initialProfit = 0;

    public int totalProfit = 0;

    public TextMeshProUGUI profitText;
    public Animator profitTextAnim;


    public int initialBuyingPrice;
    public int buyingPrice = 12;

    public int boughtAt = 0;
    public int soldAt = 0;

    public int currentAmount = 0;

    //public GameObject buyingPoint;
    //public Transform buyingPointYUp;
    //public Transform buyingPointYDown;
    //public float buyingPointMoveTime;
    //public bool buyPointMoving = false;

    public FAMinigameController minigameController;

    public bool isComplete = false;


    // Start is called before the first frame update
    void Start()
    {
        currentAmount = startAmount;
        goalSlider.maxValue = goal;
        currentAmountTxt.text = "" + startAmount + "$";
        sliderGoalText.text = "+$" + currentProfit + "/" + "" + goal / 1000 + "K$";
        profitText.text = "";

        // Setting for Restart
        originalStartAmount = startAmount;
        initialProfit = currentProfit;
        initialBuyingPrice = buyingPrice;
    }

    public void StartGraphMotion()
    {
        isPaused = false;
        StartCoroutine(ChangeAbsoluteCashValue());
        //ControlBuyingPointMovement();
        graphDot.DOPath(pathWaypoints, graphTime, pathType: PathType.Linear, pathMode: PathMode.Sidescroller2D).OnComplete(OnCompletion);
        isComplete = false;
    }

    [ContextMenu("Pause")]
    public void PauseGraphMotion()
    {
        isPaused = true;
        graphDot.DOPause();
    }

    public void ContinueGraphMotion()
    {
        isPaused = false;
        StartCoroutine(ChangeAbsoluteCashValue());
        graphDot.DOPlay();
    }

    public IEnumerator ChangeAbsoluteCashValue()
    {
        do
        {
            switch (isIncreasing)
            {
                case true:
                    //absCashValue += increaseBy;
                    buyingPrice += increaseBy;
                    yield return new WaitForSeconds(timeBetweenIncrement); // Slight Delay before throwing again
                    break;
                case false:
                    //absCashValue -= increaseBy;
                    buyingPrice -= increaseBy;
                    yield return new WaitForSeconds(timeBetweenIncrement); // Slight Delay before throwing again 
                    break;
            }
        } while (!isPaused);
    }


    public void OnCompletion()
    {
        isPaused = true;
        isComplete = true;
        minigameController.CheckWinLose(totalProfit, goal);  
    }

    public void ShowMargin()
    {
        totalProfit += currentProfit;
        StartCoroutine(ShowMargin(currentProfit));
    }

    public void UpdateCurrentAmount()
    {
        currentAmountTxt.text = "$" + currentAmount;
    }

    public IEnumerator ShowMargin(int amountGainedOrLost)
    {
        switch (currentProfit> 0)
        {
            case true:
                // show Profit text
                profitText.text = "$+" + amountGainedOrLost;
                //Set text colour to green
                profitText.color = Color.green;
                // Set text animator to pop the text
                profitTextAnim.SetTrigger("Pop");
                // Brief pause before profit disappearing
                yield return new WaitForSeconds(2f);
                // Set text animator to idle
                profitTextAnim.SetTrigger("Idle");
                // Clear the text field
                profitText.text = "";
                break;
            case false:
                // show Loss text
                profitText.text = "$" + amountGainedOrLost;
                //Set text colour to red
                profitText.color = Color.red;
                // Set text animator to pop the text
                profitTextAnim.SetTrigger("Pop");
                // Brief pause before profit disappearing
                yield return new WaitForSeconds(2f);
                // Set text animator to idle
                profitTextAnim.SetTrigger("Idle");
                // Clear the text field
                profitText.text = "";
                break;
        }
    }

    public void OnBuy()
    {
        boughtAt = buyingPrice;
        Debug.Log("BP: "+ boughtAt);

        currentAmount -= boughtAt;
        currentAmountTxt.text = "" + currentAmount + "$";
    }

    public void OnSell()
    {
        soldAt = buyingPrice;
        Debug.Log("SP: " + soldAt);
        CalculateProfit();
    }

    public void UpdateSlider()
    {
        sliderCurrentValue = totalProfit;
        goalSlider.DOValue(sliderCurrentValue, 1f, snapping:false);
        sliderGoalText.text = "+$" + sliderCurrentValue + "/" + "" + goal / 1000 + "K$";
    }

    public void CalculateProfit()
    {
        currentProfit =soldAt - boughtAt;
        Debug.Log("P: " + currentProfit);

        currentAmount += currentProfit;
        currentAmountTxt.text = "" + currentAmount + "$";
    }

    public void OnRestart()
    {
        startAmount = originalStartAmount;
        currentProfit = initialProfit;
        totalProfit = initialProfit;
        currentAmount = originalStartAmount;
        isIncreasing = true;
        boughtAt = 0;
        soldAt = 0;
        buyingPrice = initialBuyingPrice;

    }
}
