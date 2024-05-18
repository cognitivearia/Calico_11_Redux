using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;
using DG.Tweening;

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

    private PathType pathTypeSys = PathType.Linear;
    private Vector3[] pathvalF = new Vector3[1];
    private Vector3[] pathvalI = new Vector3[1];
    private Tween t;

    void Start()
    {
        thisTransform = GetComponent<Transform>();
        pathvalF[0] = finalTransform.position;
        pathvalI[0] = initialTransform.position;
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            buttonPress();
        }

        if (actualFloor == 1 && gem)
        {
            if (moving == true)
            {
                // OLD // thisTransform.position = thisTransform.position + new Vector3(0, Time.deltaTime * elevatorSpeed, 0);
                //thisTransform.DOMoveY(finalTransform.position.y, elevatorSpeed);   //(finalTransform.position, elevatorSpeed);

                t = thisTransform.DOPath(pathvalF, elevatorSpeed, pathTypeSys);
                t.SetEase(Ease.Linear);

                if (thisTransform.position.y >= finalTransform.position.y - 1)
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
                // OLD // thisTransform.position = thisTransform.position - new Vector3(0, Time.deltaTime * elevatorSpeed, 0);
                //thisTransform.DOMoveY(initialTransform.position.y, elevatorSpeed);

                t = thisTransform.DOPath(pathvalI, elevatorSpeed, pathTypeSys);
                t.SetEase(Ease.Linear);

                if (thisTransform.position.y <= initialTransform.position.y + 1)
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
