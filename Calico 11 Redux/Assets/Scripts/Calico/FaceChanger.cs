using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceChanger : MonoBehaviour
{
    [SerializeField] CalicoAnimatorController CalicoAnimator;
    [SerializeField] FaceController FaceController;
    private int index = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            string IndexToString = index.ToString();
            FaceController.estadoActual = "CaraBase"+ IndexToString;
            index++;
            if (index > 2)
            {
                index = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            CalicoAnimator.estadoActual = "SwimRoll";
        }
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            CalicoAnimator.estadoActual = "T-Pose";
        }
    }
}
