using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInstance : MonoBehaviour
{
    public static CanvasInstance ins;
    public Canvas canvas;
    private void Awake()
    {
        ins = this;
        canvas = GetComponent<Canvas>();
    }
}
