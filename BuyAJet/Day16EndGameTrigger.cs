using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day16EndGameTrigger : MonoBehaviour
{
    public Transform MoneySpawnPoint;

    public List<ParticleSystem> confettiBlasts = new List<ParticleSystem>();

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag == "Plane")
        {
            case true:
                foreach(ParticleSystem confettiBlast in confettiBlasts)
                {
                    confettiBlast.Play();
                }
                other.gameObject.GetComponent<Rigidbody>().useGravity = true;

                // Haptic Feedback Added on Success - Jeff
                //CodeManager.Instance.HapticsController_.Success();
                Vibration.VibratePop();

                //Invoke("EndGame", 2f);
                EndGame(2f);
                break;
            case false: break;
        }
    }

    public void EndGame(float delay)
    {
        //TTPManager.Instance.ShowInterstitialAd("AfterBuyAJet", () =>
        //{
        //    //CodeManager.Instance.LevelManager_Script.NextLevel();
        CodeManager.Instance.LevelManager_Script.EndLevel(delay);
        //});
    }
}
