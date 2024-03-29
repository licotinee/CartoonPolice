using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonScan_Scene1_3 : MonoBehaviour
{
    [SerializeField] private float timeDelayHint;
    private float scaleNormal;

    public delegate void ButtonScanClicked();
    public static event ButtonScanClicked buttonScanClicked;

    private void Start()
    {
        scaleNormal = transform.localScale.x;
        Hint();
    }

    private void Hint()
    {
        StartCoroutine(nameof(StartHint));
    }

    public void BeClicked()
    {
        buttonScanClicked?.Invoke();
        StopCoroutine(nameof(StartHint));
        transform.localScale = new Vector3(scaleNormal, scaleNormal, scaleNormal);
    }

    IEnumerator StartHint()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeDelayHint);
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
