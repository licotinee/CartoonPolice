using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsacle_Scene5_1 : MonoBehaviour
{
    Rigidbody2D rigid;
    [SerializeField] float speed;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StartDestroy());
        }
        if (collision.gameObject.CompareTag("LimitScene"))
        {
            DestroyObscale();
        }
    }

    IEnumerator StartDestroy()
    {
        yield return new WaitForSeconds(GameScene15Manager.ins.timeBeHitted);
        DestroyObscale();
    }

    private void DestroyObscale()
    {
        GameScene15Manager.ins.cntDestroyObsacle++;
        Destroy(gameObject);
    }
}
