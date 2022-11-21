using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    private float _xRotation = 0f;
    private float _yRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    
        _xRotation -= mouseY; //The amount of rotation up and down to rotate camera and character
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        _yRotation -= mouseX;
        var localRotation = Quaternion.Euler(_xRotation, -_yRotation, 0f);
        transform.localRotation = localRotation;
        
        //
        // // transform.Rotate();
        // print($"Mouse Y: {mouseY}");

        playerBody.Rotate(Vector3.up * mouseX); //Rotate character by the same amount as camera
        
    }
}