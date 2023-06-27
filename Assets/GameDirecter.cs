using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirecter : MonoBehaviour
{
    public Transform cam;
    public float shakeSpeed = 2.0f;
    public float shakeAmount = 1.0f;

    public float failShakeTime = 10f;
    
    public int score = 0;
    public Text scoreText;
    
    public float gameTime = 30f;
    public int successDoorCount = 30;

    public AudioClip earthquakeSound;
    public AudioSource alert;
    
    void Update()
    {
        scoreText.text = "닫은 문의 개수\n" + score + "개";
    }
    
    void Start()
    {
        StartCoroutine(gameEnd());
    }

    IEnumerator gameEnd()
    {
        yield return new WaitForSeconds(gameTime);

        Debug.Log("끌");

        if (score < successDoorCount) // 실패
        {
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.mute = true;
            
            yield return new WaitForSeconds(0.5f);
            
            audioSource.clip = earthquakeSound;
            audioSource.time = 3f;
            audioSource.Play();
            
            alert.Play();
            
            yield return new WaitForSeconds(5f);
            StartCoroutine(camShake());
        }
        else // 성공
        {
            SceneManager.LoadScene("Scenes/SuccessScene");
        }
    }
    
    IEnumerator camShake()
    {
        Vector3 originPosition = cam.localPosition;
        float elapsedTime = 0.0f;
 
        while (elapsedTime < failShakeTime)
        {
            Vector3 randomPoint = originPosition + Random.insideUnitSphere * shakeAmount;
            cam.localPosition = Vector3.Lerp(cam.localPosition, randomPoint, Time.deltaTime * shakeSpeed);
 
            yield return null;
 
            elapsedTime += Time.deltaTime;
        }
 
        cam.localPosition = originPosition;
        SceneManager.LoadScene("Scenes/FailScene");
    }
}
