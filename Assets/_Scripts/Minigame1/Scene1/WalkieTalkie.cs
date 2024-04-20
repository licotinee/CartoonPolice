using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkieTalkie : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxRotation;

    private void Start()
    {
        StartCoroutine(Shake1());    
    }
    IEnumerator Shake1()
    {
        while (transform.eulerAngles.z <= maxRotation)
        {
            transform.eulerAngles += new Vector3(0, 0, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        transform.eulerAngles = new Vector3(0, 0, maxRotation);
        StartCoroutine(Shake2());
    }

    IEnumerator Shake2()
    {
        while (transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= 180)
        {
            transform.eulerAngles -= new Vector3(0, 0, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        transform.eulerAngles = new Vector3(0, 0, 0);
        StartCoroutine(Shake3());

    }

    IEnumerator Shake3()
    {
        while (transform.eulerAngles.z >= (360 - maxRotation) && transform.eulerAngles.z >= 180 || transform.eulerAngles.z == 0)
        {
            transform.eulerAngles -= new Vector3(0, 0, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        transform.eulerAngles = new Vector3(0, 0, 360 - maxRotation);
        StartCoroutine(Shake4());

    }

    IEnumerator Shake4()
    {
        while (transform.eulerAngles.z <= 360 && transform.eulerAngles.z >= 180)
        {
            transform.eulerAngles += new Vector3(0, 0, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        transform.eulerAngles = new Vector3(0, 0, 0);
        StartCoroutine(Shake1());

    }

}
