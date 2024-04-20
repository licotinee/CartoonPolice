using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;

public class Light_SceneMenu : MonoBehaviour
{
    [SerializeField] Image lightSprite;
    [SerializeField] SkeletonGraphic skeleton;

    private void OnEnable()
    {
        UIMenuManager.buttonCliked += TurnOnLight;
    }

    private void OnDestroy()
    {
        UIMenuManager.buttonCliked -= TurnOnLight;
    }

    private void TurnOnLight()
    {
        lightSprite.gameObject.SetActive(false);
        skeleton.gameObject.SetActive(true);
        skeleton.AnimationState.SetAnimation(0, "Idle", true);
    }
}
