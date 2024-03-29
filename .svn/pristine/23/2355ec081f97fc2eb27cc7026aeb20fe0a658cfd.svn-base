using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Scan_SessionFoot_8 : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler   
{
    Canvas canvas;

    private RectTransform rectTransform;
    float startScale;
    [SerializeField] GameObject footPrint;
    [SerializeField] float minDist;

    bool isComplete;
    [SerializeField] Image whiteBg;
    [SerializeField] FootScan_SessionFoot_8 footScanImage;
    
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        startScale = rectTransform.localScale.x;
    }

    private void Update()
    {
        CheckScan();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (!isComplete)
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
        if (!isComplete)
            rectTransform.localScale = new Vector3(1.2f * startScale, 1.2f * startScale, 1.2f * startScale);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isComplete)
            rectTransform.localScale = new Vector3(startScale, startScale, startScale);
    }

    private void CheckScan()
    {
        if (Vector2.Distance(transform.position, footPrint.transform.position) <= minDist && !isComplete)
        {
            isComplete = true;
            StartCoroutine(StartComplete());
        }
    }

    IEnumerator StartComplete()
    {
        whiteBg.gameObject.SetActive(true);
        transform.position = new Vector3(footPrint.transform.position.x, footPrint.transform.position.y, transform.position.z);
        rectTransform.localScale = new Vector3(1.2f * startScale, 1.2f * startScale, 1.2f * startScale);
        yield return new WaitForSeconds(0.5f);

        // get small height
        float speed = 2f;
        while (rectTransform.localScale.y >= 0)
        {
            rectTransform.localScale -= new Vector3(0, speed * Time.deltaTime, 0);
            yield return new WaitForEndOfFrame();
        }
        rectTransform.localScale = Vector3.zero;
        footScanImage.gameObject.SetActive(true);

    }
}
