using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Scene5_1 : MonoBehaviour
{
    [SerializeField] GameObject limitScene;
    float startSize;
    Camera cam;
    private void Awake()
    {
        cam = Camera.main;
        startSize = cam.orthographicSize;
        limitScene.transform.position = new Vector3(Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - 3f, limitScene.transform.position.y, limitScene.transform.position.z);
    }

    public void ScaleUp(float seconds)
    {
        StartCoroutine(StartScaleUp(seconds));
    }

    IEnumerator StartScaleUp(float seconds)
    {
        float start = startSize;
        float end = 0.9f * startSize;

        float eslased = 0;
        while (eslased <= seconds)
        {
            eslased += Time.deltaTime;
            cam.orthographicSize = start + (end - start) * eslased / seconds;
            yield return new WaitForEndOfFrame();
        }
        cam.orthographicSize = end;
    }
}
