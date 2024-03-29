using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StolenThing : MonoBehaviour
{
    float scale;
    Rigidbody2D rigid;
    [SerializeField] float speed;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        scale = transform.localScale.x;
    }
    public void FixedUpdate()
    {
        if (!GameScene15Manager.ins.isWolfooBeHitted)
        {
            rigid.velocity = new Vector2(-speed * Time.deltaTime, 0);
        }
        else
        {
            rigid.velocity = Vector2.zero;
        }
    }
    public void Move(float endY)
    {
        StartCoroutine(StartMove(endY));
    }

    IEnumerator StartMove(float endY) 
    {
        float eslapsed = 0;
        float seconds = 0.5f;

        float startY = transform.position.y;
        float maxDist = Mathf.Abs(startY - endY);
        float curDist;


        float posY;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime; ;
            posY = startY + (endY - startY) * (eslapsed / seconds);
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);
            curDist = Mathf.Abs(posY - endY);
            transform.localScale = new Vector3(scale * (1 - curDist / maxDist), scale * (1 - curDist / maxDist), scale * (1 - curDist / maxDist));
            yield return new WaitForEndOfFrame();
        }
        transform.position = new Vector3(transform.position.x, endY, transform.position.z);
        transform.localScale = new Vector3(scale, scale, scale);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StartMoveToBarProgress());
        }

        if (collision.gameObject.CompareTag("LimitScene"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator StartMoveToBarProgress()
    {
        float scale = transform.localScale.x;
        float eslapsed = 0;
        float seconds = 0.25f;

        Vector3 posIcon = UIManager_Scene5_1.ins.barPanel.icon.transform.position;
        Vector3 start = transform.position;
        Vector3 end = new Vector3(posIcon.x, posIcon.y, transform.position.z);

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed/seconds);
            transform.localScale = new Vector3(scale * (1 - eslapsed/seconds), scale * (1 - eslapsed/seconds), scale * (1 - eslapsed / seconds));
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        transform.localScale = Vector3.zero;
        GameScene15Manager.ins.UpdatePoint();
        Destroy(gameObject);
    }
}
