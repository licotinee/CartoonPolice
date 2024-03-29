using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class WolfooMinigame7 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;

    public void SetAnimationState(string Anim, bool loop)
    {
        skeleton.AnimationState.SetAnimation(0, Anim, loop);
    }
    public void Reset()
    {
        skeleton.AnimationState.ClearTracks();
        skeleton.Skeleton.SetToSetupPose();
    }
}
