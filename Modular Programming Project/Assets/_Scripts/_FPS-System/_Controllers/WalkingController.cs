using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class WalkingController : BaseController {

    // movement information
    private float moveX;
    private float moveZ;
    private Vector3 _movement;
    private bool _jump;
    private float gravityFloat = -9.81f;

    // movement settings
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float jumpHeight = 6f;
    [SerializeField] private bool movementModifiers = true;


    Collider m_Collider;
    private bool m_HitDetect;
    RaycastHit m_Hit;
    float m_MaxDistance = 300f;
    LayerMask groundMask;



    void Start() {
        input = InputManager.instance;
        m_Collider = GetComponent<Collider>();
        groundMask = LayerMask.GetMask("Ground");
    }

    void Update() {
        ReadInput(); // Set bool to do something to true, just in case update runs twice before fixedUpdate
        m_HitDetect = Physics.BoxCast(m_Collider.bounds.center, transform.localScale, Vector3.down, out RaycastHit m_Hit, transform.rotation, m_MaxDistance, groundMask);
        Debug.Log(m_HitDetect);
    }

    void FixedUpdate() {
        CalculateMovement();
        Jump();

    }


    void OnDrawGizmos() {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (m_HitDetect) {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, Vector3.down * m_Hit.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(transform.position + m_Hit.point, transform.localScale);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        //else {
        //    //Draw a Ray forward from GameObject toward the maximum distance
        //    Gizmos.DrawRay(transform.position, Vector3.down * m_MaxDistance);
        //    //Draw a cube at the maximum distance
        //    Gizmos.DrawWireCube(transform.position + Vector3.down * m_MaxDistance, transform.localScale);
        //}
    }



    private void Gravity() {

    }


    public override void ReadInput() {

        float horizontal = input.GetAxis(PlayerID, InputAction.MoveHorizontal);
        float vertical = input.GetAxis(PlayerID, InputAction.MoveVertical);

        _movement = new Vector3(horizontal, 0f, vertical);

        //if (!IsGrounded) {
        //    _movement -= new Vector3(0.0f, gravityFloat, 0.0f);
        //}

        if (input.GetButtonDown(PlayerID, InputAction.Jump) && IsGrounded()) {
            _jump = true;
        }

    }

    private void Jump() {
        if (_jump) {
            selfRigidBody.AddForce(Vector3.up * jumpHeight);
            _jump = false;
        }
    }

    void CalculateMovement() {

        _movement *= walkSpeed;

        if (movementModifiers) {
            CalculateAdditionalMovement();
        } else {
            ApplyMovement();
        }
    }

    private void CalculateAdditionalMovement() {



        ApplyMovement();
    }

    private void ApplyMovement() {
        selfRigidBody.velocity = _movement;
    }

    public override bool IsGrounded() {
        Grounded = Physics.BoxCast(Vector3.zero, transform.localScale, Vector3.down);
        
        return true;
    }
}