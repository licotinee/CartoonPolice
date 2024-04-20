using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;

public class Screen_SceneCall : MonoBehaviour
{
    [SerializeField] Image imageMap;
    [SerializeField] GameObject lightNormal;
    [SerializeField] SkeletonGraphic lightAnim;
    public void TurnOnTheLight()
    {
        imageMap.gameObject.SetActive(true);

        lightNormal.SetActive(false);
        lightAnim.gameObject.SetActive(true);
        lightAnim.AnimationState.SetAnimation(0, "Idle", true);
        GameSceneCallPoliceManager.ins.EndScene();
    }

}

