using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 6.0f;
    public float MIN_DOOR_DISTANCE = 1.5f;
    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);
        Vector3 moveDirection = transform.TransformDirection(movement);
        transform.position += moveDirection * playerSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject[] doorList = GameObject.FindGameObjectsWithTag("door");
            Vector3 currentPostion = transform.position;

            GameObject nearestDoor = doorList[0];
            float nearestDoorDistance = Vector3.Distance(nearestDoor.transform.position, currentPostion);

            foreach (var door in doorList)
            {
                float distance = Vector3.Distance(door.transform.position, currentPostion);

                if (distance < nearestDoorDistance)
                {
                    nearestDoor = door;
                    nearestDoorDistance = distance;
                }
            }
            
            DoorAction nearestDoorAction = nearestDoor.GetComponent<DoorAction>();

            Debug.Log(nearestDoorDistance);

            if (nearestDoorAction.isOpen && nearestDoorDistance <= MIN_DOOR_DISTANCE)
            {
                nearestDoorAction.closeDoor();
            }
        }
        
        
    }
}
