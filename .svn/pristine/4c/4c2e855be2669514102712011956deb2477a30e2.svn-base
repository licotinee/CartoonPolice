using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid_Scene0_3 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    [SerializeField] Transform endPos;
    private bool isMoving;
    private void Start()
    {
        skeleton.AnimationState.SetAnimation(0, "Crying", true);
        
    }

    private void OnEnable()
    {
        Door.completeOpenDoor += MoveToEndPos;
    }

    private void OnDestroy()
    {
        Door.completeOpenDoor -= MoveToEndPos;

    }

    private void MoveToEndPos()
    {
        if(!isMoving)
            StartCoroutine(StartMoveToEndPos());
    }

    IEnumerator StartMoveToEndPos()
    {
        skeleton.AnimationState.SetAnimation(0, "Walk_Crying", true);
        skeleton.GetComponent<MeshRenderer>().sortingOrder = 4;
        isMoving = true;
        Vector3 start = transform.position;
        Vector3 end = endPos.position;
        float eslapsed = 0;
        float seconds = 2f;
        while(eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        skeleton.AnimationState.SetAnimation(0, "Crying", true);
        yield return new WaitForSeconds(1f);
        GameScene30Manager.ins.CompleteScene1();
    }
}
