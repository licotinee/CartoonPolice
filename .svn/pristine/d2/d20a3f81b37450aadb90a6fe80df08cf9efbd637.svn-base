using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoPhanGhepHinh : DragSprite
{
    [SerializeField] GameObject hinhVuongHienThi;
    [SerializeField] GameObject hintSprite;
    [SerializeField] GameObject hintNetDut;
    [SerializeField] GameObject light;
    private void Awake()
    {
        SetStartValue();
    }
    public override void CorrectDrag()
    {
        base.CorrectDrag();
        StartCoroutine(StartCorrectDrag());
    }

    IEnumerator StartCorrectDrag()
    {
        float eslapsed = 0;
        float seconds = 0.2f;
        float startScale = transform.localScale.x;
        float start = 1.3f * startScale;
        float end = startScale;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.localScale = new Vector3(start + (end - start) * (eslapsed/seconds), start + (end - start) * (eslapsed / seconds), start + (end - start) * (eslapsed / seconds));
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(end, end, end);
        hinhVuongHienThi.GetComponent<SquareShow>().ScaleDown(0.2f);
        hintSprite.GetComponent<HintNhapNhay>().StopHint();
        hintNetDut.GetComponent<HintNhapNhay>().StopHint();
        yield return new WaitForSeconds(0.2f);
        GamePlay_Scene4_1_Manager.ins.UpdateCntTrueBoPhan();
    }


    public override void ChangeScale()
    {
        // Chi co 1 true object
        transform.localScale = ListTrueObjects[0].transform.localScale;
    }

    void SetStartValue()
    {
        startPos = transform.position;
        scaleNormal = transform.localScale;
    }

    public override void DoSthingWhenOnMouseDown()
    {
        base.DoSthingWhenOnMouseDown();
        hintSprite.GetComponent<HintNhapNhay>().StartHint();
        hintNetDut.GetComponent<HintNhapNhay>().StartHint();
    }

    public override void DoSthingWhenOnMouseUp()
    {
        base.DoSthingWhenOnMouseUp();
        hintSprite.GetComponent<HintNhapNhay>().StopHint();
        hintNetDut.GetComponent<HintNhapNhay>().StopHint();
    }

    public void MoveToStartPos(float seconds)
    {
        StartCoroutine(StartMoveToStartPos(seconds));
    }

    IEnumerator StartMoveToStartPos(float seconds)
    {
        light.gameObject.SetActive(false);
        float eslapsed = 0;
        Vector3 start = transform.position;
        Vector3 end = startPos;

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        isCanDrag = true;
    }
}
