using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMUMinigameController : MonoBehaviour
{
    public bool isMaleMillionaire;

    public List<GameObject> maleMilliPhotos = new List<GameObject>();
    public List<GameObject> femaleMilliPhotos = new List<GameObject>();
   

    // Start is called before the first frame update
    void Start()
    {
        CheckMillionaire();
    }


    public void CheckMillionaire()
    {
        // Get var saved in code controller
        isMaleMillionaire = CodeManager.Instance.PlayerPrefsManager_Script.GetGender();

        // Check if male or female and basically change based on answer
        switch (isMaleMillionaire)
        {
            case true:
                foreach (GameObject maleMilli in maleMilliPhotos)
                {
                    maleMilli.SetActive(true);
                }

                foreach (GameObject femaleMilli in femaleMilliPhotos)
                {
                    femaleMilli.SetActive(false);
                }
                break;
            case false:

                foreach (GameObject maleMilli in maleMilliPhotos)
                {
                    maleMilli.SetActive(false);
                }

                foreach (GameObject femaleMilli in femaleMilliPhotos)
                {
                    femaleMilli.SetActive(true);
                }
                break;
        }
    }
    [ContextMenu("End Level")]
    public void EndLevel(float delay)
    {
        ////End of Level, trigger inter
        //TTPManager.Instance.ShowInterstitialAd("AfterSMUMinigame", () =>
        //{

        //CodeManager.Instance.CashManager_Script.IncreaseCash(200000);

        CodeManager.Instance.LevelManager_Script.EndLevel(delay);
        //});
    }
}
