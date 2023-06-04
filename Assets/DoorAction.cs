
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;
using Random = UnityEngine.Random;

public class DoorAction : MonoBehaviour
{
    public Sprite[] doorTexture;
    public Transform doorFront;

    private void Start()
    {
        doorFront = transform.Find("DoorFront");
        // changeDoorTextrue();
        Debug.Log(doorFront);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            doorFront.position += new Vector3(0.3f, 0, 0);
            float newX = doorFront.localScale.x * 0.7f;
            doorFront.localScale = new Vector3(newX, 1, 1);
            Debug.Log("변경");
        }
    }

    private void changeDoorTextrue()
    {
        int imageIndex = Random.Range(0, doorTexture.Length);
        doorFront.GetComponent<Image>().sprite = doorTexture[imageIndex];
    }
}
