using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMScanablesController : MonoBehaviour
{
    public List<SMScanablesDefiner> definers = new List<SMScanablesDefiner>();
    public SMQueueManager queueManager;
   
    public ButtonDetails ApproveButton;
    public ButtonDetails DisapproveButton;


    public void CheckIfGoodOrBad()
    {
        switch (queueManager.noInQueue)
        {
            case 0:
                switch (definers[queueManager.noInQueue].isGood)
                {
                    case true:
                        ApproveButton.PositiveButton = true;
                        DisapproveButton.PositiveButton = false;
                        break;
                    case false:
                        
                        ApproveButton.PositiveButton = false;
                        DisapproveButton.PositiveButton = true;
                        break;
                }
                break;
            case 1:
                switch (definers[queueManager.noInQueue].isGood)
                {
                    case true:
                        ApproveButton.PositiveButton = true;
                        DisapproveButton.PositiveButton = false;
                        break;
                    case false:
                        ApproveButton.DeductCash = true;
                        ApproveButton.CashValue = 5000;
                        ApproveButton.PositiveButton = false;
                        DisapproveButton.PositiveButton = true;
                        break;
                }
                break;
            case 2:
                switch (definers[queueManager.noInQueue].isGood)
                {
                    case true:
                        ApproveButton.DeductCash = false;
                        ApproveButton.CashValue = 0;
                        ApproveButton.PositiveButton = true;
                        DisapproveButton.PositiveButton = false;
                        break;
                    case false:
                        
                        ApproveButton.PositiveButton = false;
                        DisapproveButton.PositiveButton = true;
                        break;
                }
                break;
            case 3:
                switch (definers[queueManager.noInQueue].isGood)
                {
                    case true:
                        ApproveButton.PositiveButton = true;
                        DisapproveButton.PositiveButton = false;
                        break;
                    case false:
                        ApproveButton.DeductCash = true;
                        ApproveButton.CashValue = 5000;
                        ApproveButton.PositiveButton = false;
                        DisapproveButton.PositiveButton = true;
                        break;
                }
                break;
            case 4:
                switch (definers[queueManager.noInQueue].isGood)
                {
                    case true:
                        ApproveButton.DeductCash = false;
                        ApproveButton.CashValue = 0;
                        ApproveButton.PositiveButton = true;
                        DisapproveButton.PositiveButton = false;
                        break;
                    case false:
                        
                        ApproveButton.PositiveButton = false;
                        DisapproveButton.PositiveButton = true;
                        break;
                }
                break;
            case 5:
                switch (definers[queueManager.noInQueue].isGood)
                {
                    case true:
                        ApproveButton.PositiveButton = true;
                        DisapproveButton.PositiveButton = false;
                        break;
                    case false:
                        ApproveButton.PositiveButton = false;
                        DisapproveButton.PositiveButton = true;
                        break;
                }
                break;
            case 6:
                switch (definers[queueManager.noInQueue].isGood)
                {
                    case true:
                        ApproveButton.PositiveButton = true;
                        DisapproveButton.PositiveButton = false;
                        break;
                    case false:
                        ApproveButton.PositiveButton = false;
                        DisapproveButton.PositiveButton = true;
                        break;
                }
                break;

        }
    }
    
}
