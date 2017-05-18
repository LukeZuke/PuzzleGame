using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 5.0f;
    public float drag = 0.5f;
    public float terminalRotationSpeed = 25.0f;
    public VirtualJoystick moveJoystick;

    private Rigidbody controller;
   


    private void Start()
    {
        controller = GetComponent<Rigidbody>();
        controller.maxAngularVelocity = terminalRotationSpeed;
        controller.drag = drag;

    }



    private void Update()
    {

        Vector3 joypad = Vector3.zero;
        joypad.x = Input.GetAxis("Horizontal");
        joypad.z = Input.GetAxis("Vertical");

        if (joypad.magnitude > 1)
            joypad.Normalize();

        if (moveJoystick.inputDirection != Vector3.zero)
        {
            joypad = moveJoystick.inputDirection;
        }
        
        Vector3 camera= Camera.main.transform.forward;
        camera.y = transform.position.y;
        camera.normalize();
        
        Vector3 dir = camera * joypad;
        
        controller.addForce(dir * moveSpeed);

        Vector3 tilt = Input.acceleration;

    }


}
