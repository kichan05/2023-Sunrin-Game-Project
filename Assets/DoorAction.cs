
using System;
using System.Collections;
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
    public GameDirecter gameDirecter;

    public bool isOpen = false;
    public float openTime = 5f;

    private void Start()
    {
        ParticleSystem partical = transform.Find("smoke").GetComponent<ParticleSystem>();
        partical.gameObject.SetActive(false);
        partical.Play(false);
        
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
        ParticleSystem partical = transform.Find("smoke").GetComponent<ParticleSystem>();
        partical.gameObject.SetActive(true);
        partical.Play(true);
        
        doorFront.position += new Vector3(0.3f, 0, 0);
        float newX = doorFront.localScale.x * 0.7f;
        doorFront.localScale = new Vector3(newX, 1, 1);

        isOpen = true;

        StartCoroutine(closeFail());
    }

    public void closeDoor()
    {
        transform.Find("smoke").gameObject.SetActive(false);
        
        doorFront.position -= new Vector3(0.3f, 0, 0);
        float newX = doorFront.localScale.x / 0.7f;
        doorFront.localScale = new Vector3(newX, 1, 1);
        
        nextOpenTime = Random.Range(5f, 10f);
        isOpen = false;
    }
    
    public IEnumerator closeFail()
    {
        yield return new WaitForSeconds(openTime);
        
        if (isOpen)
        {
            closeDoor();
            if (gameDirecter.score != 0)
            {
                gameDirecter.score -= 1;
            }
        }
    }
}
