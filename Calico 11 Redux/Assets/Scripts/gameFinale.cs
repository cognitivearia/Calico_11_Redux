using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameFinale : MonoBehaviour
{
    private float timer = 0f;
    [SerializeField] private float timeToWait = 5f;
    private bool grabbed = false;
    [SerializeField] GameObject player;
    [SerializeField] private Transform teleportTransform;


    // Update is called once per frame
    void Update()
    {
        if (grabbed)
        {
            timer += Time.deltaTime;
            if (timer>=timeToWait)
            {
                player.transform.position = teleportTransform.position;
            }
        }
    }

    public void GrabbedObject()
    {
        grabbed = true;
    }

}
