using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueTickBar : MonoBehaviour
{
    float startScale;
    private void Awake()
    {
        startScale = transform.localScale.x;
        transform.localScale = Vector3.zero;
        StartCoroutine(nameof(StartEnlarge));
    }

    IEnumerator StartEnlarge()
    {
        float speed = 5f;
        while (transform.localScale.x <= startScale)
        {
            transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(startScale, startScale, startScale);
    }
}
