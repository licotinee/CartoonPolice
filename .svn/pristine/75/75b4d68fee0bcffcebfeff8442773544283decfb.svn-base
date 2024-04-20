using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class DragSprite : MonoBehaviour
{
    bool isCorrectDrag;
    protected Vector3 scaleNormal;
    [SerializeField] protected List<GameObject> ListTrueObjects;
    protected GameObject firstTrueObject;
    public Vector3 startPos;
    bool isbeingHeld = false;
    private Vector3 offset;
    [SerializeField] float minDist;
    public bool isCanDrag;

    private void Update()
    {
        if (isbeingHeld && !isCorrectDrag)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            ChangeScale();
        }
    }

    public virtual void ChangeScale() { }

    private void OnMouseDown()
    {
        if (isCanDrag)
        {
            if (!isCorrectDrag)
            {
                DoSthingWhenOnMouseDown();
            }
        }
        
    }

    public virtual void DoSthingWhenOnMouseDown()
    {
        isbeingHeld = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.localScale = ListTrueObjects[0].transform.localScale;

    }

    public void OnMouseUp()
    {
        if (isCanDrag)
        {
            isbeingHeld = false;
            if (!isCorrectDrag)
            {
                DoSthingWhenOnMouseUp();
            }
        }
  
    }

    public virtual void DoSthingWhenOnMouseUp()
    {
        
        foreach (GameObject ob in ListTrueObjects)
        {
            if (ThoaManDistance(gameObject, ob))
            {
                firstTrueObject = ob;
                CorrectDrag();
                break;
            }
        }
        if (!isCorrectDrag) StartCoroutine(StartToMoveBack());
    }

    bool ThoaManDistance(GameObject ob1, GameObject ob2)
    {
        if (ob2 != null)
        {
            if (Mathf.Sqrt((ob1.transform.position.x - ob2.transform.position.x) * (ob1.transform.position.x - ob2.transform.position.x) +
             (ob1.transform.position.y - ob2.transform.position.y) * (ob1.transform.position.y - ob2.transform.position.y)) < minDist)
            {
                return true;
            }
        }
        return false;
    }


    public virtual void CorrectDrag()
    {
        isCorrectDrag = true;
        transform.position = firstTrueObject.transform.position;
    }

    IEnumerator StartToMoveBack()
    {
        transform.localScale = scaleNormal;
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


}
