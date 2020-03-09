using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementType {Walking, Driving, Flying }


public class Player : MonoBehaviour
{
    public MovementType startingMovementType;
    private MovementType movementType;
    public  MovementType MovementType 
    {
        get { return movementType; }
        set 
        {
            movementType = value;
            switch (movementType) {
                case MovementType.Walking:
                    walkingController.enabled = true;
                    drivingController.enabled = false;
                    flyingController.enabled = false;

                    break;
                case MovementType.Driving:
                    walkingController.enabled = false;
                    drivingController.enabled = true;
                    flyingController.enabled = false;

                    break;
                case MovementType.Flying:
                    walkingController.enabled = false;
                    drivingController.enabled = false;
                    flyingController.enabled = true;
                    break;
                default:
                    break;
            }
        }
    }
    private WalkingController walkingController;
    private DrivingController drivingController;
    private FlyingController flyingController;

    private void Start() {
        walkingController = GetComponent<WalkingController>();
        drivingController = GetComponent<DrivingController>();
        flyingController = GetComponent<FlyingController>();
        MovementType = startingMovementType;
    }

}
