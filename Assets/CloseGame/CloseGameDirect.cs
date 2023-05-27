using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class CloseGameDirect : MonoBehaviour
{
    public float score = 0;
    public float MAX_SCORE = 100;
    public float plusScore = 5;

    public Transform loadingBar;
    private float maxLoadingBarWitdh;

    private void Start()
    {
        maxLoadingBarWitdh = loadingBar.localScale.x;
        loadingBar.localScale = new Vector3(0, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score += plusScore;
        }

        float scorePercent = score / MAX_SCORE;
        loadingBar.localScale = new Vector3(maxLoadingBarWitdh * scorePercent, 1, 1);
        Debug.Log("" + score + ", " + MAX_SCORE);

        if (score >= MAX_SCORE)
        {
            Debug.Log("게임 승리");
        }
    }
}
