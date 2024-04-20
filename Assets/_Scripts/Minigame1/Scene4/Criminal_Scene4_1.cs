using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Criminal_Scene4_1 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;

    private void Start()
    {
        skeleton.AnimationState.SetAnimation(0, "Angry", true);
        SoundManager.Instance.PlaySFXOneShot(SoundTag.Eff_witch_growl);
    }

    public void Scare()
    {
        skeleton.AnimationState.SetAnimation(0, "Scare", true);
        SoundManager.Instance.PlaySFXOneShot(SoundTag.Eff_witch_surprise);
    }

}
