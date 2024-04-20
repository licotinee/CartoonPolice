using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSation : MonoBehaviour
{
    [SerializeField] Transform endPos;

    private void OnEnable()
    {
        StartCoroutine(MoveToEndPos());
    }

    IEnumerator MoveToEndPos()
    {
        Vector3 startPos = transform.position;
        Vector3 maxScale = transform.localScale;
        float eslapsed = 0;
        float maxDist = Vector2.Distance(endPos.position, startPos);
        float curDist;
        float seconds = 2f;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector2.Lerp(startPos, endPos.position, eslapsed / seconds);
            curDist = Vector2.Distance(endPos.position, transform.position);
            transform.localScale = new Vector2((1 - curDist / maxDist) * maxScale.x, (1 - curDist / maxDist) * maxScale.y);
            yield return new WaitForEndOfFrame();
        }
        transform.position = endPos.position;
        transform.localScale = maxScale;
    }

}
