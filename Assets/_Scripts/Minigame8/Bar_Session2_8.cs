using DG.Tweening;
using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar_Session2_8 : MonoBehaviour
{
    [SerializeField] Vector3 startPos;

    public void Awake()
    {
        startPos = transform.position;
        transform.position = new Vector3(transform.position.x - 7f, transform.position.y, transform.position.z);
        //MoveLeft(0);
    }
    public void MoveRight(float seconds)
    {
        StartCoroutine(StartMoveRight(seconds));
        //transform.DOMoveX(startPos.x, seconds);
    }

    IEnumerator StartMoveRight(float seconds)
    {
        Vector3 start = transform.position;
        Vector3 end = start + new Vector3(7f, 0, 0);

        transform.position = start;

        float eslapsed = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        Debug.Log(transform.position);

    }

    public void MoveLeft(float seconds)
    {
        StartCoroutine(StartMoveLeft(seconds));
        //transform.DOMoveX(startPos.x - 7, seconds);
    }

    IEnumerator StartMoveLeft(float seconds)
    {
        Vector3 start = transform.position;
        Vector3 end = start - new Vector3(7f, 0, 0);

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

}
