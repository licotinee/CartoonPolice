using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBar_Scene2_4 : MonoBehaviour
{
    [SerializeField] Image barFill;
    [SerializeField] Image icon;
    [SerializeField] float lengthBar;
    private float startYIcon;
    RectTransform rectIcon;
    private float normalScaleIcon;
    Animator animator;

    public delegate void EUpdateBar(float rate);
    public static EUpdateBar eUpdateBar;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rectIcon = icon.GetComponent<RectTransform>();
        normalScaleIcon = icon.transform.localScale.x;
        startYIcon = rectIcon.anchoredPosition.y;

        animator.Play("StartGame");
    }

    private void OnEnable()
    {
        eUpdateBar += UpdateBar;
        GameScene42Manager.eEndGame += EndGame;

    }

    private void OnDestroy()
    {
        eUpdateBar -= UpdateBar;
        GameScene42Manager.eEndGame -= EndGame;

    }

    private void UpdateBar(float rate)
    {
        if (rate >= 1)
        {
            rate = 1;
        }
        barFill.fillAmount = rate;
        rectIcon.anchoredPosition = new Vector2(rectIcon.anchoredPosition.x, startYIcon + rate * lengthBar);
        StopCoroutine(nameof(StartScaleIcon));
        StartCoroutine(nameof(StartScaleIcon));
    }

    IEnumerator StartScaleIcon()
    {
        float eslapsed = 0;
        float seconds = 0.25f;

        float start = normalScaleIcon;
        float end = 1.2f * start;

        rectIcon.transform.localScale = new Vector3(start, start, start);
        while (eslapsed <= seconds/2)
        {
            eslapsed += Time.deltaTime;
            rectIcon.transform.localScale = new Vector3(start + (end - start) * eslapsed/seconds, start + (end - start) * eslapsed / seconds, start + (end - start) * eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        rectIcon.transform.localScale = new Vector3(end, end, end);


        eslapsed = 0;

        end = start;
        start = rectIcon.transform.localScale.x;

        rectIcon.transform.localScale = new Vector3(start, start, start);
        while (eslapsed <= seconds / 2)
        {
            eslapsed += Time.deltaTime;
            rectIcon.transform.localScale = new Vector3(start + (end - start) * eslapsed / seconds, start + (end - start) * eslapsed / seconds, start + (end - start) * eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        rectIcon.transform.localScale = new Vector3(end, end, end);
    }

    private void EndGame()
    {
        animator.Play("EndGame");
    }
}
