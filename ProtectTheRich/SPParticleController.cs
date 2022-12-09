using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPParticleController : MonoBehaviour
{
    public ParticleSystem starburst;

    public void PlayPS()
    {
        starburst.Play();
    }
}
