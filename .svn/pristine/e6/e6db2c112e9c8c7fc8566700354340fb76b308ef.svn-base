using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarPannelScene72 : MonoBehaviour
{
    [SerializeField] Image barFill;
    [SerializeField] List<Image> ListStars;
    [SerializeField] Image icon;
    int curCheckPoint = 0;
    float lengthBar;
    [SerializeField] Sprite completeSprite;
    private void Start()
    {
        lengthBar = ListStars[ListStars.Count - 1].transform.position.y - icon.transform.position.y;
        setUpPositonStar();
    }
    void setUpPositonStar()
    {
        ListStars[0].transform.position = new Vector3(ListStars[0].transform.position.x, icon.transform.position.y + (1f / 3f) * lengthBar);
        ListStars[1].transform.position = new Vector3(ListStars[1].transform.position.x, icon.transform.position.y + (3f / 4f) * lengthBar);
    }

    public void UpdateBarFill(float rate)
    {
        barFill.fillAmount = rate;
    }

    public void UpdateIcon(float rate)
    {
        float startY = ListStars[2].transform.position.y - lengthBar;
        icon.transform.position = new Vector3(icon.transform.position.x, startY + rate * lengthBar);
        GetCheckPoint();
    }

    void GetCheckPoint()
    {
        if (Mathf.Abs(icon.transform.position.y - ListStars[curCheckPoint].transform.position.y) <= 0.05f || icon.transform.position.y >= ListStars[curCheckPoint].transform.position.y)
        {
            TransformCompleteStar(ListStars[curCheckPoint]);
        }
    }

    void TransformCompleteStar(Image star)
    {
        curCheckPoint++;
        GameScene72Manager.ins.AttackTheCriminal(curCheckPoint);
        StartCoroutine(StartTransform(star));
    }

    IEnumerator StartTransform(Image star)
    {
        GameScene72Manager.ins.UpdateScaleSpeed(curCheckPoint);
        
        star.sprite = completeSprite;
        float startScale = star.transform.localScale.x;
        float endScale = 1.2f * startScale;

        float speed = 0.4f;

        while (star.transform.localScale.x <= endScale)
        {
            star.transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed*Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        star.transform.localScale = new Vector3(endScale, endScale, endScale);

        while (star.transform.localScale.x >= startScale)
        {
            star.transform.localScale -= new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        star.transform.localScale = new Vector3(startScale, startScale, startScale);
    }
}

