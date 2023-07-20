using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;

    private Vector3 desiredPosition;
    private Vector3 offset;
    private Vector2 touchPosition;
    private float swipeResistace = 200.0f;

    private float smoothSpeed = 7.5f;
    private float distance = 5.0f;
    private float yOffset = 3.5f;

    private void Start()
    {
        //makes the camera goes behinde Vector3 
        offset = new Vector3 (0, yOffset, -2f * distance);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
            SlideCamera (true);
        else if(Input.GetKeyDown(KeyCode.RightArrow))
            SlideCamera (false);

        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            touchPosition = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            //rotating camera 
            float swipeForce = touchPosition.x - Input.mousePosition.x;
            if(Mathf.Abs (swipeForce) > swipeResistace)
            {
                if(swipeForce < 0 )
                    SlideCamera (true);
                else
                    SlideCamera (false);
            }
        }


        //desiredPosition = lookAt.position + offset;
        //transform.position = Vector3.Lerp(transform.position,desiredPosition, smoothSpeed * Time.deltaTime);
        //transform.LookAt (lookAt.position + Vector3.up);
    }
    private void FixedUpdate()
    {
        desiredPosition = lookAt.position + offset;
        transform.position = Vector3.Lerp(transform.position,desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt (lookAt.position + Vector3.up);
    }

    public void SlideCamera(bool left)
    {
        if(left)
            offset = Quaternion.Euler(0, 90, 0) * offset;
        else
            offset = Quaternion.Euler (0, -90, 0) * offset;

    }
}
