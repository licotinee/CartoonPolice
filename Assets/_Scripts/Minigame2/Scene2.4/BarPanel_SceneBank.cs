using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarPanel_SceneBank : MonoBehaviour
{
    public static BarPanel_SceneBank ins;
    [SerializeField] Image barFill;
    [SerializeField] Image icon;

    float lengthBar;
    RectTransform iconRect;
    private void Awake()
    {
        ins = this;
        iconRect = icon.GetComponent<RectTransform>();
        lengthBar = barFill.GetComponent<RectTransform>().rect.width;
    }
    public void UpdateBar(float rate)
    {
        barFill.fillAmount = rate;

        //Update pos icon
        iconRect.anchoredPosition = new Vector3(rate * lengthBar, 0, 0);
    }
}
