using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMinigame : MonoBehaviour
{
    public void BeClicked()
    {
        StartCoroutine(StartBeClicked());
    }

    IEnumerator StartBeClicked()
    {
        float eslapsed = 0;
        float seconds = 0.25f;
        float start = transform.localScale.x;
        float end = 1.07f * start;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.localScale = new Vector3(start + (end - start) * eslapsed/seconds, start + (end - start) * eslapsed / seconds, start + (end - start) * eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(end, end, end);

        end = start;
        start = transform.localScale.x;
        eslapsed = 0;

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.localScale = new Vector3(start + (end - start) * eslapsed / seconds, start + (end - start) * eslapsed / seconds, start + (end - start) * eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(end, end, end);

    }

    public void ScaleDown()
    {
        StartCoroutine(StartScaleDown());
    }

    IEnumerator StartScaleDown()
    {
        float eslapsed = 0;
        float seconds = 0.25f;
        float start = transform.localScale.x;
        float end = 1.07f * start;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.localScale = new Vector3(start + (end - start) * eslapsed / seconds, start + (end - start) * eslapsed / seconds, start + (end - start) * eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(end, end, end);

        eslapsed = 0;
        seconds = 0.5f;
        start = transform.localScale.x;
        end = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.localScale = new Vector3(start + (end - start) * eslapsed / seconds, start + (end - start) * eslapsed / seconds, start + (end - start) * eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(end, end, end);
        Destroy(gameObject);
    }
}
