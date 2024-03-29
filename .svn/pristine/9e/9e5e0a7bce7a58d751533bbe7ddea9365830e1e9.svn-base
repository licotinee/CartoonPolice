using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WhiteBg_SessionFoot_8 : MonoBehaviour
{
    [SerializeField] float speed;
    Image whiteBg;
    private void Awake()
    {
        whiteBg = GetComponent<Image>();
    }

    private void OnEnable()
    {
        StartCoroutine(StartFade());
    }
    IEnumerator StartFade()
    {
        while (whiteBg.color.a >= 0)
        {
            whiteBg.color -= new Color(0, 0, 0, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        gameObject.SetActive(false);
    }
}
