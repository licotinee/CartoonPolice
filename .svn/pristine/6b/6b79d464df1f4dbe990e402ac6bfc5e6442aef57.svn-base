using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towel : MonoBehaviour
{
    bool isbeingHeld;
    private Vector3 offset;
    Vector3 startPos;
    private bool isEnd;
    [SerializeField] float minDist;


    IEnumerator MoveToStartPos()
    {
        Vector3 start = new Vector3(Camera.main.orthographicSize * Camera.main.aspect + 3f, transform.position.y, transform.position.z);
        Vector3 end = new Vector3(Camera.main.orthographicSize * Camera.main.aspect - 2f, transform.position.y, transform.position.z);
        float eslapsed = 0;
        float seconds = 0.5f;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        startPos = transform.position;
    }

    private void OnEnable()
    {
        CarWash.eCompleteCleanWater += EndTowel;
        StartCoroutine(MoveToStartPos());
    }

    private void OnDestroy()
    {
        CarWash.eCompleteCleanWater -= EndTowel;
    }

    private void Update()
    {
        if (isbeingHeld && ToolManager.ins.isStartTurn)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            CleanWater();
        }
        
    }
    private void OnMouseDown()
    {
        isbeingHeld = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        isbeingHeld = false;
        if (!isEnd)
        {
            StartCoroutine(StartToMoveBack());
        }
    }   

    void CleanWater()
    {
        if (Vector2.Distance(transform.position, GameScene51Manager.ins.car.transform.position) < minDist && !isEnd)
        {
            GameScene51Manager.ins.car.ClearWaterSprite();
        }
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

    private void EndTowel()
    {
        isEnd = true;
        GetComponent<CapsuleCollider2D>().enabled = false;
        isbeingHeld = false;
        StartCoroutine(StartMoveToOutSideScreen());
    }

    IEnumerator StartMoveToOutSideScreen()
    {
        float eslapsed = 0;
        float seconds = 0.5f;
        Vector3 start = transform.position;
        Vector3 end = new Vector3(Camera.main.orthographicSize * Camera.main.aspect + 3f, transform.position.y, transform.position.z);
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        Destroy(gameObject);
    }
}
