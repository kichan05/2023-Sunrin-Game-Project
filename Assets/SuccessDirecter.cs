using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SuccessDirecter : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public float currentTile = 0;
    public float delayTime = 3;

    // Update is called once per frame
    void Update()
    {
        if (currentTile >= delayTime)
        {
            videoPlayer.Play();
        }
        else
        {
            currentTile += Time.deltaTime;
        }
    }
}
