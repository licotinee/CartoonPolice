using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgUIDetected : MonoBehaviour
{
    RectTransform rectTransform;
    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Canvas canvas = CanvasInstance.ins.canvas;
        float newScaleX = canvas.GetComponent<RectTransform>().rect.width / (rectTransform.rect.width * transform.localScale.x);
        float newScaleY = canvas.GetComponent<RectTransform>().rect.height / (rectTransform.rect.height * transform.localScale.y);

        if (newScaleX > 1 || newScaleY > 1)
        {
            float newScale = (newScaleX >= newScaleY ? newScaleX : newScaleY);
            rectTransform.localScale = new Vector3(newScale * transform.localScale.x, newScale * transform.localScale.y, 0);
        }
    }
}
