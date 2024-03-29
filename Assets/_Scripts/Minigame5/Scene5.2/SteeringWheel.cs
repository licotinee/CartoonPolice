using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : MonoBehaviour
{
    [SerializeField] Camera cam;
    bool isClicked;
    private bool isEnd;
    Vector3 startMouse;
    Vector3 endMouse;
    [SerializeField] float maxDist;
    [SerializeField] float speed;
    [SerializeField] float speedRotate;
    [SerializeField] float MaxRotate;
    public delegate void EGetGoalPos();
    public static event EGetGoalPos eGetGoalPos;
    private void Update()
    {
        RotateSteering();
    }

    private void RotateSteering()
    {
        if (isClicked && !isEnd)
        {
            endMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float directX = (startMouse == Vector3.zero ? 0 : endMouse.x - startMouse.x);
            if (directX < 0)
            {
                if (cam.transform.position.x >= -maxDist)
                {
                    cam.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                }

                if (Mathf.Abs(transform.eulerAngles.z - Vector2.Angle(endMouse - transform.position, Vector2.up)) >= 2f)
                {
                    if (transform.eulerAngles.z <= MaxRotate || (transform.eulerAngles.z >= (360 - MaxRotate) && (transform.eulerAngles.z <= 360)))
                    {
                        transform.eulerAngles += new Vector3(0, 0, speedRotate * Time.deltaTime);
                    }
                }

            }
            if (directX > 0)
            {
                if (cam.transform.position.x <= maxDist)
                {
                    cam.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                }

                if (Mathf.Abs(transform.eulerAngles.z + Vector2.Angle(endMouse - transform.position, Vector2.up)) >= 2f)
                {
                    if ((transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= MaxRotate) || 
                        (transform.eulerAngles.z <= 360 && transform.eulerAngles.z >= (360 - MaxRotate)))
                    {
                        transform.eulerAngles -= new Vector3(0, 0, speedRotate * Time.deltaTime);
                    }
                }
            }
            if (transform.eulerAngles.z >= 180 && transform.eulerAngles.z < (360 - MaxRotate))
            {
                transform.eulerAngles = new Vector3(0, 0, 360 - MaxRotate + 0.05f);
            }else if (transform.eulerAngles.z <= 180 && transform.eulerAngles.z > MaxRotate)
            {
                transform.eulerAngles = new Vector3(0, 0, MaxRotate - 0.05f);
            }
            startMouse = endMouse;
        }
    }

    private void OnMouseDown()
    {
        isClicked = true;
        StopCoroutine(nameof(BackSteering));
    }

    IEnumerator BackSteering()
    {
        while (Math.Abs(transform.eulerAngles.z) >= 1.5f)
        {
            if (transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= MaxRotate)
            {
                transform.eulerAngles -= new Vector3(0 ,0, speedRotate * Time.deltaTime * 2);
            }else if (transform.eulerAngles.z <= 360 && transform.eulerAngles.z >= (360 - MaxRotate))
            {
                transform.eulerAngles += new Vector3(0, 0, speedRotate * Time.deltaTime * 2);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnMouseUp()
    {
        isClicked = false;
        startMouse = endMouse = Vector3.zero;
        StopCoroutine(nameof(BackSteering));
        StartCoroutine(nameof(BackSteering));
    }

    public void EndScene()
    {
        StartCoroutine(StartEndScene());
    }

    IEnumerator StartEndScene()
    {
        isEnd = true;
        float eslapsed = 0;
        float seconds = 2f;
        Vector3 startPos = cam.transform.position;
        Vector3 endPos = new Vector3(maxDist, cam.transform.position.y, cam.transform.position.z);
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            cam.transform.position = Vector3.Lerp(startPos, endPos, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        cam.transform.position = endPos;
        eGetGoalPos?.Invoke();
    }
}
