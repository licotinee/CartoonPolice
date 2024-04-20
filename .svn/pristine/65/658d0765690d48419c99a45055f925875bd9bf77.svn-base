using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Dog : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    
    public void SetAnimationState(string Anim, bool loop, int track = 0)
    {
        skeleton.AnimationState.SetAnimation(0, Anim, loop);
    }

    public void Reset()
    {
        skeleton.AnimationState.ClearTracks();
        skeleton.Skeleton.SetToSetupPose();
    }
}
