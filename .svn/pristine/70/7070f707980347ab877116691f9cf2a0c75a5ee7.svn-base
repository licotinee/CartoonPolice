using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class Wolf_Session_8 : MonoBehaviour
{
    [SerializeField] SkeletonGraphic skeleton;

    public void MoveUp(float seconds)
    {
        StartCoroutine(StartMoveUp(seconds));
    }

    IEnumerator StartMoveUp(float seconds)
    {
        Vector3 end = transform.position;
        Vector3 start = end - new Vector3(0, 7f, 0);

        transform.position = start;
        skeleton.AnimationState.SetAnimation(0, "Idle", true);

        float eslapsed = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        skeleton.AnimationState.SetAnimation(0, "Like", true);
    }

    public void MoveDown(float seconds)
    {
        StartCoroutine(StartMoveDown(seconds));
    }

    IEnumerator StartMoveDown(float seconds)
    {
        Vector3 start = transform.position;
        Vector3 end = start - new Vector3(0, 7f, 0);

        skeleton.AnimationState.SetAnimation(0, "Idle", true);

        float eslapsed = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        skeleton.AnimationState.SetAnimation(0, "Like", true);
    }

    public void MoveRight(float seconds)
    {
        StartCoroutine(StartMoveRight(seconds));
    }

    IEnumerator StartMoveRight(float seconds)
    {
        Vector3 end = transform.position;
        Vector3 start = end - new Vector3(10, 0f, 0);

        transform.position = start;
        skeleton.AnimationState.SetAnimation(0, "Run_c", true);

        float eslapsed = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        skeleton.AnimationState.SetAnimation(0, "Cheer", true);
    }
}
