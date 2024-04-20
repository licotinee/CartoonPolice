using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScanningBtn : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] Image fingerCompleted;
    [SerializeField] Image rayScan;
    [SerializeField] float speed;
    [SerializeField] Transform startFinger;
    [SerializeField] Transform endFinger;
    [SerializeField] Transform endPos;
    private float normalScale;
    private float lengthScan;
    private bool isPressed;
    private bool isComplete;

    public delegate void CompleteScan();
    private void OnEnable()
    {
        normalScale = transform.localScale.x;
        lengthScan = startFinger.position.y - endFinger.position.y;
        Scale(0, normalScale);
    }

    private void Scale(float startScale, float endScale)
    {
        StartCoroutine(StartScale(startScale, endScale));
    }

    IEnumerator StartScale(float startScale, float endScale)
    {
        float eslapsed = 0;
        float seconds = 0.25f;

        transform.localScale = new Vector3(startScale, startScale, startScale);

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.localScale = new Vector3(startScale + eslapsed / seconds * (endScale - startScale),
                                               startScale + eslapsed / seconds * (endScale - startScale),
                                               startScale + eslapsed / seconds * (endScale - startScale));
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(endScale, endScale, endScale);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        StopCoroutine(nameof(StartScan));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isComplete)
        {
            isPressed = true;
            StartCoroutine(nameof(StartScan));
        }
    }

    IEnumerator StartScan()
    {
        while (isPressed && !isComplete)
        {
            rayScan.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);

            float newValue = (startFinger.position.y - rayScan.transform.position.y) / lengthScan;
            fingerCompleted.fillAmount = newValue;

            if (rayScan.transform.position.y <= endPos.position.y)
            {
                isComplete = true;
                CompleteScanning();
                StopCoroutine(nameof(StartScan));
                Destroy(rayScan.gameObject);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private void CompleteScanning()
    {
        StartCoroutine(nameof(StartDisableScan));
    }


    IEnumerator StartDisableScan()
    {
        yield return new WaitForSeconds(0.5f);
        Scale(normalScale, 0);
        yield return new WaitForSeconds(0.5f);
        UIManager_Scene1_3.ins.CompleteScanningGamePlayPanel();
    }
}


