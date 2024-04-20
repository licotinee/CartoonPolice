using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken : MonoBehaviour
{
    [SerializeField] GameObject bgRed;
    float sizeX;
    float sizeY;
    SpriteRenderer spriteRender;
    GameObject bg;

    [SerializeField] GameObject itemBreak;
    GameObject item;
    int index;
    [SerializeField] List<Sprite> ListBreaks;
    private void Start() 
    {
        bg = Instantiate(bgRed, Vector3.zero, Quaternion.identity);
        
        spriteRender = bg.GetComponent<SpriteRenderer>();

        spriteRender.color = new Color(255, 255, 255, 0);

        sizeX = spriteRender.sprite.bounds.size.x / 2;
        sizeY = spriteRender.sprite.bounds.size.y / 2;

        float scaleX = Camera.main.orthographicSize * Camera.main.aspect / sizeX;
        float scaleY = Camera.main.orthographicSize / sizeY;

        float scale = (scaleX >= scaleY ? scaleX : scaleY);

        bg.transform.localScale = new Vector3(scale, scale, scale);

        StartCoroutine(nameof(StartShade));

        item = Instantiate(itemBreak, Vector3.zero, Quaternion.identity);
        StartCoroutine(nameof(StartBreakItem));
    }

    IEnumerator StartShade()
    {
        float speed = 2f;
        while (spriteRender.color.a <= 1)
        {
            spriteRender.color += new Color(0, 0, 0, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        spriteRender.color = new Color(255, 255, 255, 1);

        while (spriteRender.color.a >= 0)
        {
            spriteRender.color -= new Color(0, 0, 0, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        spriteRender.color = new Color(255, 255, 255, 0);
        Destroy(bg);
        Destroy(item);
        Destroy(gameObject);
    }

    IEnumerator StartBreakItem()
    {
        item.GetComponent<SpriteRenderer>().sprite = ListBreaks[index];
        float endScale = item.transform.localScale.x;
        float startScale = endScale/2;
        item.transform.localScale = new Vector3(startScale, startScale, startScale);
        if (index < 3)
        {
            item.transform.position = transform.position;

            float speed = 0.55f;

            while (item.transform.localScale.x <= endScale)
            {
                item.transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }

            item.transform.localScale = new Vector3(endScale, endScale, endScale);
        }
        else
        {
            float speed = 0.55f;
            item.transform.position = transform.position - new Vector3(2f, 0 , 0);

            while (item.transform.localScale.x <= endScale)
            {
                item.transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }

            item.transform.localScale = new Vector3(endScale, endScale, endScale);

            item.transform.position = transform.position + new Vector3(2f, 0, 0);
            item.transform.localScale = new Vector3(startScale, startScale, startScale);
            while (item.transform.localScale.x <= endScale)
            {
                item.transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            item.transform.localScale = new Vector3(endScale, endScale, endScale);
        }

    }

    public void SetIndex(int number)
    {
        index = number;
    }
}
