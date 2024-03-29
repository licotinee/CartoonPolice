using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hint : MonoBehaviour
{
    float scaleNormal;

    public delegate void EStopHint();
    public static EStopHint eStopHint;

    private void Awake()
    {
        scaleNormal = transform.localScale.x;
    }

    private void OnEnable()
    {
        eStopHint += StopHint;
        StartCoroutine(nameof(StartHint));
    }

    private void OnDestroy()
    {
        eStopHint -= StopHint;
    }

    private void StopHint()
    {
        StopCoroutine(nameof(StartHint));
        transform.localScale = new Vector3(scaleNormal, scaleNormal, scaleNormal);  
    }

    IEnumerator StartHint()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            //scaleNormal = transform.localScale.x;
            float startScale = scaleNormal;
            float maxScale = startScale * 1.2f;

            float speed = 0.7f;
            // first
            while (transform.localScale.x <= maxScale)
            {
                transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            transform.localScale = new Vector3(maxScale, maxScale, maxScale);

            while (transform.localScale.x >= startScale)
            {
                transform.localScale -= new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            transform.localScale = new Vector3(startScale, startScale, startScale);

            // second
            while (transform.localScale.x <= maxScale)
            {
                transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            transform.localScale = new Vector3(maxScale, maxScale, maxScale);

            while (transform.localScale.x >= startScale)
            {
                transform.localScale -= new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            transform.localScale = new Vector3(startScale, startScale, startScale);
        }
    }     
}
