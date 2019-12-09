using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        GetInput();

    }

    public override void GetInput() {

        float mouseX = input.GetAxis(PlayerID, InputAction.LookHorizontal) * mouseSensitivity * Time.deltaTime;
        float mouseY = input.GetAxis(PlayerID, InputAction.LookVertical) * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerBody.Rotate(Vector3.left * mouseY);
        playerBody.parent.Rotate(Vector3.up * mouseX);
    }
}
