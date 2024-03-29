using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_SessionShirt_8 : MonoBehaviour
{
    public void ScaleUp(float seconds)
    {
        StartCoroutine(StartScaleUp(seconds));
    }
    IEnumerator StartScaleUp(float seconds)
    {
        float eslapsed = 0;
        float maxScale = transform.localScale.x;
        transform.localScale = Vector3.zero;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.localScale = new Vector3((eslapsed / seconds) * maxScale, (eslapsed / seconds) * maxScale, (eslapsed / seconds) * maxScale);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(maxScale, maxScale, maxScale);
    }

    public void ScaleDown(float seconds)
    {
        StartCoroutine(StartScaleDown(seconds));
    }
    IEnumerator StartScaleDown(float seconds)
    {
        float eslapsed = 0;
        float maxScale = transform.localScale.x;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.localScale = new Vector3((1 - eslapsed / seconds) * maxScale, (1 - eslapsed / seconds) * maxScale, (1 - eslapsed / seconds) * maxScale);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = Vector3.zero;
    }
}
