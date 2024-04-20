using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackGround_Scene3_4 : MonoBehaviour
{
    [SerializeField] List<GameObject> ListBg;
    private float length;
    private float limitPos;
    Camera cam;
    private void Start()
    {
        cam = Camera.main;
        length = ListBg[0].GetComponent<SpriteRenderer>().size.x;
    }
    private void Update()
    {
        limitPos = cam.transform.position.x - cam.orthographicSize * cam.aspect - 1.5f;
        for (int i = 0; i < ListBg.Count; ++i)
        {
            if (ListBg[i].transform.position.x + length / 2 < limitPos)
            {
                ListBg[i].transform.position = ListBg[(i - 1 + ListBg.Count) % ListBg.Count].transform.position + new Vector3(length - 0.1f, 0, 0);
            }
        }
    }
}
