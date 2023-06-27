using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource audioSource; // 오디오 소스 참조
    public float delay = 13.0f;     // 오디오 멈춤 지연 시간 (13초)

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(StopAudio());
    }

    IEnumerator StopAudio()
    {
        // 지연 시간만큼 기다림
        yield return new WaitForSeconds(delay);

        // 오디오 멈춤
        audioSource.Stop();
    }
}
