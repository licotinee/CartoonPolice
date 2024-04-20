using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgAttack_Scene5_2 : MonoBehaviour
{
    SpriteRenderer sprite;
    private void Awake()
    {
        transform.position = Vector3.zero;
        sprite = GetComponent<SpriteRenderer>();
        SetSize();
    }

    public void Enable(float timeEnable)
    {
        StartCoroutine(StartEnable(timeEnable));
    }

    IEnumerator StartEnable(float timeEnable)
    {
        sprite.color = new Color(255, 255, 255, 0);
        float eslapsed = 0;
        float seconds = timeEnable/2;
        while(eslapsed <= seconds)
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

    private void SetSize()
    {
        float sizeX = sprite.bounds.size.x / 2;
        float sizeY = sprite.bounds.size.y / 2;

        float scaleX = Camera.main.orthographicSize * Camera.main.aspect / sizeX;
        float scaleY = Camera.main.orthographicSize / sizeY;

        float scale = (scaleX >= scaleY ? scaleX : scaleY);

        transform.localScale = new Vector3(scale, scale, scale);
    }
}
