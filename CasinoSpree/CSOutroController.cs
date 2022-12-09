using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CSOutroController : MonoBehaviour
{
    public GameObject millionaire;

    public GameObject cam;

    public Transform cameraPointFinal;

    public Transform millionairePointFinal;

    public CharacterBehaviourManager millionaireAnim;

    public string Celebrate = "Cheer_2";
    public string disappointed = "Sad";

    public CSMinigameController minigameController;

    public CSInputReciever inputReciever;

    public List<ParticleSystem> confettiClutter = new List<ParticleSystem>();


    public void OnOutroCalled()
    {
        // Disable scripts
        // Disable Input from player
        inputReciever.enabled = false;

        // Camera zooms out
        cam.transform.DOMove(cameraPointFinal.position, 2f);
        cam.transform.DORotateQuaternion(cameraPointFinal.rotation, 2f).OnComplete(RotateMillionaire);
    }

    public void RotateMillionaire()
    {
        // Millionaire faces camera and starts dancing
        millionaire.transform.DORotateQuaternion(millionairePointFinal.rotation, 0.5f).OnComplete(MillionaireDancing);
    }

    public void MillionaireDancing()
    {
        millionaireAnim.SetAnimation(Celebrate);

        foreach(ParticleSystem confetti in confettiClutter)
        {
            confetti.Play();
        }
        // Invoke Level end in 1.5s
        //Invoke("EndLevel", 1.5f);
        EndLevel(1.5f);
    }

    public void OnLoseOutroCalled()
    {
        // Disable scripts
        // Disable Input from player
        inputReciever.enabled = false;

        // Camera zooms out
        cam.transform.DOMove(cameraPointFinal.position, 2f);
        cam.transform.DORotateQuaternion(cameraPointFinal.rotation, 2f).OnComplete(RotateMillionaireLose);
    }

    public void RotateMillionaireLose()
    {
        // Millionaire faces camera and starts dancing
        millionaire.transform.DORotateQuaternion(millionairePointFinal.rotation, 0.5f).OnComplete(MillionaireDissapointed);
    }

    public void MillionaireDissapointed()
    {
        millionaireAnim.SetAnimation(disappointed);

        EndLevel(1.5f);
    }



    public void EndLevel(float delay)
    {
        minigameController.EndLevel(delay);
    }
}
