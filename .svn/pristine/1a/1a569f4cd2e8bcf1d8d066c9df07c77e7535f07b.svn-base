using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private bool isbeingHeld;
    private Vector3 offset;
    
    private void OnEnable()
    {
        StartCoroutine(MoveToStartPos());
    }

    IEnumerator MoveToStartPos()
    {
        Vector3 startPos = new Vector3(Camera.main.orthographicSize * Camera.main.aspect + 3f, transform.position.y, transform.position.z);
        Vector3 endPos = new Vector3(Camera.main.orthographicSize * Camera.main.aspect - 2f, transform.position.y, transform.position.z);
        float eslapsed = 0;
        float seconds = 0.5f;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, endPos, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = endPos;
    }

    private void Update()
    {
        if (isbeingHeld && ToolManager.ins.isStartTurn)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
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
    }
}
