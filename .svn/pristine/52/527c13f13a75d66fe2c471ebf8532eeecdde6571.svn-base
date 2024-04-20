using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Smoke_Scene2_3 : MonoBehaviour
{
    [SerializeField] float timeExist;
    private void Start()
    {
        StartCoroutine(StartCountTime());
    }

    IEnumerator StartCountTime()
    {
        float eslased = 0;
        while (eslased <= timeExist)
        {
            eslased += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
