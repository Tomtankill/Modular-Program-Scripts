using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraControl : BaseController
{

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        input = InputManager.instance;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        ReadInput();

    }

    public override void ReadInput() {

        float mouseX = input.GetAxis(PlayerID, InputAction.LookHorizontal) * mouseSensitivity * Time.deltaTime;
        float mouseY = input.GetAxis(PlayerID, InputAction.LookVertical) * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.Rotate(Vector3.left * mouseY);
        Camera.main.transform.Rotate(Vector3.up * mouseX);
    }

    public override bool IsGrounded() {
        throw new System.NotImplementedException();
    }
}
