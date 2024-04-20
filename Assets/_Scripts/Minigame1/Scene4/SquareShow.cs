using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareShow : MonoBehaviour
{
    public void ScaleDown(float seconds)
    {
        StartCoroutine(StartScaleDown(seconds));
    }

    IEnumerator StartScaleDown(float seconds)
    {
        float start = transform.localScale.x;
        float eslapsed = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.localScale = new Vector3((1 - eslapsed / seconds) * start, (1 - eslapsed / seconds) * start, (1 - eslapsed / seconds) * start);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = Vector3.zero;
        Destroy(gameObject);
    }

}
