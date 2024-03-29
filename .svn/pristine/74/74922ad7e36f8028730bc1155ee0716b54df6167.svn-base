using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxChat : MonoBehaviour
{
    SkeletonGraphic skeleton;

    private void Awake()
    {
        skeleton = GetComponent<SkeletonGraphic>();
    }

    private void OnEnable()
    {
        skeleton.AnimationState.SetAnimation(0, "Start", false).Complete += BoxChat_Complete;
    }

    private void BoxChat_Complete(Spine.TrackEntry trackEntry)
    {
        skeleton.AnimationState.SetAnimation(0, "animation", true);
    }
}
