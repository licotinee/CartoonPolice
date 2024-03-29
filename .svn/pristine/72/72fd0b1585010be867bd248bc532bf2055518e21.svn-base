using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class Kid_Scene3_3 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    [SerializeField] Transform endPos;
    Vector3 end;
    private void Start()
    {
        end = endPos.position;

        transform.position = new Vector3(-Camera.main.orthographicSize * Camera.main.aspect - 2f, transform.position.y, transform.position.z);
        StartCoroutine(StartMoveToEndPos());
    }

    IEnumerator StartMoveToEndPos()
    {
        float eslapsed = 0;
        float seconds = 1f;
        Vector3 start = transform.position;
        skeleton.AnimationState.SetAnimation(0, "Run_c", true);
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        skeleton.AnimationState.SetAnimation(0, "Crying_hug", true);
        GameScene33Manager.ins.momKid.HugeTheKid();
        GameScene33Manager.ins.EndScene();
    }

}
