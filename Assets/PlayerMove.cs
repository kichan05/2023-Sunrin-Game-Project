using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 6.0f;
    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized;

        Vector3 moveDirection = transform.TransformDirection(movement);

        transform.position += moveDirection * playerSpeed * Time.deltaTime;
    }
}
