using Spine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Police_SceneBank;
using DG.Tweening;



public class BannedItem : MonoBehaviour
{
    Vector3 startPos;
    float maxScale;
    [SerializeField] public float seconds;
    [SerializeField] float speedRotate;
    [SerializeField] List<Sprite> sprites;
    [SerializeField] Broken broken;
    BoxCollider2D collider2D;
    SpriteRenderer spriteRender;
    public bool isItemTutorial;
    public GameObject animTut;
    int ran;
    private void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.gameObject.CompareTag("LimitPosTutorial"))
        {

            Debug.LogError("cham collirder");
        }
    }
    [SerializeField] List<ListFragment> ListFragments;
    void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        startPos = transform.position;
        maxScale = transform.localScale.x;
        ran = Random.Range(0, sprites.Count);
        spriteRender.sprite = sprites[ran];
        //if (isItemTutorial)
        //{
        //    this.MoveToPosTutorial();
        //    return;
        //}
        StartCoroutine(nameof(MoveToEndPos));
    }
    
    //private void MoveToPosTutorial()
    //{
    //    transform.localScale = Vector2.zero;
    //    Vector3 endPos = new Vector3(Random.Range(-Camera.main.orthographicSize * Camera.main.aspect + 3f, 0), Random.Range(-1, Camera.main.orthographicSize - 2f), 0);

    //    transform.DOScale(new Vector3(1, 1, 1), 2f);
    //    transform.DORotate(new Vector3(0, 0, 360), 2f);
    //    transform.DOMove(endPos, 2f).OnComplete(() =>
    //    {
    //        //animTut.SetActive(true);
    //    });
    //}
    IEnumerator MoveToEndPos()
    {
        transform.localScale = Vector2.zero;
        Vector3 endPos = new Vector3(Random.Range(-Camera.main.orthographicSize * Camera.main.aspect+ 3f, 0), Random.Range(-1, Camera.main.orthographicSize - 2f), 0);

        float maxDist = Vector2.Distance(startPos, endPos);
        float curDist;

        float eslapsed = 0;
        while(eslapsed <= seconds)
        {
            //rotate
            transform.eulerAngles -= new Vector3(0, 0, speedRotate * Time.deltaTime);

            eslapsed += Time.deltaTime;
            transform.position = Vector2.Lerp(startPos, endPos, eslapsed / seconds);
            curDist = Vector2.Distance(transform.position, endPos);
            transform.localScale = new Vector3((1 - curDist / maxDist) * maxScale, (1 - curDist / maxDist) * maxScale, (1 - curDist / maxDist) * maxScale);

            //Scale collider
            float sizeX = spriteRender.sprite.bounds.size.x;
            float sizeY = spriteRender.sprite.bounds.size.y;

            collider2D.size = new Vector2(sizeX, sizeY);
            

            yield return new WaitForEndOfFrame();
        }
        transform.position = endPos;
        transform.localScale = new Vector3(maxScale, maxScale, maxScale);
        animTut.SetActive(true);

        if (!GameScene72Manager.ins.isDogAttacking && !isItemTutorial)
        {
            SoundManager.Instance.PlaySFX(SoundTag.Eff_grass_broken);
            SoundManager.Instance.PlaySFXOneShot(SoundTag.Eff_fail_01);
            Broken newBroke = Instantiate(broken, transform.position, Quaternion.identity);
            newBroke.SetIndex(ran);
            GameScene72Manager.ins.dog.BeHitted();
            Destroy(this.gameObject);
        }


    }

    private void OnMouseDown()
    {
        if (isItemTutorial)
        {
            CriminalScene72.Instance.SpawnBannedItem();
            animTut.SetActive(false);
            PlayerPrefs.SetInt(CONSTANTS.FirstPlayScene7_2, 0);
        }
       
        ListFragment fragment = Instantiate(ListFragments[ran], transform.position, Quaternion.identity);
        fragment.FlyOut(transform.localScale.x);
        GameScene72Manager.ins.UpDatePoint();
        SoundManager.Instance.PlaySFX(SoundTag.Eff_grass_broken);
        SoundManager.Instance.PlaySFXOneShot(SoundTag.Eff_success_02);
        Destroy(gameObject);
    }

}
