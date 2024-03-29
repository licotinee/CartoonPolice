using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarProgressScene63 : MonoBehaviour
{
    [SerializeField] Image barFill;
    private float curTime;

    float startScaleX;

    private void Awake()
    {
        startScaleX = transform.localScale.x;
    }

    private void OnEnable()
    {
        StartCoroutine(StartEnlarge());
    }

    IEnumerator StartEnlarge()
    {
        float speedEnlarge = 3;
        transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);
        while (transform.localScale.x <= startScaleX)
        {
            transform.localScale += new Vector3(speedEnlarge * Time.deltaTime, 0, 0);
            yield return new WaitForEndOfFrame();   
        }
    }

    public void UpdateBar()
    {
        if (curTime < GameScene63Manager.ins.maxTime)
        {
            curTime += Time.deltaTime;
            barFill.fillAmount = curTime / GameScene63Manager.ins.maxTime;
        }
        else
        {
            GameScene63Manager.ins.EndGame();
            gameObject.SetActive(false);
        }

    }
}
