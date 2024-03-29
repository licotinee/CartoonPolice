using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suitcase : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteSuitcase;
    BoxCollider2D collider;
    bool isIllegal;
    bool isOnClick;
    bool isCanClick;
    [SerializeField] GameObject smell;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        CheckDestroy();
    }

    public void SetUp(Sprite sprite, bool illegal)
    {
        spriteSuitcase.sprite = sprite;
        float sizeX = spriteSuitcase.sprite.bounds.size.x;
        float sizeY = spriteSuitcase.sprite.bounds.size.y;
        collider.size = new Vector2(sizeX, sizeY);
        collider.offset = new Vector2(0, sizeY / 2);

        isIllegal = illegal;

        StartCoroutine(WaitToCanClick(sizeY));
    }

    IEnumerator WaitToCanClick(float sizeY)
    {
        yield return new WaitForSeconds(1.5f);
        isCanClick = true;
        if (isIllegal)
        {
            smell.SetActive(true);
            smell.transform.localPosition = new Vector3(0, sizeY + 0.5f, 0);
        }
    }

    private void OnMouseDown()
    {
        if (!isOnClick && isCanClick && !GameScene71Manager.ins.isFindingBanned && !GameScene71Manager.ins.isEndgame)
        {
            if (isIllegal)
            {
                StartCoroutine(nameof(TrueClick));
                // Enable Turn Click
                GameScene71Manager.ins.StartTurn(this.gameObject);
            }
            else
            {
                StartCoroutine(nameof(FalseClick));
                GameScene71Manager.ins.Smile();
            }
        }
    }

    IEnumerator TrueClick()
    {
        // Enable isIllegal

        float startScale = transform.localScale.x;
        float newScale = 1.2f * startScale;
        float speed = 0.8f;

        while (transform.localScale.x <= newScale)
        {
            transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(newScale, newScale, newScale);

        while (transform.localScale.x >= startScale)
        {
            transform.localScale -= new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        transform.localScale = new Vector3(startScale, startScale, startScale);

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    IEnumerator FalseClick()
    {
        //Cant click consecutive
        isOnClick = true;

        float newY;
        float speed = 10;
        
        newY = spriteSuitcase.transform.position.y + 1f;
        while (spriteSuitcase.transform.position.y <= newY)
        {
            spriteSuitcase.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            yield return new WaitForEndOfFrame();
        }
        spriteSuitcase.transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // ring
        float speedRotate = 300f;
        while (spriteSuitcase.transform.eulerAngles.z <= 25)
        {
            spriteSuitcase.transform.eulerAngles += new Vector3 (0, 0 , speedRotate * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        while (spriteSuitcase.transform.eulerAngles.z > 0 && spriteSuitcase.transform.eulerAngles.z <= 180)
        {
            spriteSuitcase.transform.eulerAngles -= new Vector3(0, 0, speedRotate * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }        
        
        while (spriteSuitcase.transform.eulerAngles.z >= 360 - 25)
        {
            spriteSuitcase.transform.eulerAngles -= new Vector3(0, 0, speedRotate * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        while (spriteSuitcase.transform.eulerAngles.z <= 360 && spriteSuitcase.transform.eulerAngles.z >= 180)
        {
            spriteSuitcase.transform.eulerAngles += new Vector3(0, 0, speedRotate * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        spriteSuitcase.transform.eulerAngles = Vector3.zero;


        // Move Down
        newY = spriteSuitcase.transform.position.y - 1f;
        while (spriteSuitcase.transform.position.y >= newY)
        {
            spriteSuitcase.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            yield return new WaitForEndOfFrame();
        }
        spriteSuitcase.transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Complete onClick
        isOnClick = false;
    }

    void CheckDestroy()
    {
        if (transform.position.x < Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - 2.5f || GameScene71Manager.ins.isEndgame)
        {
            Destroy(gameObject);
        }
    }
}
