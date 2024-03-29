using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cano : MonoBehaviour
{
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    [SerializeField] float timeMove;
    [SerializeField] float timeDelay;

    private void Start()
    {
        Move();
    }
    private void Move()
    {
        StartCoroutine(nameof(StartMove));
    }

    IEnumerator StartMove()
    {
        float eslapsed;
        float seconds = timeMove;

        while (true)
        {
            transform.position = startPos.position;
            eslapsed = 0;
            while(eslapsed <= seconds)
            {
                eslapsed += Time.deltaTime;
                transform.position = Vector3.Lerp(startPos.position, endPos.position, eslapsed/seconds);
                yield return new WaitForEndOfFrame();
            }
            transform.position = endPos.position;
            yield return new WaitForSeconds(timeDelay);
        }
    }
}
