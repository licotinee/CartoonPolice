using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PanelClick : MonoBehaviour
{
    [SerializeField] Button trueClickBtn1;
    [SerializeField] Button trueClickBtn2;
    [SerializeField] Button falseClick1;
    [SerializeField] Button falseClick2;
    [SerializeField] TrueTick trueTick;
    [SerializeField] FalseTick falseTick;
    float startScale;
    bool isCanClick;
    private void Awake()
    {
        trueClickBtn1.onClick.AddListener(TrueClicked);
        trueClickBtn2.onClick.AddListener(TrueClicked);
        falseClick1.onClick.AddListener(FalseClick);
        falseClick2.onClick.AddListener(FalseClick);
    }

    void TrueClicked()
    {
        if (isCanClick)
        {
            StartCoroutine(StartTrueClick());
        }
    }

    IEnumerator StartTrueClick()
    {
        isCanClick = false;
        Hint.eStopHint?.Invoke();
        TrueTick firstTick = Instantiate(trueTick, trueClickBtn1.transform.position, Quaternion.identity, transform);
        TrueTick secondTick = Instantiate(trueTick, trueClickBtn2.transform.position, Quaternion.identity, transform);
        firstTick.Enable(0.25f);
        secondTick.Enable(0.25f);
        GameScene3Manager.ins.UpdateBar(0.25f);
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(EndTurn());
    }

    void FalseClick()
    {
        if (isCanClick)
        {
            StartCoroutine(StartFalseClick());
        }
    }

    IEnumerator StartFalseClick()
    {
        Vector3 posClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 posInstance = new Vector3(posClick.x, posClick.y, transform.position.z);
        isCanClick = false;
        FalseTick Tick = Instantiate(falseTick, posInstance, Quaternion.identity, transform);
        Tick.Enable(0.65f);
        yield return new WaitForSeconds(0.65f);
        isCanClick = true;
    }

    private void OnEnable()
    {
        StartCoroutine(StartTurn());
    }

    IEnumerator EndTurn()
    {
        float eslapsed = 0;
        float seconds = 0.25f;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.localScale = new Vector3(transform.localScale.x, (1 - eslapsed / seconds) * startScale, transform.localScale.z);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
        yield return new WaitForSeconds(0.2f); // delay
        GameScene3Manager.ins.UpdateTurn();
    }

    IEnumerator StartTurn()
    {
        startScale = transform.localScale.y;
        transform.localScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
        float eslapsed = 0;
        float seconds = 0.25f;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.localScale = new Vector3(transform.localScale.x, (eslapsed / seconds) * startScale, transform.localScale.z);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(transform.localScale.x, startScale, transform.localScale.z);
        isCanClick = true;
    }
}
