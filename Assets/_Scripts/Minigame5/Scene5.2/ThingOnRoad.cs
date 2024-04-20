using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingOnRoad : MonoBehaviour
{

    [SerializeField] float speedOverScale;
    [SerializeField] float speedMove;
    Vector3 maxScale;
    Vector3 startScale;
    private void Awake()
    {
        maxScale = transform.localScale;
        startScale = new Vector3(maxScale.x / 10, maxScale.y / 10, maxScale.z / 10);
        transform.localScale = startScale;
    }
    private void OnEnable()
    {
        SteeringWheel.eGetGoalPos += End;
    }
    private void OnDestroy()
    {
        SteeringWheel.eGetGoalPos -= End;

    }
    IEnumerator MoveToEndSpawn(Transform startSpawn, Transform endSpawn, Transform posMaxScale)
    {
        float maxDist = startSpawn.position.y - posMaxScale.position.y;
        float curDist;
        while (transform.position != endSpawn.position)
        {
            float scale = GameScene52Manager.ins.scaleSpeed;
            // Move to endSpawn
            transform.position = Vector2.MoveTowards(transform.position, endSpawn.position, scale * speedMove * Time.deltaTime);
            
            // Tranform scale
            if (transform.position.y <= posMaxScale.transform.position.y)
            {
                transform.localScale = maxScale;
            }
            else
            {
                curDist = transform.position.y - posMaxScale.transform.position.y;
                float newScaleValue = startScale.x + (1 - curDist / maxDist) * (maxScale.x - startScale.x);
                transform.localScale = new Vector3(newScaleValue, newScaleValue);
            }
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }


    public void StartMove(Transform startSpawn, Transform endSpawn, Transform posMaxScale)
    {
        IEnumerator co = MoveToEndSpawn(startSpawn, endSpawn, posMaxScale);
        StartCoroutine(co);
    }

    private void End()
    {
        StopAllCoroutines();
    }
}
