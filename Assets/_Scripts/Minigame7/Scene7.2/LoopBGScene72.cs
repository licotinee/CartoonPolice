using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBGScene72 : MonoBehaviour
{
    [SerializeField] List<GameObject> ListBg;
    [SerializeField] float speed;
    float length;
    float minPos;

    private void Start()
    {
        length = ListBg[0].GetComponent<SpriteRenderer>().size.x;
        minPos = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect;
    }
    private void Update()
    {
        if (!GameScene72Manager.ins.isDogAttacking)
        {
            for (int i = 0; i < ListBg.Count; ++i)
            {
                ListBg[i].transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                if (ListBg[i].transform.position.x + length / 2 < minPos)
                {
                    ListBg[i].transform.position = ListBg[(i - 1 + ListBg.Count) % ListBg.Count].transform.position + new Vector3(length - 0.05f, 0, 0);
                }
            }
        }

    }

}
