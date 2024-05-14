using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalicoAnimatorController : MonoBehaviour
{
    [SerializeField] Animator CalicoAnimator;
    public string estadoActual = "";

    // Update is called once per frame
    void Update()
    {
        switch (estadoActual)
        {
            case "T-Pose":
                CalicoAnimator.SetInteger("ChangeState", 0);
                break;
            case "SwimRoll":
                CalicoAnimator.SetInteger("ChangeState", 1);

                break;
            default:
                break;
        }
    }
}
