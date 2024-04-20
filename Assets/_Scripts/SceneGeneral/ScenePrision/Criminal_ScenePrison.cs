using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class Criminal_ScenePrison : MonoBehaviour
{
    [SerializeField] List<SkeletonAnimation> listSkeletons;
    SkeletonAnimation skeleton;
    [SerializeField] Transform firstPos;
    [SerializeField] Transform secondPos;
    private Vector3 first;
    private Vector3 second;

    public delegate void EInnerPrison();
    public static event EInnerPrison innerPrison;

    private void Awake()
    {
        // set level
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int curLevel = LevelManager.ins.GetLevel(curMinigame);
        listSkeletons[curLevel % listSkeletons.Count].gameObject.SetActive(true);
        skeleton = listSkeletons[curLevel % listSkeletons.Count];

        if (curLevel == 6)
        {
            skeleton = listSkeletons[0];
        }

        first = firstPos.position;
        second = secondPos.position;
        transform.position = new Vector3(-Camera.main.orthographicSize * Camera.main.aspect - 2f, transform.position.y, transform.position.z);
        StartCoroutine(StartMoveToPrison());
    }

    private void OnEnable()
    {
        DoorPrison.completeCloseDoor += KneerScare;
    }

    private void OnDestroy()
    {
        DoorPrison.completeCloseDoor -= KneerScare;
    }


    IEnumerator StartMoveToPrison()
    {
        float eslapsed = 0;
        float seconds = 2f;
        Vector3 start, end;
        start = transform.position;
        end = first;

        skeleton.AnimationState.SetAnimation(0, "Walk_Prisoner", true);

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    
        eslapsed = 0;
        seconds = 0.75f;
        start = transform.position;
        end = second;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        skeleton.AnimationState.SetAnimation(0, "Idle_prison", true);
        innerPrison?.Invoke();
    }

    private void KneerScare()
    {
        skeleton.AnimationState.SetAnimation(0, "Kneel_Prisoner", true);
    }
}
