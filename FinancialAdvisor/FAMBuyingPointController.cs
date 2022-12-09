using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAMBuyingPointController : MonoBehaviour
{
    public Transform graphDot;
    //public Transform buyingPointTrans;

    public GameObject buyingPriceline;

    public bool isMoving = false;

    // Update is called once per frame
    void Update()
    {
        switch (isMoving)
        {
            case true:
                buyingPriceline.transform.localPosition = new Vector3(0.2065f, graphDot.localPosition.y, - 0.0615f);
                break;
            case false:
                break;
        }
    }

    public void BPMoving()
    {
        isMoving = true;
    }

    public void BPStopMoving()
    {
        isMoving = false;
    }

    public void OnBuy()
    {
        buyingPriceline.SetActive(true);
        BPStopMoving();
    }

    public void OnSell()
    {
        buyingPriceline.SetActive(false);
        BPMoving();
    }

}


