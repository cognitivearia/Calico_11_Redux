using Autohand;
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
    [SerializeField] private Animator UIanimator;
    [SerializeField] private AudioSource objectAudio;
    private int secretInt = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.U))
        {
            grabbed = true;
        }

        if (grabbed)
        {
            if (!objectAudio.isPlaying && secretInt == 0) 
            {
                objectAudio.Play();
                secretInt = 1;
            }

            timer += Time.deltaTime;
            if (timer>=timeToWait)
            {
                player.transform.position = teleportTransform.position;
                UIanimator.SetTrigger("Start");
                AutoHandPlayer.Instance.ToggleFlying();
            }
        }
    }

    public void GrabbedObject()
    {
        grabbed = true;
    }

}
