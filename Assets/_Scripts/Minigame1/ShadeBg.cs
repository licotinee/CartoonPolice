using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadeBg : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] float startA;
    [SerializeField] float endA;
    [SerializeField] float seconds;
    private void Awake()
    {
        transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
        sprite = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(Camera.main.orthographicSize * Camera.main.aspect / (sprite.size.x / 2),
                                            Camera.main.orthographicSize / (sprite.size.y / 2));
        sprite.color = new Color(255, 255, 255, startA);
        StartCoroutine(StartShade());
    }

    IEnumerator StartShade()
    {
        float eslapsed = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            sprite.color = new Color(255, 255, 255, startA + (endA - startA) * eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        sprite.color = new Color(255, 255, 255, endA);
    }

}
