using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarPanel_Scene5_2 : MonoBehaviour
{
    public static BarPanel_Scene5_2 ins = null;
    [SerializeField] Image barFill;
    [SerializeField] Image icon;
    [SerializeField] float lengthBar;
    private float startYIcon;
    RectTransform rectIcon;
    Animator animEnd;
    private void Awake()
    {
        ins = this;
        rectIcon = icon.GetComponent<RectTransform>();
        startYIcon = rectIcon.anchoredPosition.y;
        animEnd = GetComponent<Animator>();

    }


    public void UpdateBar(float rate)
    {
        barFill.fillAmount = rate;
        rectIcon.anchoredPosition = new Vector2(rectIcon.anchoredPosition.x, startYIcon + rate * lengthBar);
    }


    public void EndGame()
    {
        animEnd.Play("Bar_Scene5_2EndGame");
    }
}
 