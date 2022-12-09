using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAMButtonController : MonoBehaviour
{

    public FAMGraphController graphController;

    public FAMinigameController minigameController;

    public FAMBuyingPointController bPController;

    public int buyCounter = 0;

    public bool isBuying = false;

    public Animator buyButton;
    public Animator sellButton;

    public SkinnedMeshRenderer buyButtonRenderer;
    public SkinnedMeshRenderer sellButtonRenderer;


    public Material buyButtonOriginalMaterial;
    public Material sellButtonOriginalMaterial;
    public Material greyOut;

    [ContextMenu("Buy")]
    public void OnBuy()
    {
        switch (!isBuying)
        {
            case true:
                buyButtonRenderer.materials[1].color = greyOut.color;
                sellButtonRenderer.materials[1].color = sellButtonOriginalMaterial.color;
                isBuying = true;
                buyButton.SetTrigger("Clicked");
                switch (buyCounter == 0)
                {
                    case true:
                        // Reduce starting amount by start buying price
                        graphController.OnBuy();
                        // On first buy we start the graph motion
                        graphController.StartGraphMotion();
                        //  Red line appear
                        bPController.OnBuy();
                        // Buy Counter Increases
                        buyCounter++;

                        break;
                    case false:
                        // Check win loss if after buying the start amount goes below 0
                        //switch (graphController.currentAmount < 0)
                        //{
                        //    case true:
                        //        //  Red line appear
                        //        bPController.OnBuy();
                        //        // Reduce starting amount by start buying price
                        //        graphController.OnBuy();

                        //        minigameController.CheckWinLose(graphController.totalProfit, graphController.goal);
                        //        break;
                        //    case false:
                        //        //  Red line appear
                        //        bPController.OnBuy();
                        //        // Reduce starting amount by start buying price
                        //        graphController.OnBuy();
                        //        break;
                        //}

                        //Red line appear
                        bPController.OnBuy();
                        // Reduce starting amount by start buying price
                        graphController.OnBuy();

                        break;
                }

                break;
            case false:
                break;
        }
    }

    [ContextMenu("Sell")]
    public void OnSell()
    {
        switch (isBuying)
        {
            case true:

                buyButtonRenderer.materials[1].color = buyButtonOriginalMaterial.color;
                sellButtonRenderer.materials[1].color = greyOut.color;
                isBuying = false;
                sellButton.SetTrigger("Clicked");

                //  Red line disappear
                bPController.OnSell();

                graphController.OnSell();
                // We then take the current profit and show it
                graphController.ShowMargin();
                // Add or subtract money from startAmount
                graphController.UpdateCurrentAmount(); 
                // Update slider
                graphController.UpdateSlider();

                // Check win/loss
                minigameController.CheckWinLose(graphController.totalProfit, graphController.goal);
                break;
            case false:
                break;
        }
    }
}
