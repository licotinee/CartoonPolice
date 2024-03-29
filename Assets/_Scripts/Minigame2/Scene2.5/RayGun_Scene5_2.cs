using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGun_Scene5_2 : MonoBehaviour
{
    SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        sprite.color = new Color(255, 255, 255, 0);
    }
    public void Fade(float seconds)
    {
        StartCoroutine(StartFade(seconds));
    }

    IEnumerator StartFade(float timeFade)
    {
        float eslapsed = 0;
        float seconds = timeFade / 2;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            sprite.color = new Color(255, 255, 255, eslapsed/seconds);
            yield return new WaitForEndOfFrame();
        }
        sprite.color = new Color(255, 255, 255, 1);

        eslapsed = 0;

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            sprite.color = new Color(255, 255, 255, 1 - eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        sprite.color = new Color(255, 255, 255, 0);
        Destroy(gameObject);

    }
}
