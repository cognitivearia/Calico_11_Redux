using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceController : MonoBehaviour
{
    public string estadoActual = "";
    [SerializeField] private Material CaraBase;
    [SerializeField] private Material CaraBase2;
    [SerializeField] private SkinnedMeshRenderer Carita;
    void Update()
    {
        switch (estadoActual)
        {
            case "CaraBase1":
                Carita.material = CaraBase;
                break;
            case "CaraBase2":
                Carita.material = CaraBase2;
                break;
            default:
                break;
        }
    }
}
