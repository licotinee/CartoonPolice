using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke_Scene2_4 : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Fade()
    {
        StartCoroutine(StartFade());
    }

    IEnumerator StartFade()
    {
        float eslapsed = 0;
        float seconds = 1f;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            spriteRenderer.color = new Color(255, 255, 255, 1 - eslapsed/seconds);
            yield return new WaitForEndOfFrame();
        }
        spriteRenderer.color = new Color(255, 255, 255, 0);
    }
}
