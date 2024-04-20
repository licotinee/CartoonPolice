using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private float length, startPos;
    [SerializeField] private Camera cam;
    [SerializeField] private float parallaxEffect;

    private void Awake()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().size.x;
    }

    private void LateUpdate()
    {
        float relativeCam = cam.transform.position.x * (1 - parallaxEffect);
        float dist = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3 (startPos + dist, transform.position.y, transform.position.z);
        if (relativeCam > startPos + length)
        {
            startPos += 2 * length;
        }else if (relativeCam < startPos - length)
        {
           startPos -= 2 * length;
        }
    }
}
