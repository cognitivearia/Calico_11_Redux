using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OvniMiniGameBehaviour : MonoBehaviour
{
    [SerializeField] int points = 0;
    [SerializeField] TMP_Text text;
    
    void Start()
    {
        text.text = points.ToString();
    }

    public void Score()
    {
        points++;
        text.text = points.ToString();
    }
}
