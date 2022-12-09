using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class SMUPhoneController : MonoBehaviour
{
    public int post1Likes = 0;
    public int post2Likes = 0;
    public int post3Likes = 0;
    public int post4Likes = 0;

    public int currentLikes = 0;

    public TextMeshProUGUI likeCounter1;
    public TextMeshProUGUI likeCounter2;
    public TextMeshProUGUI likeCounter3;
    public TextMeshProUGUI likeCounter4;


    public SMUButtonController buttonController;
    public SMUQueueController queueController;
    public SMUOutroController outroController;

    public void IncreaseLikes1()
    {
        likeCounter1.color = Color.green;
        int random_no = post1Likes + Random.Range(100, 200);
        StartCoroutine(Increase_FollowersCounter(random_no));
    }

    public void IncreaseLikes2()
    {
        likeCounter2.color = Color.green;
        int random_no = post2Likes + Random.Range(100, 200);
        StartCoroutine(Increase_FollowersCounter2(random_no));
    }

    public void IncreaseLikes3()
    {
        likeCounter3.color = Color.green;
        int random_no = post3Likes + Random.Range(100, 200);
        StartCoroutine(Increase_FollowersCounter3(random_no));
    }

    public void IncreaseLikes4()
    {
        likeCounter4.color = Color.green;
        int random_no = post4Likes + Random.Range(100, 200);
        StartCoroutine(Increase_FollowersCounter4(random_no));
    }


    IEnumerator Increase_FollowersCounter(int target)
    {
        while (currentLikes != target)
        {
            if (currentLikes > target) { currentLikes--; } else { currentLikes++; }

            likeCounter1.SetText(currentLikes.ToString()+ "K and "+ "BYawnSay" );

            yield return new WaitForSeconds(0.0000001f);
        }
        post1Likes = currentLikes;
        Debug.Log("Done");
        yield return new WaitForSeconds(buttonController.millionaireAudio1Delay);
        currentLikes = 0;
        queueController.SwitchPost();
        yield return new WaitForSeconds(.75f);
        buttonController.EnableNextButton();
    }

    IEnumerator Increase_FollowersCounter2(int target)
    {
        while (currentLikes != target)
        {
            if (currentLikes > target) { currentLikes--; } else { currentLikes++; }

            likeCounter2.SetText(currentLikes.ToString() + "K and " + "KimKards");

            yield return new WaitForSeconds(0.0000001f);
        }
        post2Likes = currentLikes;
        Debug.Log("Done");
        yield return new WaitForSeconds(buttonController.millionaireAudio2Delay);
        currentLikes = 0;
        queueController.SwitchPost();
        yield return new WaitForSeconds(.75f);
        buttonController.EnableNextButton();
    }

    IEnumerator Increase_FollowersCounter3(int target)
    {
        while (currentLikes != target)
        {
            if (currentLikes > target) { currentLikes--; } else { currentLikes++; }

            likeCounter3.SetText(currentLikes.ToString() + "K and " + "JBeebz");

            yield return new WaitForSeconds(0.0000001f);
        }
        post3Likes = currentLikes;
        Debug.Log("Done");
        yield return new WaitForSeconds(buttonController.millionaireAudio3Delay);
        currentLikes = 0;
        queueController.SwitchPost();
        yield return new WaitForSeconds(.75f);
        buttonController.EnableNextButton();
    }

    IEnumerator Increase_FollowersCounter4(int target)
    {
        while (currentLikes != target)
        {
            if (currentLikes > target) { currentLikes--; } else { currentLikes++; }

            likeCounter4.SetText(currentLikes.ToString() + "K and " + "BarbiTing");

            yield return new WaitForSeconds(0.0000001f);
        }
        post4Likes = currentLikes;
        Debug.Log("Done");
        yield return new WaitForSeconds(buttonController.millionaireAudio4Delay);
        currentLikes = 0;
        outroController.CameraZoomOut();
    }
}
