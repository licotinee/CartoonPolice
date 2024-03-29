using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicroScope_SessionFinger_8 : MonoBehaviour
{
    [SerializeField] Image blurFinger;
    [SerializeField] Image completeFinger;
    [SerializeField] PrintInBar_SessionFoot_8 posInBar;
    [SerializeField] Light_Session_8 light;
    [SerializeField] Bar_Session2_8 bar;
    public bool isComplete;
    public void ScaleUp(float seconds)
    {
        StartCoroutine(StartScaleUp(seconds));
    }
    IEnumerator StartScaleUp(float seconds)
    {
        float eslapsed = 0;
        float maxScale = transform.localScale.x;
        transform.localScale = Vector3.zero;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.localScale = new Vector3((eslapsed/seconds) * maxScale, (eslapsed/seconds) * maxScale, (eslapsed/ seconds) * maxScale);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(maxScale, maxScale, maxScale);
    }

    public void ScaleDown(float seconds)
    {
        StartCoroutine(StartScaleDown(seconds));
    }
    IEnumerator StartScaleDown(float seconds)
    {
        float eslapsed = 0;
        float maxScale = transform.localScale.x;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.localScale = new Vector3((1 - eslapsed / seconds) * maxScale, (1 - eslapsed / seconds) * maxScale, (1 - eslapsed / seconds) * maxScale);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = Vector3.zero;
    }


    public void UpdateFinger()
    {
        float speed = 1.7f;
        if (!isComplete)
        {
            if (completeFinger.color.a <= 1)
            {
                completeFinger.color += new Color(0, 0, 0, speed * Time.deltaTime);
            }
            else
            {
                isComplete = true;
                light.gameObject.SetActive(true);
                MoveToBar();
            }
        }
    }

    void MoveToBar()
    {
        StartCoroutine(StartMoveToBar());
    }


    IEnumerator StartMoveToBar()
    {
        yield return new WaitForSeconds(0.5f);
        bar.MoveRight(0.5f);

        yield return new WaitForSeconds(1f);

        
        completeFinger.transform.parent = bar.transform;
        completeFinger.transform.SetAsLastSibling();
        float eslapsed = 0;
        float seconds = 0.3f;
        Vector3 start = completeFinger.transform.position;
        Vector3 end = new Vector3(posInBar.transform.position.x, posInBar.transform.position.y, completeFinger.transform.position.z);
        float maxDist = Vector2.Distance(start, end);
        float curDist;
        Vector3 startScale = completeFinger.transform.localScale;
        float endScale = posInBar.GetComponent<RectTransform>().sizeDelta.x / completeFinger.GetComponent<RectTransform>().sizeDelta.x;

        light.gameObject.SetActive(false);

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            completeFinger.transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            curDist = Vector2.Distance(completeFinger.transform.position, end);
            completeFinger.transform.localScale = startScale + new Vector3((1 - curDist / maxDist) * (endScale - startScale.x),
                (1 - curDist / maxDist) * (endScale - startScale.y), (1 - curDist / maxDist) * (endScale - startScale.z));
            yield return new WaitForEndOfFrame();
        }
        completeFinger.transform.position = end;
        completeFinger.transform.localScale = Vector3.zero;
        ScaleDown(0.5f);
        posInBar.Complete();
        yield return new WaitForSeconds(0.5f);
        SessionManager_8.ins.GetCurListSession().GetComponent<Session2_8>().EndFingerSession();
    }


}
