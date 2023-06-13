using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameDirecter : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    
    void Update()
    {
        scoreText.text = "닫은 문의 개수\n" + score + "개";
    }
}
