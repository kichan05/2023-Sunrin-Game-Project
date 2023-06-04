
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;
using Random = UnityEngine.Random;

public class DoorAction : MonoBehaviour
{
    public Sprite[] doorTexture;
    private Transform doorFront;
    public float nextOpenTime;

    public bool isOpen = false;

    private void Start()
    {
        doorFront = transform.Find("DoorFront");
        changeDoorTextrue();
        nextOpenTime = Random.Range(5f, 10f);
    }

    private void Update()
    {
        if (nextOpenTime <= 0 && !isOpen)
        {
            openDoor();
        }
        else if(!isOpen)
        {
            nextOpenTime -= Time.deltaTime;
        }
    }
    
    private void changeDoorTextrue()
    {
        int imageIndex = Random.Range(0, doorTexture.Length);
        SpriteRenderer spriteRenderer = doorFront.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = doorTexture[imageIndex];
    }
    
    private void openDoor()
    {
        doorFront.position += new Vector3(0.3f, 0, 0);
        float newX = doorFront.localScale.x * 0.7f;
        doorFront.localScale = new Vector3(newX, 1, 1);

        isOpen = true;
    }

    public void closeDoor()
    {
        doorFront.position -= new Vector3(0.3f, 0, 0);
        float newX = doorFront.localScale.x / 0.7f;
        doorFront.localScale = new Vector3(newX, 1, 1);
        
        nextOpenTime = Random.Range(5f, 10f);
        isOpen = false;
    }
}
