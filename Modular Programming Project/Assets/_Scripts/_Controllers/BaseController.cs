using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public abstract class BaseController : MonoBehaviour
{
    // Plugging in InputManager
    protected IInputManager input;
    protected int PlayerID;

    protected Rigidbody selfRigidBody;
    protected bool newInput;

    private void Awake() {
        PlayerID = 0;
        selfRigidBody = gameObject.GetComponent<Rigidbody>();
    }

    public abstract void GetInput();
}
