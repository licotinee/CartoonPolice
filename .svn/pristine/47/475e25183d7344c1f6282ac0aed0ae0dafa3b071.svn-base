using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police_Scene2_4 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    [SerializeField] float timeShooting;
    private void Start()
    {
        skeleton.AnimationState.SetAnimation(0, "Idle", true);
    }

    private void OnEnable()
    {
        CarEnemy_Scene2_4.carEnemyShooted += Shooting;
        GameScene42Manager.eEndGame += EndGame;
        GameScene42Manager.eChangeScene += ChangeScene;
    }

    private void OnDestroy()
    {
        CarEnemy_Scene2_4.carEnemyShooted -= Shooting;
        GameScene42Manager.eEndGame -= EndGame;
        GameScene42Manager.eChangeScene -= ChangeScene;

    }

    private void Shooting(bool isMoveFast)
    {
        StopCoroutine(nameof(StartShooting));
        StartCoroutine(nameof(StartShooting));
    }

    IEnumerator StartShooting()
    {
        skeleton.AnimationState.SetAnimation(0, "Shooting", true);
        yield return new WaitForSeconds(timeShooting);
        skeleton.AnimationState.SetAnimation(0, "Idle", true);
    }

    private void EndGame()
    {
        StartCoroutine(StartEndGame());
    }
    IEnumerator StartEndGame()
    {
        yield return new WaitForSeconds(0.5f);
        StopCoroutine(nameof(StartShooting));
        skeleton.AnimationState.AddAnimation(0, "Yay_yay", true, 1f);
        skeleton.AnimationState.AddAnimation(0, "Jump_Hight", true, 1f);
        skeleton.AnimationState.AddAnimation(0, "Jump_Win", true, 1f);
    }
        
    private void ChangeScene()
    {
        skeleton.AnimationState.SetAnimation(0, "Surprise_Idle", true);
    }
}
