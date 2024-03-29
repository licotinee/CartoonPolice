using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Scene5_2 : MonoBehaviour
{
    [SerializeField] GameObject broken;
    public delegate void BulletBroken(GameObject ob);
    public static event BulletBroken bulletBroken;
    public void ShootIntoGoalPos(float timeMove, Vector3 goalPos, int isRight) {
        StartCoroutine(StartMove(timeMove, goalPos, isRight));
    }

    IEnumerator StartMove(float timeMove, Vector3 goalPos, int isRight)
    {
        float eslapsed = 0;
        float seconds = timeMove/2;
        Vector3 start = transform.position;
        Vector3 end = new Vector3(goalPos.x, goalPos.y, 0);
        Vector3 control = new Vector3((start.x + end.x) / 2, (start.y + end.y), 0) + new Vector3(isRight, 1) * 2 ;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = BezierCurve(start, control , end, eslapsed/seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        bulletBroken?.Invoke(gameObject);
        Instantiate(broken, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    Vector3 BezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        Vector3 newPos = (1 - t) * (1 - t) * p0 + 2 * (1 - t) * t * p1 + t * t * p2;
        return newPos;
    }
}
