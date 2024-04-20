using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPrison : MonoBehaviour
{
    private Vector3 start;
    private Vector3 end;
    [SerializeField] Transform endPos;
    private bool isCloseDoor;
    
    [SerializeField] float timeDelayHint;
    [SerializeField] GameObject rattle;
    private bool isCanClick;

    public delegate void ECompleteCloseDoor();
    public static event ECompleteCloseDoor completeCloseDoor;

    private void OnEnable()
    {
        Criminal_ScenePrison.innerPrison += Play;
    }

    private void OnDestroy()
    {
        Criminal_ScenePrison.innerPrison -= Play;
    }

    private void Play()
    {
        isCanClick = true;
        StartCoroutine(nameof(StartHint));
    }

    private void OnMouseDrag()
    {
        if (isCanClick)
        {
            end = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (start != Vector3.zero)
            {
                if (end.x - start.x < 0)
                {
                    if (!isCloseDoor)
                    {
                        StartCoroutine(StartCloseDoor());
                    }
                }
            }
            start = end;
        }
    }

    private void OnMouseUp()
    {
        start = Vector3.zero;
    }

    IEnumerator StartCloseDoor()
    {
        StopCoroutine(nameof(StartHint));
        isCloseDoor = true;
        float eslapsed = 0;
        float seconds = 0.5f;
        Vector3 start = transform.position;
        Vector3 end = endPos.position;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        rattle.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        completeCloseDoor?.Invoke();
        GameScenePrisionManager.ins.ActiveEndScene();
    }

    IEnumerator StartHint()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeDelayHint);
            float eslapsed = 0;
            float seconds = 0.5f;
            Vector3 start = transform.position;
            Vector3 end = start - new Vector3(1f, 0, 0);
            while (eslapsed <= seconds)
            {
                eslapsed += Time.deltaTime;
                transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
                yield return new WaitForEndOfFrame();
            }
            transform.position = end;

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
}
