using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Clip_SessionShirt_8 : MonoBehaviour, IDragHandler, IDropHandler
{
    Canvas canvas;

    private RectTransform rectTransform;
    [SerializeField] Image shirt;
    [SerializeField] float minDist;
    [SerializeField] Sprite spriteClipping;
    [SerializeField] Image Hande;
    [SerializeField] Bag_SessionShirt_8 bag;
    bool isClipping;
    bool isDropping;
    float startScale;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        startScale = transform.localScale.x;
    }

    private void Update()
    {
        CheckToClipShirt();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (!isDropping)
        {
            transform.localScale = new Vector3(1.2f * startScale, 1.2f * startScale, 1.2f * startScale);
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
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

    void CheckToClipShirt()
    {
        if (Vector2.Distance(transform.position, shirt.transform.position) <= minDist && !isClipping)
        {
            isClipping = true;
            Hande.sprite = spriteClipping;
            shirt.transform.position = transform.position;
            shirt.transform.parent = transform;
            shirt.transform.SetAsFirstSibling();
            bag.gameObject.SetActive(true);
            bag.MoveUp(0.5f);
        }
    }

    void CheckToDropShirtToBag()
    {
        if (bag)
        {
            if (Vector2.Distance(shirt.transform.position, bag.transform.position) <= minDist + 4.5f && !isDropping)
            {
                isDropping = true;
                MoveDown(0.5f);
                DropShirt(0.5f);
            }
        }
    }

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        transform.localScale = new Vector3(startScale, startScale, startScale);
        CheckToDropShirtToBag();
    }

    void MoveDown(float seconds)
    {
        StartCoroutine(StartMoveDown(seconds));
    }

    IEnumerator StartMoveDown(float seconds)
    {
        Vector3 start = transform.position;
        Vector3 end = transform.position - new Vector3(0, 10f, 0);

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

    void DropShirt(float seconds)
    {
        StartCoroutine(StartDropShirt(seconds));
    }

    IEnumerator StartDropShirt(float seconds)
    {
        Vector3 start = bag.transform.position + new Vector3(0, 4f, 0);
        Vector3 end = bag.transform.position;

        shirt.transform.position = start;

        float eslapsed = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            shirt.transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        shirt.transform.position = end;
        shirt.transform.parent = bag.transform;
        shirt.transform.SetAsFirstSibling();

        yield return new WaitForSeconds(0.1f);
        SessionShirt_8.ins.screen.ScaleDown(0.5f);
        bag.MoveToCenter(0.5f);
    }


}
