using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingDetector : MonoBehaviour
{
    private OvniMiniGameBehaviour miniGameManager;

    private void Start()
    {
        miniGameManager = GetComponentInParent<OvniMiniGameBehaviour>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ovni"))
        {
            miniGameManager.Score();
        }
    }
}
