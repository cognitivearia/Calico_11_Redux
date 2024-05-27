using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;

public class ShowCredits : MonoBehaviour
{
    [SerializeField] private GameObject @object;
    
    public void Start()
    {
        @object.SetActive(false);
    }

    public void Show()
    {
        @object.SetActive(true);
    }
}
