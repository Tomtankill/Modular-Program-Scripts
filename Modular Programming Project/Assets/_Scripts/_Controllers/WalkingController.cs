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

        moveX = input.GetAxis(PlayerID, InputAction.MoveVertical);
        moveZ = input.GetAxis(PlayerID, InputAction.MoveHorizontal);

        GetInput();

    }

    public override void GetInput() {

        walkVelocity = Vector3.zero;

        // Vertical Movement
        if (moveX != 0) {
            walkVelocity += transform.forward * moveX * walkSpeed;
        }

        // Horizontal Movement
        if (moveZ != 0) {
            walkVelocity += transform.right * moveZ * walkSpeed;
        }

        selfRigidBody.velocity = new Vector3(walkVelocity.x, selfRigidBody.velocity.y, walkVelocity.z);

    }
}
