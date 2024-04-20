using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarProgress_Scene5_1 : MonoBehaviour
{
    [SerializeField] Image barFill;
    [SerializeField] public Image icon;
    [SerializeField] List<Image> ListStars;
    [SerializeField] Sprite completeStar;
    public int cntCompleteStar;
    Vector3 startPosIcon;
    private float size;
    private float scaleIcon;
    private void Awake()
    {
        SetUpBar();
    }

    private void SetUpBar()
    {
        scaleIcon = icon.transform.localScale.x;
        startPosIcon = icon.transform.position;
        size = ListStars[ListStars.Count - 1].transform.position.x - icon.transform.position.x;
        for (int i = 0; i < ListStars.Count; ++i)
        {
            ListStars[i].transform.position = new Vector3(startPosIcon.x + 1.0f * (i+1)/ListStars.Count * size, ListStars[i].transform.position.y, ListStars[i].transform.position.z);
        }

    }

    public void UpdateBar(float rate)
    {
        barFill.fillAmount = rate;
        StartCoroutine(StartUpdateIcon(rate));  
    }

    IEnumerator StartUpdateIcon(float rate)
    {
        icon.transform.position = new Vector3(startPosIcon.x + rate * size, startPosIcon.y, startPosIcon.z);
        icon.transform.localScale = new Vector3 (1.2f * scaleIcon, 1.2f * scaleIcon, 1.2f * scaleIcon);
        yield return new WaitForSeconds(0.1f);
        icon.transform.localScale = new Vector3 (scaleIcon, scaleIcon, scaleIcon);
        CheckCompleteStar();
    }


    void CheckCompleteStar()
    {
        if (cntCompleteStar < ListStars.Count)
        {
            if (Mathf.Abs(icon.transform.position.x - ListStars[cntCompleteStar].transform.position.x) <= 0.05f || icon.transform.position.x >= ListStars[cntCompleteStar].transform.position.x)
            {
                StartCoroutine(StartCompleteStar(ListStars[cntCompleteStar]));
            }
        }
    }

    IEnumerator StartCompleteStar(Image star)
    {
        cntCompleteStar++;

        float scale = star.transform.localScale.x;
        star.sprite = completeStar;
        star.transform.SetAsLastSibling();
        star.transform.localScale = new Vector3(1.2f * scale, 1.2f * scale, 1.2f * scale);
        yield return new WaitForSeconds(0.5f);
        star.transform.localScale = new Vector3(scale, scale, scale);
        star.transform.SetAsFirstSibling();

        if (cntCompleteStar < ListStars.Count)
        {
            GameScene15Manager.ins.UpdateLevel(cntCompleteStar);
        }
    }
}

