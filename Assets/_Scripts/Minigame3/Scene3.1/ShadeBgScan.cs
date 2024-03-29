using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadeBgScan: MonoBehaviour
{
    RectTransform rectTransform;
    Canvas canvas;
    public void Start()
    {
        canvas = CanvasInstance.ins.canvas;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localScale = new Vector3(canvas.GetComponent<RectTransform>().rect.width / (rectTransform.rect.width),
        canvas.GetComponent<RectTransform>().rect.height / (rectTransform.rect.height));
        rectTransform.transform.position = Vector3.zero;
    }

}
