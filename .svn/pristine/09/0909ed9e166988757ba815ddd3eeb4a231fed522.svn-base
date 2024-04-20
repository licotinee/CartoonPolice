using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police_Scene2_5 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;

    private void OnEnable()
    {
        SteeringWheel.eGetGoalPos += JumpWin;
        skeleton.AnimationState.SetAnimation(0, "Waving", true);
    }

    private void JumpWin()
    {
        skeleton.AnimationState.SetAnimation(0, "Jump_Win", true);
    }
}
