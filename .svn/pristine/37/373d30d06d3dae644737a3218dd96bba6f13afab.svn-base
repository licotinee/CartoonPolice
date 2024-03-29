using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManagerScene52 : MonoBehaviour
{
    [SerializeField] Image iconCar;
    [SerializeField] List<Image> ListStar;
    [SerializeField] Sprite completedStar;
    [SerializeField] Image barFill;
    int completedStartCount;
    Vector3 startPos;
    Vector3 normalScale;
    [SerializeField] float lengthBar;
    private void Start()
    {
        normalScale = iconCar.transform.localScale;
        SetPosStar();
    }

    private void SetPosStar()
    {
        startPos = iconCar.rectTransform.anchoredPosition;
        ListStar[0].rectTransform.anchoredPosition = startPos + new Vector3(lengthBar * 2 / 7, 0, 0);
        ListStar[1].rectTransform.anchoredPosition = startPos + new Vector3(lengthBar * 2 / 3, 0, 0);
        ListStar[2].rectTransform.anchoredPosition = startPos + new Vector3(lengthBar, 0, 0);
    }

    public void UpdatePosIcon(float rate)
    {
        StartCoroutine(StartUpdate(rate));
    }

    IEnumerator StartUpdate(float rate)
    {
        rate = rate >= 1 ? 1 : rate;
        float timeUpdate = 0.1f;
        iconCar.rectTransform.anchoredPosition = startPos + new Vector3(rate * lengthBar, 0, 0);
        iconCar.rectTransform.localScale = new Vector3(normalScale.x * 1.2f, normalScale.y * 1.2f, normalScale.z * 1.2f);
        CheckPassOverStar();
        yield return new WaitForSeconds(timeUpdate);
        iconCar.rectTransform.localScale = normalScale;
    }

    private void CheckPassOverStar()
    {
        if (completedStartCount < ListStar.Count)
        {
            if ((iconCar.transform.position.x >= ListStar[completedStartCount].transform.position.x || Mathf.Abs(iconCar.transform.position.x - ListStar[completedStartCount].transform.position.x) <= 0.05f))
            {
                TransformCompletedStar(ListStar[completedStartCount]);
                completedStartCount++;
                GameScene52Manager.ins.SpeedUp();
            }
        }
    }

    private void TransformCompletedStar(Image star)
    {
        StartCoroutine(StartTransformCompletedStar(star));
    }

    IEnumerator StartTransformCompletedStar(Image star)
    {
        Vector3 normalScale = star.rectTransform.localScale;
        star.transform.SetAsLastSibling();
        float timeTransform = 0.1f;
        star.rectTransform.localScale = new Vector3(normalScale.x * 1.2f, normalScale.y * 1.2f, normalScale.z * 1.2f);
        star.sprite = completedStar;
        yield return new WaitForSeconds(timeTransform);
        star.transform.localScale = normalScale;
        star.transform.SetAsFirstSibling();

    }
}
