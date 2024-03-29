using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class ShopKeeper : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    private void Start()
    {
        skeleton.AnimationState.SetAnimation(0, "Waving", true);
        GameScenePoliceCarManager.ins.shopKeeper = this;
    }

    public void Idle_Talk()
    {
        skeleton.AnimationState.SetAnimation(0, "Idle_Talk", true);
    }
}
