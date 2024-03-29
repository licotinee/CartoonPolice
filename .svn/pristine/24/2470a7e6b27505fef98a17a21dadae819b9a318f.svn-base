using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgObDetected : MonoBehaviour
{
    SpriteRenderer sprite;
    float widthCam;
    float heightCam;
    float widthSprite;
    float heightSprite;
    private void Start()
    {
        heightCam = Camera.main.orthographicSize * 2;
        widthCam = heightCam * Camera.main.aspect;
        sprite = GetComponent<SpriteRenderer>();
        widthSprite = sprite.bounds.size.x;
        heightSprite = sprite.size.y;

        float newScaleX = widthCam / widthSprite;
        float newScaleY = heightCam / heightSprite;
        if (newScaleX > 1 || newScaleY > 1)
        {
            float newScale = (newScaleX >= newScaleY ? newScaleX : newScaleY);
            sprite.transform.localScale = new Vector3(newScale, newScale, 0);
        }
    }
}
