using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Criminal_Scene6_8 : MonoBehaviour
{
    [SerializeField] private List<SkeletonAnimation> skeleton;
    [SerializeField] Transform posBoard;
    private int curLevelScene8;

    private void OnEnable()
    {
        curLevelScene8 = PlayerPrefs.GetInt("LevelScene8", 0) % 3;
        skeleton[curLevelScene8].gameObject.SetActive(true);
    }
    private void Start()
    {
        
        transform.position = new Vector3(-Camera.main.orthographicSize * Camera.main.aspect - 3f, transform.position.y, 0);
        StartCoroutine(MoveToBoard());
    }

    IEnumerator MoveToBoard()
    {
        float eslapsed = 0;
        float seconds = 2;
        Vector3 start = transform.position;
        Vector3 end = new Vector3(posBoard.position.x, transform.position.y, 0);

        skeleton[curLevelScene8].AnimationState.SetAnimation(0, "Run_c", true);
        skeleton[curLevelScene8].AnimationState.SetAnimation(1, "Angry", true);

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        skeleton[curLevelScene8].AnimationState.ClearTrack(0);
        skeleton[curLevelScene8].Skeleton.SetToSetupPose();

        GameScene86Manager.ins.isStartGame = true;
    }

    public void TurnLeft()
    {
        transform.eulerAngles += new Vector3(0, 180, 0);
    }

    public void Scare()
    {
        skeleton[curLevelScene8].AnimationState.SetAnimation(1, "Sad", true);
    }
}
