using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfMinigameCrowdController : MonoBehaviour
{
    public Animator[] audience;
    public string Celebration = "Dance";
    public string Idle = "Idle";

    [ContextMenu("Dance")]
    public void Dance()
    {
        foreach(Animator member in audience) {
            switch(member.isActiveAndEnabled)
            {
                case true:
                    member.Play(Celebration);
                    break;
                case false: break;
            }
        }
    }

    [ContextMenu("Idle")]
    public void IdleAnim()
    {
        foreach (Animator member in audience)
        {
            switch (member.isActiveAndEnabled)
            {
                case true:
                    member.Play(Idle); break;
                case false: break;
            }
        }
    }
}
