using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class BubbleKids : MonoBehaviour
{
    RectTransform rect;
    float startScale;
    Image bubbleImage;
    int curBg;
    [SerializeField] List<Sprite> spriteBubbles;
    [SerializeField] Transform cellEnd;
    Vector3 pivot1;
    Vector3 pivot2;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
        bubbleImage = GetComponent<Image>();
        startScale = transform.localScale.x;
        pivot1 = rect.pivot;
        pivot2 = new Vector3(1, 0.5f);
    }

    private void OnEnable()
    {
        CameraSet.endCamMove += BubbleUpdatePosHint;
        CameraSet.startCamMove += SetScaleToZero;
        GameScene32Manager.end += EndGame;
    }

    private void OnDestroy()
    {
        CameraSet.endCamMove -= BubbleUpdatePosHint;
        CameraSet.startCamMove -= SetScaleToZero;
        GameScene32Manager.end -= EndGame;

    }

    IEnumerator StartScaleUp()
    {
        float eslapsed = 0;
        float seconds = 0.5f;
        int typeHint;

        if (curBg > 0 && curBg <= 3)
        {
            float posX = Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect - 0.1f;
            transform.position = new Vector3(posX, cellEnd.position.y, transform.position.z);

            rect.pivot = pivot2;
            bubbleImage.sprite = spriteBubbles[1];
            typeHint = 1;
        }
        else
        {
            transform.position = cellEnd.position;

            rect.pivot = pivot1;
            bubbleImage.sprite = spriteBubbles[0];
            typeHint = 0;
        }

        float end = startScale;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.localScale = new Vector3(eslapsed/seconds * end, eslapsed/seconds * end, eslapsed/seconds * end);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(end, end, end);
        curBg++;
        Hint(typeHint);
    }

    private void BubbleUpdatePosHint()
    {
        StopAllCoroutines();
        StartCoroutine(nameof(StartScaleUp));
    }

    private void Hint(int typeHint)
    {
        StopCoroutine(nameof(StartHint));   
        StartCoroutine(nameof(StartHint), typeHint);
    }

    IEnumerator StartHint(int typeHint)
    {
        Vector3 start, end;
        float eslapsed = 0f;
        float seconds = 1f;

        float dis = 0.75f;

        while (true)
        {
            eslapsed = 0;
            start = transform.position;
            if (typeHint == 0)
            {
                end = transform.position + new Vector3(-1, 1, 0) * dis;
            }
            else
            {
                end = transform.position + new Vector3(-1, 0, 0) * dis;
            }
            while (eslapsed <= seconds)
            {
                eslapsed += Time.deltaTime;
                transform.position = Vector3.Lerp(start, end, eslapsed/seconds);
                yield return new WaitForEndOfFrame();
            }
            transform.position = end;

            // Back
            eslapsed = 0;
            end = start;
            start = transform.position;
            while (eslapsed <= seconds)
            {
                eslapsed += Time.deltaTime;
                transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
                yield return new WaitForEndOfFrame();
            }
            transform.position = end;
        }
    }

    private void SetScaleToZero()
    {
        StopAllCoroutines();
        transform.localScale = Vector3.zero;
    }

    private void EndGame()
    {
        bubbleImage.sprite = spriteBubbles[2];
    }
}
