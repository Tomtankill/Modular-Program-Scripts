using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingController : BaseController {

    // movement information
    private Vector3 walkVelocity;

    // movement settings
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float jumpSpeed = 6f;
    private float moveX;
    private float moveZ;

    void Start() {
        input = InputManager.instance;
    }

    void FixedUpdate() {

        GetInput();
        CalculateMovement();
        ApplyMovement();
    }


    public override void GetInput() {

        moveX = input.GetAxis(PlayerID, InputAction.MoveVertical);
        moveZ = input.GetAxis(PlayerID, InputAction.MoveHorizontal);

    }

    private Vector3 CalculateMovement() {

        walkVelocity = Vector3.zero;

        // Vertical Movement
        if (moveX != 0) {
            walkVelocity += transform.forward * moveX * walkSpeed;
            if (moveZ != 0) {
                walkVelocity += transform.right * moveZ * walkSpeed;
                return walkVelocity;
            }
            return walkVelocity;
        }
        return walkVelocity;
    }

    private void ApplyMovement() {
        selfRigidBody.velocity = new Vector3(walkVelocity.x, selfRigidBody.velocity.y, walkVelocity.z);
    }
}
