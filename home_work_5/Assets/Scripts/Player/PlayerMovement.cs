using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;              
    public float mouseSensitivity = 100f;  

    private float verticalLookRotation = 0f;  
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody not found on object Player!");
        }

        rb.freezeRotation = true;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        Debug.Log("mouseX: " + mouseX);

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f); 
        Camera.main.transform.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);

        Debug.Log("mouseY: " + mouseY);

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        rb.MovePosition(rb.position + move * speed * Time.deltaTime);

        Debug.Log("MoveX: " + moveX + ", MoveZ: " + moveZ);
    }
}
