using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Transform endDoor;

    private void Start()
    {
        StartCoroutine(StartOpenDoor());
    }

    public delegate void CompleteOpenDoor();
    public static event CompleteOpenDoor completeOpenDoor;

    IEnumerator StartOpenDoor()
    {
        
        float eslapsed = 0;
        float seconds = 0.5f;
        Vector3 start = transform.position;
        Vector3 end = endDoor.position;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        completeOpenDoor?.Invoke();
    }
}
