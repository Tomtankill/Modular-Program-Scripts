using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]


public class Druid : MonoBehaviour
{
    private IInputManager input;
    private Rigidbody selfRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        input = InputManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        float x = input.GetAxis(0, InputAction.MoveHorizontal);
        selfRigidBody.velocity(Vector3(0, x, 0));
        //float z = input.GetAxis(0, "Vertical");
        //if (input.GetButton(0, InputAction.MoveHorizontal)) {
        //    selfRigidBody.velocity +=
        //}
    }
}
