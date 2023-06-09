using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameDirecter : MonoBehaviour
{
    public int score = 0;
    
    void Update()
    {
        Debug.Log(score);
    }
}
