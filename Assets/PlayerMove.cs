using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 6.0f;
    public float MIN_DOOR_DISTANCE = 1.5f;
    public GameDirecter gameDirecter;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);
        Vector3 moveDirection = transform.TransformDirection(movement);
        transform.position += moveDirection * playerSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject nearestDoor = findNearDoor();
            float nearestDoorDistance = Vector3.Distance(nearestDoor.transform.position, transform.position);
            DoorAction nearestDoorAction = nearestDoor.GetComponent<DoorAction>();
            if (nearestDoorAction.isOpen && nearestDoorDistance <= MIN_DOOR_DISTANCE)
            {
                nearestDoorAction.closeDoor();
                gameDirecter.score += 1;
            }
        }
    }

    private GameObject findNearDoor()
    {
        GameObject[] doorList = GameObject.FindGameObjectsWithTag("door");
        Vector3 currentPosition = transform.position;

        GameObject nearestDoor = doorList[0];
        float nearestDoorDistance = Vector3.Distance(nearestDoor.transform.position, currentPosition);

        foreach (var door in doorList)
        {
            float distance = Vector3.Distance(door.transform.position, currentPosition);

            if (distance < nearestDoorDistance)
            {
                nearestDoor = door;
                nearestDoorDistance = distance;
            }
        }

        return nearestDoor;
    }
}
