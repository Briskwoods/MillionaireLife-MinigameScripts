using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPPResidentRestartController : MonoBehaviour
{
    public Animator malePresident;
    public Animator femalePresident;

    [ContextMenu("Restart")]
    public void Restart()
    {
        malePresident.enabled = true;
        femalePresident.enabled = true;
    }
}
