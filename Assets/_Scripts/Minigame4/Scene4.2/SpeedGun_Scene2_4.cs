using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedGun_Scene2_4 : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] Transform startLine;
    [SerializeField] Transform endLine;
    [SerializeField] float timeShootRay;

    public delegate void EGunShootRay(Transform posCeneterCar);
    public static EGunShootRay gunShootRay;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void OnEnable()
    {
        gunShootRay += ShootRay;
    }

    private void OnDestroy()
    {
        gunShootRay -= ShootRay;
    }

    private void ShootRay(Transform posCenterCar)
    {
        StopCoroutine(nameof(StartShootRay));
        StartCoroutine(nameof(StartShootRay), posCenterCar);
    }

    IEnumerator StartShootRay(Transform posCenterCar)
    {
        float eslapsed = 0;
        float seconds = timeShootRay;
        endLine = posCenterCar;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            lineRenderer.SetPosition(0, startLine.position);
            lineRenderer.SetPosition(1, endLine.position);
            yield return new WaitForEndOfFrame();
        }
        lineRenderer.SetPosition(1, startLine.position);
    }
    
}
