using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class KWWoodPileCollisionController : MonoBehaviour
{
    public Transform camOrigin;

    public GameObject cam;

    [SerializeField] private int counter = 0;

    public GameObject secondButtonSet;


    public GameObject speechBubble;

    public AnimatedTyping speechBubbleTyping;

    public TextMeshProUGUI speechBubbleText;

    public bool isMaleMillionaire;


    [TextArea(3, 4)] public string woodIsWetText;

    public AudioSource maleMillionaireWetWoodAudio;
    public AudioSource femaleMillionaireWetWoodAudio;


    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag == "KWMatch")
        {
            case true:
                switch (counter == 0)
                {
                    case true:
                        Invoke("ReturnToOffice", 1.5f);
                        counter++;
                        break;
                    case false: break;
                }
                break;
            case false:
                break;
        }
    }

    public void EnableSpeechBubble()
    {
        speechBubble.SetActive(true);

        switch (isMaleMillionaire)
        {
            case true:
                speechBubbleText.text = woodIsWetText;
                speechBubbleTyping.Animate();

                maleMillionaireWetWoodAudio.Play();
                break;
            case false:
                speechBubbleText.text = woodIsWetText;
                speechBubbleTyping.Animate();

                femaleMillionaireWetWoodAudio.Play();
                break;
        }
    }


    public void ReturnToOffice()
    {
        cam.transform.DOMove(camOrigin.position, 1.5f);
        cam.transform.DORotateQuaternion(camOrigin.rotation, 1.5f).OnComplete(EnableSpeechBubble);
    }

    public void ShowButtons()
    {
        secondButtonSet.SetActive(true);
    }
}
