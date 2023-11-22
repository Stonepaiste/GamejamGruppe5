using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public GameObject flashlight;
    public bool flashlightEnabled = true;
    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate() 
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //så man ikke kan roterer mere en 90 grader op og ned

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && flashlightEnabled == true)
        {
            flashlight.SetActive(false);
            flashlightEnabled = false;
        }
        else if (Input.GetMouseButtonDown(0) && flashlightEnabled == false)
        {
            flashlight.SetActive(true);
            flashlightEnabled = true;
        }
    }
}
