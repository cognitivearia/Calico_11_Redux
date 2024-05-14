using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;

public class ElevatorBehaviour : MonoBehaviour
{
    private bool moving = false;
    private int actualFloor = 1;
    [SerializeField] private Transform initialTransform;
    [SerializeField] private Transform finalTransform;
    private Transform thisTransform;
    [SerializeField] float elevatorSpeed = 4f;
    [SerializeField] private bool gem = false;
    [SerializeField] PlacePoint placePoint;
    [SerializeField] MeshRenderer button;
    [SerializeField] Material material;

    void Start()
    {
        thisTransform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        placePoint.OnPlaceEvent += OnPlace;
    }

    private void OnDisable()
    {
        placePoint.OnPlaceEvent -= OnPlace;
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            buttonPress();
        }*/

        if (actualFloor == 1 && gem)
        {
            if (moving == true)
            {
                thisTransform.position = thisTransform.position + new Vector3(0, Time.deltaTime * elevatorSpeed, 0);
                if (thisTransform.position.y >= finalTransform.position.y)
                {
                    actualFloor = 2;
                    moving = false;
                }
            }
        }
        else if (actualFloor == 2 && gem)
        {
            if (moving == true)
            {
                thisTransform.position = thisTransform.position - new Vector3(0, Time.deltaTime * elevatorSpeed, 0);
                if (thisTransform.position.y <= initialTransform.position.y)
                {
                    actualFloor = 1;
                    moving = false;
                }
            }
        }
    }

    public void buttonPress()
    {
        moving = true;
    }

    public void OnPlace(PlacePoint point, Grabbable grab)
    {
        if(grab.name == "ChargedGem")
        {
            button.material = material;
            gem = true;
        }
    }
}
