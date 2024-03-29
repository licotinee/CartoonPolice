using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Scene5_1 : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    [SerializeField] float speed;
    [SerializeField] GameObject otherRoad;
    float size;
    
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        size = sprite.bounds.size.x/2;
    }

    private void FixedUpdate()
    {
        Move();
        CheckLoop();
    }

    private void Move()
    {
        if (!GameScene15Manager.ins.isWolfooBeHitted && !GameScene15Manager.ins.isStopRoad)
        {
            rigid.velocity = new Vector2(-speed * Time.deltaTime, 0);
        }
        else
        {
            rigid.velocity = Vector2.zero;
        }
    }
    private void CheckLoop()
    {
        if (transform.position.x + size <= Camera.main.transform.position.x - Camera.main.orthographicSize  * Camera.main.aspect)
        {
            transform.position = otherRoad.transform.position + new Vector3(2 * size - 0.05f, 0, 0);
        }
    }
}
 