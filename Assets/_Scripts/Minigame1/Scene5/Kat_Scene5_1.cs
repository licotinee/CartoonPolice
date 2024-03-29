using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kat_Scene5_1 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    public void EndGame(float seconds)
    {
        StartCoroutine(StartEndGame(seconds));
    }

    IEnumerator StartEndGame(float seconds)
    {
        transform.position = new Vector3(Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect + 3f, transform.position.y, transform.position.z);
        skeleton.AnimationState.SetAnimation(0, "Run_Ninja2", true);

        float eslasped = 0;
        Vector3 start = transform.position;
        Vector3 end = new Vector3(Camera.main.transform.position.x + 2f, transform.position.y, transform.position.z);
        while (eslasped <= seconds)
        {
            eslasped += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslasped / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        skeleton.AnimationState.SetAnimation(0, "Cheer", true);

    }   
}
