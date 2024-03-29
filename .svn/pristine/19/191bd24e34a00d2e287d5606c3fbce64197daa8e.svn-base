using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ResponsiveCam : MonoBehaviour
{
    private float widthDefault = 2208;
    private float heightDefault = 1242;

    float scaleX;
    float scaleY;
    public void Awake()
    {   
        scaleX = Screen.width / widthDefault;
        scaleY = Screen.height / heightDefault;
        if (scaleX >= 1 || scaleY >= 1)
        {     
            float newScale = (scaleX >= scaleY ? scaleX : scaleY);
            Camera.main.orthographicSize = Camera.main.orthographicSize / newScale;
        }
    }


}
