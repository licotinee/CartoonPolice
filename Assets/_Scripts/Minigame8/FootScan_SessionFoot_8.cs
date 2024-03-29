using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class FootScan_SessionFoot_8 : MonoBehaviour
{
    [SerializeField] Image footPrint;
    [SerializeField] float rotateSpeed;
    [SerializeField] Bar_Session2_8 bar;
    [SerializeField] PrintInBar_SessionFoot_8 posInBar;
    [SerializeField] Light_Session_8 light;
    float endScale;
    private void Awake()
    {
        endScale = transform.localScale.x;
        transform.localScale = Vector3.zero;
        transform.position = new Vector3(footPrint.transform.position.x, footPrint.transform.position.y, transform.position.z);
    }
    
    public void OnEnable()
    {
        StartCoroutine(StartZoomOut());
    }

    IEnumerator StartZoomOut()
    {
        float curRotate = 0f;
        float endRotate = 360f * 2;
        Vector3 start = transform.position;
        Vector3 end = new Vector3(0, 0, transform.position.z);
        while (curRotate <= endRotate)
        {
            curRotate += rotateSpeed * Time.deltaTime;
            // rotate
            transform.eulerAngles = new Vector3(0, 0, curRotate);
            transform.position = Vector3.Lerp(start, end, curRotate / endRotate);

            transform.localScale = new Vector3((curRotate / endRotate) * endScale, (curRotate / endRotate) * endScale, (curRotate / endRotate) * endScale);
            yield return new WaitForEndOfFrame();
        }
        light.gameObject.SetActive(true);
        transform.position = end;
        transform.localScale = new Vector3(endScale, endScale, endScale);
        transform.eulerAngles = Vector3.zero;
        bar.MoveRight(0.5f);
        yield return new WaitForSeconds(2f);
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
        SessionManager_8.ins.GetCurListSession().GetComponent<Session2_8>().EndFootSession();
    }
}
