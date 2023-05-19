using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    public float kaguya = 10;
    
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        playerPosition.z = kaguya;
        transform.position = playerPosition;
    }
}
