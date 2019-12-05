 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]


public class Druid : MonoBehaviour {
    private IInputManager input;
    private Rigidbody selfRigidBody;

    private float hRange;
    private float vRange;
    private float Height;

    // Start is called before the first frame update
    void Start() {
        input = InputManager.instance;
        hRange = 1;
        vRange = 1;
        Height = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate() {


        if (input.GetButton(0, InputAction.MoveHorizontal)) {
            Debug.Log(input.GetAxis(0, InputAction.MoveHorizontal));
        }

        float h = input.GetAxis(0, InputAction.MoveHorizontal);

        float v = input.GetAxis(0, InputAction.MoveHorizontal);

        float xPos = h * hRange;
        float vPos = v * vRange;

        gameObject.transform.position = new Vector3(xPos, Height, vPos);

    }
}
