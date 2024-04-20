using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPolice_Scene3_5 : MonoBehaviour
{
    [SerializeField] GameObject wheel1;
    [SerializeField] GameObject wheel2;
    [SerializeField] Transform endTransform;
    private Vector3 endPos;
    
    private void Start()
    {
        endPos = endTransform.position;
        transform.position = new Vector3(-Camera.main.orthographicSize * Camera.main.aspect - 5f, transform.position.y, transform.position.z);
        StartCoroutine(StartMoveToEndPos());
    }

    IEnumerator StartMoveToEndPos()
    {
        float eslapsed = 0;
        float seconds = 2f;
        Vector3 start = transform.position;
        Vector3 end = endPos;
        float wheelRotateSpeed = 200f;
        while(eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed/seconds);
            wheel1.transform.eulerAngles -= new Vector3(0, 0, wheelRotateSpeed * Time.deltaTime);
            wheel2.transform.eulerAngles -= new Vector3(0, 0, wheelRotateSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        GameScene53Manager.ins.ActiveEndScene();
    }


}
