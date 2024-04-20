using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSet : MonoBehaviour
{
    [SerializeField] float speed;
    int isCurBg = 0;
    [SerializeField] Image posCam1;
    [SerializeField] Image posCam2;
    [SerializeField] Image posCam3;


    public delegate void CamMove();
    public static event CamMove startCamMove;
    public static event CamMove endCamMove;


    private void Start()
    {
        IntroduceScene();
    }

    public void UpdateCameraPos(int curCol)
    {
        if (curCol == 9 && isCurBg == 0)
        {
            isCurBg += 1;
            Vector3 newPos = new Vector3(posCam1.transform.position.x, transform.position.y, transform.position.z);
            StartCoroutine(MoveCam(newPos));
        }
        else if (curCol == 19 && isCurBg == 1)
        {
            isCurBg += 1;
            Vector3 newPos = new Vector3(posCam2.transform.position.x, transform.position.y, transform.position.z);
            StartCoroutine(MoveCam(newPos));
        }
        else if (curCol == 25 && isCurBg == 2)
        {
            isCurBg += 1;
            Vector3 newPos = new Vector3(posCam3.transform.position.x, transform.position.y, transform.position.z);
            StartCoroutine(MoveCam(newPos));
        }

    }

    IEnumerator MoveCam(Vector3 newPos)
    {
        startCamMove?.Invoke();
        Vector3 startingPos = transform.position;
        float eslapsed = 0;
        float second = 0.5f;
        GameScene32Manager.ins.isMovingCam = true;
        while (eslapsed <= second)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(startingPos, newPos, eslapsed/second);
            yield return new WaitForEndOfFrame();
        }
        transform.position = newPos;
        endCamMove?.Invoke();
        GameScene32Manager.ins.isMovingCam = false;

    }

    private void IntroduceScene()
    {
        StartCoroutine(StartIntroduceScene());
    }

    IEnumerator StartIntroduceScene()
    {
        GameScene32Manager.ins.isMovingCam = true;
        yield return new WaitForSeconds(1f);
        startCamMove?.Invoke();
        float eslapsed = 0;
        float seconds = 3f;
        Vector3 start = transform.position;
        Vector3 end = posCam3.transform.position;

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed/seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;

        endCamMove?.Invoke();
        yield return new WaitForSeconds(2f);

        startCamMove?.Invoke();     
        eslapsed = 0;

        end = start;
        start = transform.position;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        GameScene32Manager.ins.isMovingCam = false;
        
        endCamMove?.Invoke();

        // Start Game
        Map.ins.StartGame();
    }
}

