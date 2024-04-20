using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using Spine;
public class Criminal_Prison_Scene26 : Singleton<Criminal_Prison_Scene26>
{
    [SerializeField] List<SkeletonAnimation> listSkeletons;
    [SerializeField] List<Transform> firstPos;
    [SerializeField] List<Transform> secondPos;


    public delegate void EInnerPrison();
    public static event EInnerPrison innerPrison;

    private void Awake()
    {
       base.Awake();
        
        transform.position = new Vector3(-Camera.main.orthographicSize * Camera.main.aspect - 2f, transform.position.y, transform.position.z);
        StartCoroutine(StartMoveToPrison());
    }

    //private void OnEnable()
    //{
    //    DoorPrison.completeCloseDoor += KneerScare;
    //}

    //private void OnDestroy()
    //{
    //    DoorPrison.completeCloseDoor -= KneerScare;
    //}


    IEnumerator StartMoveToPrison()
    {
        foreach( SkeletonAnimation s in listSkeletons)
        {
            s.AnimationState.SetAnimation(0, "Walk_Prisoner", true);

        }

     

        listSkeletons[0].gameObject.transform.DOMove(firstPos[0].position, 3f).OnComplete(() =>
        {
            listSkeletons[0].gameObject.transform.DOMove(secondPos[0].position, 2f).OnComplete(() =>
            {
                listSkeletons[0].AnimationState.SetAnimation(0, "Idle_prison", true);
            });
        });

        listSkeletons[1].gameObject.transform.DOMove(firstPos[1].position, 3.25f).OnComplete(() =>
        {
            listSkeletons[1].gameObject.transform.DOMove(secondPos[1].position, 2f).OnComplete(() =>
            {
                listSkeletons[1].AnimationState.SetAnimation(0, "Idle_prison", true);
            });
        });

        listSkeletons[2].gameObject.transform.DOMove(firstPos[2].position, 3.25f).OnComplete(() =>
        {
            listSkeletons[2].gameObject.transform.DOMove(secondPos[2].position, 2f).OnComplete(() =>
            {
                listSkeletons[2].AnimationState.SetAnimation(0, "Idle_prison", true);
                DoorPrison_Scene26.Instance.Play();
            });
        });

        //skeleton.AnimationState.SetAnimation(0, "Walk_Prisoner", true);

        //while (eslapsed <= seconds)
        //{
        //    eslapsed += Time.deltaTime;
        //    transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
        //    yield return new WaitForEndOfFrame();
        //}
        //transform.position = end;

        //eslapsed = 0;
        //seconds = 0.75f;
        //start = transform.position;

        //while (eslapsed <= seconds)
        //{
        //    eslapsed += Time.deltaTime;
        //    transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
        //    yield return new WaitForEndOfFrame();
        //}
        //transform.position = end;
        //skeleton.AnimationState.SetAnimation(0, "Idle_prison", true);
        
        yield return new WaitForSeconds(0.1f);
    }

    private void KneerScare()
    {
        //skeleton.AnimationState.SetAnimation(0, "Kneel_Prisoner", true);
        foreach (SkeletonAnimation s in listSkeletons)
        {
            s.AnimationState.SetAnimation(0, "Kneel_Prisoner", true);

        }
    }
}
