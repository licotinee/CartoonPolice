using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Broom_SessionFinger_8 : MonoBehaviour, IDragHandler
{
    Canvas canvas;

    private RectTransform rectTransform;
    [SerializeField] Dust_SessionFinger_8 dust;
    [SerializeField] MicroScope_SessionFinger_8 scope;

    [SerializeField] float minDist;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    float timeInstantiateDust = 0.1f;
    float eslapsed = 0;
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (!scope.isComplete)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            if (Vector2.Distance(scope.transform.position, transform.position) <= minDist)
            {
                eslapsed += Time.deltaTime;
                if (eslapsed >= timeInstantiateDust)
                {
                    //reset
                    eslapsed = 0;

                    Dust_SessionFinger_8 left = Instantiate(dust, transform.position, Quaternion.identity, transform);
                    left.SetPos(-1);
                    Dust_SessionFinger_8 right = Instantiate(dust, transform.position, Quaternion.identity, transform);
                    right.SetPos(1);
                    left.transform.SetAsFirstSibling();
                    right.transform.SetAsFirstSibling();
                }

                scope.UpdateFinger();
                if (scope.isComplete)
                {
                    MoveDown(0.5f);
                }
            }
        }
    }

    public void MoveUp(float seconds)
    {
        StartCoroutine(StartMoveUp(seconds));
    }
    IEnumerator StartMoveUp(float seconds)
    {
        Vector3 end = transform.position;
        Vector3 start = transform.position - new Vector3(0, 10f, 0);

        transform.position = start;

        float eslapsed = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    }

    public void MoveDown(float seconds)
    {
        StartCoroutine(StartMoveDown(seconds));
    }

    IEnumerator StartMoveDown(float seconds)
    {
        Vector3 start = transform.position;
        Vector3 end = transform.position - new Vector3(0, 7f, 0);

        float eslapsed = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        gameObject.SetActive(false);
    }
}
