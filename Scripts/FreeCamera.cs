using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    public VirtualJoystick cameraJoystick;

    public Transform lookAt;

    private float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 11.0f;
    private float sensivityX = 3.0f;
    private float sensivityY = 1.0f;

    private void Update()
    {
        currentX += cameraJoystick.InputDirection.x * sensivityX;
        currentY += cameraJoystick.InputDirection.z * sensivityY;
    }
    private void LateUpdate()
    {
        //-distance will put us 10 meter behind the ball
        Vector3 dir = new Vector3(0, 0 , -distance);
        Quaternion rotation = Quaternion.Euler (currentY, currentX, 0);
        //gives us the offset of where the camera is related to the player
        transform.position = lookAt.position + rotation * dir; 
        transform.LookAt (lookAt);
    }
}
