using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;
using Spine;

public class LostKid : MonoBehaviour
{
    [SerializeField] public SkeletonGraphic skeleton;
    [SerializeField] Image teddyBear;

    public delegate void KidPushHandOnButton();
    public static event KidPushHandOnButton kidPushHandOnButton;

    private void Start()
    {
        skeleton.AnimationState.SetAnimation(0, "Crying", true);
    }

    private void OnEnable()
    {
        DragToys.trueDragToy += SetAnimHappy;
        ButtonScan_Scene1_3.buttonScanClicked += ScanHandOnButton;
        UIManager_Scene1_3.completeScanning += CompleteScanning;
    }
    private void OnDestroy()
    {
        DragToys.trueDragToy -= SetAnimHappy;
        ButtonScan_Scene1_3.buttonScanClicked -= ScanHandOnButton;
        UIManager_Scene1_3.completeScanning -= CompleteScanning;

    }

    private void ScanHandOnButton()
    {
        skeleton.AnimationState.SetAnimation(0, "Idle_ScanHand", false).Complete += PushHandOnButton; 
    }

    private void PushHandOnButton(Spine.TrackEntry trackEntry)
    {
        kidPushHandOnButton?.Invoke();
    }

    private void SetAnimHappy(int idToy)
    {
        StopCoroutine(nameof(StartHappy));
        StartCoroutine(nameof(StartHappy), idToy);
    }

    IEnumerator StartHappy(int idToy)
    {
        teddyBear.gameObject.SetActive(false);

        if (idToy == 1)
        {
            skeleton.AnimationState.SetAnimation(0, "Waving hand", true);
            teddyBear.gameObject.SetActive(true);
        }else if (idToy == 2)
        {
            skeleton.AnimationState.SetAnimation(0, "Idle_AAAA", true);
            skeleton.AnimationState.SetAnimation(0, "Idle_Eat", true);
        }
        else if(idToy == 3)
        {
            skeleton.AnimationState.SetAnimation(0, "Drink", true);
        }
        yield return new WaitForSeconds(1.5f);
        teddyBear.gameObject.SetActive(false);

        if (GameScene31Manager.ins.GetPoint() < 3)
        {
            skeleton.AnimationState.SetAnimation(0, "Crying", true);
        }
        else
        {
            skeleton.AnimationState.SetAnimation(0, "Idle", true);
        }
    }

    public void StartQuetVanTay()
    {
        StopAllCoroutines();
        skeleton.AnimationState.SetAnimation(0, "Idle", true);
    }

    private void CompleteScanning()
    {
        skeleton.AnimationState.AddAnimation(0, "Jump", true, 0);
        skeleton.AnimationState.AddAnimation(0, "Jump_Cheer", true, 0.5f);
        skeleton.AnimationState.AddAnimation(0, "Jump_Win", true, 1f);
    }
}
