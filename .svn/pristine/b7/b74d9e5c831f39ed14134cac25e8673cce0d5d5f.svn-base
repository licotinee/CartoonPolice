using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_scene4_1 : MonoBehaviour
{
    [SerializeField] float roatateSpeed;

    private void OnEnable()
    {
        StartCoroutine(StartRotate());
    }

    IEnumerator StartRotate()
    {
        while (true)
        {
            transform.eulerAngles += new Vector3(0, 0, roatateSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

    }
}
