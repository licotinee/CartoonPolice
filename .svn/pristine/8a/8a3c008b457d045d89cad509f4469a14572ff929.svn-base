using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bag_SessionShirt_8 : MonoBehaviour
{
    [SerializeField] Image body;
    [SerializeField] public Light_Session_8 light;
    [SerializeField] GameObject shirt;
    [SerializeField] Bar_Session2_8 bar;
    [SerializeField] PrintInBar_SessionFoot_8 posInBar;
    public void MoveUp(float seconds)
    {
        StartCoroutine(StartMoveUp(seconds));
    }
    IEnumerator StartMoveUp(float seconds)
    {
        Vector3 end = transform.position;
        Vector3 start = transform.position - new Vector3(0, 10f, 0);

        transform.position = start;

        float eslapsed = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    }

    public void MoveToCenter(float seconds)
    {
        StartCoroutine(StartMoveToCenter(seconds));
    }
    IEnumerator StartMoveToCenter(float seconds)
    {
        Vector3 start = transform.position;
        Vector3 end = new Vector3(0, 0, transform.position.z);

        float eslapsed = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        light.gameObject.SetActive(true);
        light.transform.SetAsFirstSibling();

        bar.MoveRight(0.5f);

        yield return new WaitForSeconds(1.5f);
        StartCoroutine(MoveToBar());
    }

    IEnumerator MoveToBar()
    {
        transform.parent = bar.transform;
        transform.SetAsLastSibling();
        float eslapsed = 0;
        float seconds = 0.3f;
        Vector3 start = transform.position;
        Vector3 end = new Vector3(posInBar.transform.position.x, posInBar.transform.position.y, transform.position.z);
        float maxDist = Vector2.Distance(start, end);
        float curDist;
        Vector3 startScale = transform.localScale;
        float endScale = posInBar.GetComponent<RectTransform>().sizeDelta.x / GetComponent<RectTransform>().sizeDelta.x;

        light.gameObject.SetActive(false);

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            curDist = Vector2.Distance(transform.position, end);
            transform.localScale = startScale + new Vector3((1 - curDist / maxDist) * (endScale - startScale.x),
                (1 - curDist / maxDist) * (endScale - startScale.y), (1 - curDist / maxDist) * (endScale - startScale.z));
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        transform.localScale = Vector3.zero;
        posInBar.Complete();
        yield return new WaitForSeconds(0.5f);
        SessionManager_8.ins.GetCurListSession().GetComponent<Session2_8>().EndShirtSession();
    }
}
