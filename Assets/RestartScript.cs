using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public void restartButtonClick()
    {
        // IntroScene으로 이동
        SceneManager.LoadScene("Scenes/MainScene");
    }
}
