using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeCar : MonoBehaviour
{
    SpriteRenderer sprite;
    float startScale;
    private void Awake()
    {
        startScale = transform.localScale.x;
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(255, 255, 255, 0);
    }

    public void Enable(float seconds)
    {
        StartCoroutine(StartEnable(seconds / 2));
        StartCoroutine(StartScaleUp(seconds / 2));
    }

    IEnumerator StartEnable(float seconds)
    {
        float eslapsed = 0;
        while(eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            sprite.color = new Color(255, 255, 255, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        sprite.color = new Color(255, 255, 255, 1);
    }

    IEnumerator StartScaleUp(float seconds)
    {
        float start = 0.3f * startScale;
        float end = startScale;
        transform.localScale = new Vector3(start, start, start);
        float eslapsed = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.localScale = new Vector3(start + (eslapsed/seconds) * (end - start), start + (eslapsed / seconds) * (end - start), start + (eslapsed / seconds) * (end - start));
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(end, end, end);
    }
}
