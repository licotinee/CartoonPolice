using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class Police_SceneIntro : MonoBehaviour
{
    [SerializeField] SkeletonGraphic wolfoo; 
    [SerializeField] SkeletonGraphic kat;

    public delegate void ECompleteIntro();
    public static event ECompleteIntro completeIntro;

    private void Awake()
    {
        StartCoroutine(StartIntro());
    }

    private void OnEnable()
    {
        completeIntro += CanPlay;
        UIMenuManager.buttonCliked += Play;
    }

    private void OnDestroy()
    {
        completeIntro -= CanPlay;
        UIMenuManager.buttonCliked -= Play;
    }

    IEnumerator StartIntro()
    {
        wolfoo.AnimationState.SetAnimation(0, "Waving", true);
        kat.AnimationState.SetAnimation(0, "Waving", true);
        yield return new WaitForSeconds(1.5f);
        completeIntro?.Invoke();
    }

    private void CanPlay()
    {
        wolfoo.AnimationState.SetAnimation(0, "Idle", true);
        kat.AnimationState.SetAnimation(0, "Idle", true);
    }

    private void Play()
    {
        wolfoo.AnimationState.SetAnimation(0, "Attention", true);
        kat.AnimationState.SetAnimation(0, "Attention", true);
    }
}
