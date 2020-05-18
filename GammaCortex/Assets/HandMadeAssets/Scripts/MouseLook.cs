using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseLook : MonoBehaviour
{
    public float mouseSpeed = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        //Mouse locked at center of screen
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        //Input mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        //Flip directions to proper work
        xRotation -= mouseY;

        //Clamping camera rot at 180 degrees
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //X axis rot applied                            X     Y   Z
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
        
    }
}