using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScene72 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;

    [SerializeField] float distMove;
    public Vector3 startPos;
    Vector3 endPos;
    private void Start()
    {
        skeleton.AnimationState.SetAnimation(0, "Run", true);
        skeleton.AnimationState.SetAnimation(1, "Idle", true);
        startPos = transform.position;
        endPos = startPos + new Vector3(distMove, 0, 0);

        StartCoroutine(nameof(StartMove));
    }

    IEnumerator StartMove()
    {
        transform.position = startPos;

        while (true)
        {
            float eslapsed = 0;
            float seconds = 1.5f;

            while (eslapsed <= seconds)
            {
                eslapsed += Time.deltaTime;
                transform.position = Vector3.Lerp(startPos, endPos, eslapsed / seconds);
                yield return new WaitForEndOfFrame();
            }
            transform.position = endPos;

            eslapsed = 0;
            while (eslapsed <= seconds)
            {
                eslapsed += Time.deltaTime;
                transform.position = Vector3.Lerp(endPos, startPos, eslapsed / seconds);
                yield return new WaitForEndOfFrame();
            }
            transform.position = startPos;
        }
        
    }

    public void BeHitted()
    {
        skeleton.AnimationState.SetAnimation(1, "Sad", true).Complete += DogScene72_Complete; ;
    }

    private void DogScene72_Complete(Spine.TrackEntry trackEntry)
    {
        skeleton.AnimationState.SetAnimation(1, "Idle", true);
    }

    public void StopMove()
    {
        StopCoroutine(nameof(StartMove));
    }

    public void Attack()
    {
        skeleton.AnimationState.SetAnimation(0, "Sit", true);
        skeleton.AnimationState.SetAnimation(1, "Bark", true);
    }

    public void Reset()
    {
        StartCoroutine(nameof(StartMove));
    }

    public void SetAnimRun()
    {
        skeleton.AnimationState.SetAnimation(0, "Run", true);
        skeleton.AnimationState.SetAnimation(1, "Idle", true);
    }

    public void EndScene()
    {
        skeleton.AnimationState.SetAnimation(0, "Sit", true);
        skeleton.AnimationState.SetAnimation(1, "Bark", true);
    }
}
