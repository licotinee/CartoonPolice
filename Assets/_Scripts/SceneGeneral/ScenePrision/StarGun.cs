using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGun : MonoBehaviour
{

    Vector3 startPos;
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        startPos = transform.position;
        transform.position = new Vector3(transform.position.x, -Camera.main.orthographicSize - 3f, transform.position.z);
        StartCoroutine(MoveToStartPos());
    }

    IEnumerator MoveToStartPos()
    {
        float eslapsed = 0;
        float seconds = 0.5f;
        Vector3 start = transform.position;
        Vector3 end = startPos;
        while(eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        animator.Play("StarGun");
    }

}
