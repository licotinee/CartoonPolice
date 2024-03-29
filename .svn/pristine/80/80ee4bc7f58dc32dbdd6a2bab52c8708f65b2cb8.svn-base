using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police_Scene1_5 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;

    private void OnEnable()
    {
        StartCoroutine(StartMoveOutSideScreen());
    }

    IEnumerator StartMoveOutSideScreen()
    {
        float eslapsed = 0;
        float seconds = 2f;
        Vector3 start = transform.position;
        Vector3 end = new Vector3(Camera.main.orthographicSize * Camera.main.aspect + 3f, transform.position.y, transform.position.z);
        skeleton.AnimationState.SetAnimation(0, "Run_c", true);
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        Destroy(gameObject);
    }
}
