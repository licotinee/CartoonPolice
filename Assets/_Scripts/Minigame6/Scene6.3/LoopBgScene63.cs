using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoopBgScene63 : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] List<Image> BackGrounds;

    private float length;
    private float minPos;
    private void Start()
    {
        length = Mathf.Abs(BackGrounds[1].transform.position.x - BackGrounds[0].transform.position.x);
        minPos = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect;
    }
    private void Update()
    {
        for (int i = 0; i < BackGrounds.Count; ++i)
        {
            if (!GameScene63Manager.ins.isEndGame)
                BackGrounds[i].transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            if (BackGrounds[i].transform.position.x + length / 2 <= minPos)
            {
                BackGrounds[i].transform.position = BackGrounds[(i-1 + BackGrounds.Count) % BackGrounds.Count].transform.position + new Vector3(length - 0.5f, 0, 0);
            }
        }

    }
}
