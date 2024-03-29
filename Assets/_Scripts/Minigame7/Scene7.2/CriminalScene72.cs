using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriminalScene72 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    [SerializeField] Transform posSpawn;

    [SerializeField] BannedItem item;

    private void Start()
    {
        skeleton.AnimationState.SetAnimation(0, "Run_c2", true);
        skeleton.AnimationState.SetAnimation(1, "Idle", true);
        StartCoroutine(nameof(StartSpawn));
    }

    IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            Instantiate(item, posSpawn.transform.position, Quaternion.identity);
            skeleton.AnimationState.SetAnimation(1, "Angry", false).Complete += CriminalScene72_Complete;
            yield return new WaitForSeconds(1.0f * item.seconds / GameScene72Manager.ins.scaleSpeed);
        }
    }

    private void CriminalScene72_Complete(Spine.TrackEntry trackEntry)
    {
        skeleton.AnimationState.SetAnimation(1, "Idle", false);
    }

    public void StopSpawn()
    {
        StopCoroutine(nameof(StartSpawn));
    }

    public void BeAttacked()
    {
        skeleton.AnimationState.SetAnimation(0, "Kneel", true);
        skeleton.AnimationState.SetAnimation(1, "Scare", true);
    }

    public void Reset()
    {
        StartCoroutine(nameof(StartSpawn));
    }

    public void SetAnimRun()
    {
        skeleton.AnimationState.SetAnimation(0, "Run_c2", true);
        skeleton.AnimationState.SetAnimation(1, "Idle", true);
    }

    public void EndScene()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        skeleton.AnimationState.SetAnimation(0, "Kneel", true);
        skeleton.AnimationState.SetAnimation(1, "Scare", true);
    }
}
