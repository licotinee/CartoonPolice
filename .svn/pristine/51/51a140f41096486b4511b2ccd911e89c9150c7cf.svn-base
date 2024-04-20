using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Police_Scene2_1 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation wolfoo;
    [SerializeField] SkeletonAnimation kat;

    private void Start()
    {
        wolfoo.AnimationState.SetAnimation(0, "Idle", true);
        kat.AnimationState.SetAnimation(0, "Idle", true);
    }

    public void Move(float seconds)
    {
        StartCoroutine(StartMove(seconds));
    }
    IEnumerator StartMove(float seconds)
    {
        transform.position = new Vector3(GameScenePoliceCarManager.ins.car.transform.position.x + 2f, transform.position.y, transform.position.z);

        wolfoo.AnimationState.SetAnimation(0, "Run_Ninja2", true);
        kat.AnimationState.SetAnimation(0, "Run_Ninja2", true);
        float elapsedTime = 0;
        Vector3 startingPos = transform.position;
        Vector3 endPosition = new Vector3(GameScenePoliceCarManager.ins.endPosition.position.x + 1.5f, transform.position.y, transform.position.z);
        while (elapsedTime <= seconds)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startingPos, endPosition, (elapsedTime / seconds)); ;
            yield return new WaitForEndOfFrame();
        }
        transform.position = endPosition;
        wolfoo.AnimationState.SetAnimation(0, "Idle_Talk", true);
        kat.AnimationState.SetAnimation(0, "Idle_Talk", true);
        GameScenePoliceCarManager.ins.shopKeeper.Idle_Talk();
    }



}
