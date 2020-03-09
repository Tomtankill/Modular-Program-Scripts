using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseController : MonoBehaviour
{
    // Plugging in InputManager
    protected IInputManager input;
    protected static int PlayerID;

    protected Rigidbody selfRigidBody;
    protected bool newInput;
    protected bool Grounded;
    private void Awake() {
        PlayerID = 0;
        selfRigidBody = gameObject.GetComponent<Rigidbody>();
    }

    public abstract void ReadInput();
    public abstract bool IsGrounded();
}
