using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CarEnemy_Scene2_4 : MonoBehaviour
{
    protected Rigidbody2D rigid;
    [SerializeField] SkeletonAnimation skeleton;
    [SerializeField] GameObject smoke;
    [SerializeField] protected Transform posCenter;
    [SerializeField] float speedNormal;
    [SerializeField] float speedFast;
    [SerializeField] float timeBeShooted;
    [SerializeField] bool isBossCar;
    [SerializeField] GameObject animTutorial;
    [SerializeField] GameObject spriteFocus;
    private bool canShooted;
    private bool isMoveFast;
    public bool isCarTutorial;
    public delegate void CarEnemyShooted(bool isMoveFast);
    public static event CarEnemyShooted carEnemyShooted;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        GameScene42Manager.eEndGame += EndGame;
    }

    private void OnDestroy()
    {
        GameScene42Manager.eEndGame -= EndGame;
    }

    public void SetUpCarTutorial(string skin)
    {
        skeleton.initialSkinName = skin;
        skeleton.Initialize(true);
        canShooted = true;
        isMoveFast = false;
        smoke.gameObject.SetActive(true);
        skeleton.AnimationState.SetAnimation(0, "Run_1", true);

        rigid.velocity = new Vector2(speedFast, 0);
    }
    public void SetUp(string skin, bool isMoveFast)
    {
        skeleton.initialSkinName = skin;
        skeleton.Initialize(true);
    
        if (isMoveFast)
        {
            MoveFast();
        }
        else 
        {
            MoveNormal();
        }
    }

 
    private void MoveNormal()
    {
        canShooted = true;
        isMoveFast = false;
        smoke.gameObject.SetActive(false);
        skeleton.AnimationState.SetAnimation(0, "Run_1", true);
        rigid.velocity = new Vector2(speedNormal, 0);
        
    }

    private void MoveFast()
    {
        canShooted = true;
        isMoveFast = true;
        smoke.gameObject.SetActive(true);
        skeleton.AnimationState.SetAnimation(0, "Run_2", true);
        rigid.velocity = new Vector2(speedFast, 0);
    }

    private void OnMouseDown()
    {
        if (canShooted)
        {
            if (isCarTutorial)
            {
                skeleton.AnimationState.SetAnimation(0, "Run_1", true);
                rigid.velocity = new Vector2(speedNormal, 0);
                animTutorial.SetActive(false);
                spriteFocus.SetActive(false);
                PlayerPrefs.SetInt(CONSTANTS.FirstPlayScene4_2, 0);
                this.smoke.SetActive(false);
                SpawnCarEnemy_Scene2_4.Instance.StartSpawnCar();
            }
            carEnemyShooted?.Invoke(isMoveFast);
            SpeedGun_Scene2_4.gunShootRay?.Invoke(posCenter);

            if (isMoveFast)
            {
                StartCoroutine(StartBecomeNormal());
            }
            else
            {
                StartCoroutine(StartDelay());   
            }
        }

    }

    IEnumerator StartBecomeNormal()
    {
        canShooted = false;
        isMoveFast = false;
        GameScene42Manager.ins.UpdatePoint();
        smoke.GetComponent<Smoke_Scene2_4>().Fade();
        skeleton.AnimationState.SetAnimation(0, "Defeat", true);
        yield return new WaitForSeconds(timeBeShooted);
        MoveNormal();
        yield return new WaitForSeconds(0.5f);
        canShooted = true;
    }

    IEnumerator StartDelay()
    {
        canShooted = false;
        yield return new WaitForSeconds(timeBeShooted + 0.5f);
        canShooted = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LimitScene"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("LimitShoot"))
        {
            canShooted = false; 
        }

        if (collision.gameObject.CompareTag("LimitPosTutorial") && isCarTutorial)
        {

            rigid.velocity = Vector2.zero;
            skeleton.AnimationState.SetAnimation(0, "Idle", true);
            animTutorial.SetActive(true);
            spriteFocus.SetActive(true);
        }
    }


    private void EndGame()
    {
        canShooted = false;
        if (transform.position.x <= -Camera.main.orthographicSize * Camera.main.aspect - 3f)
        {
            if (!isBossCar)
            {
                Destroy(gameObject);
            }
        }
    }
}
