using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police_Scene0_3 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation wolfoo;
    [SerializeField] SkeletonAnimation kat;

    [SerializeField] Transform endPos;
    Vector3 end;
    
    private void Awake()
    {
        end = endPos.position;

        transform.position = new Vector3(Camera.main.orthographicSize * Camera.main.aspect + 2f, transform.position.y, transform.position.z);
    }

    public void MoveToEndPos()
    {
        StartCoroutine(StartMoveToEndPos());
    }

    IEnumerator StartMoveToEndPos()
    {
        float eslapsed = 0;
        float seconds = 1f;
        Vector3 start = transform.position;
        wolfoo.AnimationState.SetAnimation(0, "Run_c", true);
        kat.AnimationState.SetAnimation(0, "Run_c", true);
        while(eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        wolfoo.AnimationState.SetAnimation(0, "Idle_Talk", true);
        kat.AnimationState.SetAnimation(0, "Idle_Talk", true);
        GameScene30Manager.ins.EndScene();
    }
}
