using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleAnimation : MonoBehaviour
{
    public int index;
    private float showTimein = 3f / 2f;
    private float delay = 1f / 3f;
    public float progress = 0;

    void Start()
    {
        Vector4 color = gameObject.transform.GetComponent<Image>().color;
        transform.GetComponent<Image>().color = new Vector4(color.x, color.y, color.z, 0);

        StartCoroutine(animtaion());
    }

    IEnumerator animtaion()
    {
        yield return new WaitForSeconds(0.5f + showTimein * (index - 1) + delay * index);

        while (progress < showTimein)
        {
            progress += Time.deltaTime;
            Debug.Log(""  + index + " / " + progress);
            
            Vector4 color = gameObject.transform.GetComponent<Image>().color;
            transform.GetComponent<Image>().color = new Vector4(color.x, color.y, color.z, progress / showTimein);
            
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
