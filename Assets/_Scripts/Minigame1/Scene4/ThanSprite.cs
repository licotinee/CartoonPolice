using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThanSprite : MonoBehaviour
{
    [SerializeField] List<Sprite> ListSprite;
    SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    IEnumerator NhapNhayThanSprite()
    {
        int cnt = 0;
        int soLuongSprite = ListSprite.Count;
        while (cnt < soLuongSprite)
        {
            sprite.color = new Color(255, 255, 255, 0);
            sprite.sprite = ListSprite[cnt];
            cnt++;
            if(cnt == soLuongSprite)
            {
                sprite.color = new Color(255, 255, 255, 1);
            }
            float eslapsed = 0;
            float seconds = 0.5f;
            while(eslapsed <= seconds)
            {
                eslapsed += Time.deltaTime;
                sprite.color = new Color(255, 255, 255, eslapsed/seconds);
                yield return new WaitForEndOfFrame();
            }
            sprite.color = new Color(255, 255, 255, 1);
            
        }
    }


    public void NhapNhay()
    {
        StartCoroutine(NhapNhayThanSprite());
    }


}
