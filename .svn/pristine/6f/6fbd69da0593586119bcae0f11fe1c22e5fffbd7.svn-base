using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintInBar_SessionFoot_8 : MonoBehaviour
{
    [SerializeField] Sprite completeSprite;
    Image img;
    [SerializeField] TrueTickBar trueTick;
    private void Start()
    {
        img = GetComponent<Image>();   
    }

    public void Complete()
    {
        StartCoroutine(StartComplete());
    }

    IEnumerator StartComplete()
    {
        float endScale = transform.localScale.x;
        float startScale = 1.2f * transform.localScale.x;
        
        transform.localScale = new Vector3(startScale, startScale, startScale);
        img.sprite = completeSprite;

        float speed = 0.5f;
        while (transform.localScale.x >= endScale)
        {
            transform.localScale -= new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();   
        }
        transform.localScale = new Vector3 (endScale, endScale, endScale);
        Instantiate(trueTick, transform);
    }
}
