using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class MomKid : MonoBehaviour
{
    [SerializeField] List<SkeletonAnimation> ListSkeletons;
    SkeletonAnimation skeleton;


    private void Awake()
    {
        LoadLevel();
    }

    private void LoadLevel()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int curLevel = LevelManager.ins.GetLevel(curMinigame);
        skeleton = ListSkeletons[curLevel % ListSkeletons.Count];
        ListSkeletons[curLevel % ListSkeletons.Count].gameObject.SetActive(true);
    }
    private void Start()
    {
        skeleton.AnimationState.SetAnimation(0, "Idle", true);
    }

    public void HugeTheKid()
    {
        skeleton.AnimationState.SetAnimation(0, "Kneel", true);
    }
}
