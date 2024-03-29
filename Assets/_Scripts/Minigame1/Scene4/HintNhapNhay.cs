using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintNhapNhay : MonoBehaviour
{
    [SerializeField] float speed;
    SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void StartHint()
    {
        StartCoroutine(nameof(NhapNhay));
    }

    IEnumerator NhapNhay() 
    {
        while (true)
        {
            if (sprite.color.a <= 0.1f)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.8f);
            }
            sprite.color -= new Color(0, 0, 0, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    public void StopHint()
    {
        StopCoroutine(nameof(NhapNhay));
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0f);
    }
}
