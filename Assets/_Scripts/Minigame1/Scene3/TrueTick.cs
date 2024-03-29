using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrueTick : MonoBehaviour
{
    Image trueClick;
    private void Awake()
    {
        trueClick = GetComponent<Image>();
    }
    public void Enable(float seconds)
    {
        StartCoroutine(StartEnable(seconds));
    }
    IEnumerator StartEnable(float seconds)
    {
        trueClick.fillAmount = 0;
        float eslapsed = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            trueClick.fillAmount = eslapsed / seconds;
            yield return new WaitForEndOfFrame();
        }
        trueClick.fillAmount = 1;
    }
}
