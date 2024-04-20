using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Scene6_8 : MonoBehaviour
{
    [SerializeField] float speedScale;
    [SerializeField] float startScale;
    [SerializeField] float endScale;
    SpriteRenderer sprite;
    private void Awake()
    {
        transform.localScale = new Vector3(startScale, startScale, startScale);
        sprite = GetComponent<SpriteRenderer>();
    }

    public void ScaleUp(float seconds)
    {
        StartCoroutine(StartScaleUp(seconds));
    }

    IEnumerator StartScaleUp(float seconds)
    {
        transform.localScale = new Vector3(startScale, startScale, startScale);
        float eslapsed = 0;
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.localScale = new Vector3(startScale + (endScale -startScale) * (eslapsed / seconds), startScale + (endScale - startScale) * (eslapsed / seconds), startScale + (endScale - startScale) * (eslapsed / seconds));
            sprite.color += new Color(0, 0, 0, 1 * (eslapsed / seconds));
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(endScale, endScale, endScale);
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        Destroy(gameObject);
    }
}
