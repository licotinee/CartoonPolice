using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToys : MonoBehaviour
{
    private float scaleNormal;
    private Vector3 startPos;
    bool isbeingHeld = false;
    private Vector3 offset;
    [SerializeField] float minDist;
    [SerializeField] RectTransform truePos;


    public delegate void TrueDrag(int id);
    public static event TrueDrag trueDragToy;
    public delegate void StartDrag();
    public static event StartDrag startDrag;
    public delegate void EndDrag();
    public static event EndDrag endDrag;

    private int idToy;
    private void Start()
    {
        scaleNormal = transform.localScale.x;
    }

    private void Update()
    {
        if (isbeingHeld)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    public void SetId(int valueId)
    {
        idToy = valueId;
    }

    public int GetId()
    {
        return idToy;
    }

    public void SetStartPos()
    {
        startPos = transform.position;
    }

    private void OnMouseDown()
    {
        startDrag?.Invoke();
        StopCoroutine(nameof(StartHint));
        isbeingHeld = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.localScale = new Vector3(scaleNormal * 1.2f, scaleNormal * 1.2f, scaleNormal * 1.2f);
        transform.SetAsLastSibling();
    }

    public void OnMouseUp()
    {
        endDrag?.Invoke();
        transform.localScale = new Vector3(scaleNormal, scaleNormal, scaleNormal);
        isbeingHeld = false;
        if (Vector2.Distance(transform.position, truePos.transform.position) <= minDist)
        {
            trueDragToy?.Invoke(idToy);
            GameScene31Manager.ins.UpdatePoint();
            Destroy(gameObject);
        }
        StartCoroutine(StartToMoveBack());
    }

    IEnumerator StartToMoveBack()
    {
        float elapsedTime = 0;
        float seconds = 0.25f;
        Vector3 startingPos = transform.position;
        while (elapsedTime < seconds)
        {
            transform.position = Vector3.Lerp(startingPos, startPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = startPos;

    }

    public void Hint()
    {
        StartCoroutine(nameof(StartHint));
    }

    IEnumerator StartHint()
    {
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
