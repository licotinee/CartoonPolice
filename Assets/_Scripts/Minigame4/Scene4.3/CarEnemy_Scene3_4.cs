using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnemy_Scene3_4 : MonoBehaviour
{
    [SerializeField] protected SkeletonAnimation skeleton;
    [SerializeField] protected float speed;
    [SerializeField] float timeBeHitted;
    protected Rigidbody2D rigid;
    
    protected void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    protected virtual void OnEnable()
    {
        GameScene43Manager.eEndGame += EndGame;
    }

    protected virtual void OnDestroy()
    {
        GameScene43Manager.eEndGame -= EndGame;

    }
    protected void FixedUpdate()
    {
        MoveX();
    }
    protected void MoveX()
    {
        if (GameScene43Manager.ins.isStartGame && !GameScene43Manager.ins.isEndGame)
        {
            rigid.velocity = new Vector2(speed * Time.deltaTime, 0);
        }
    }

    public void SetUp(string skin)
    {
        skeleton.initialSkinName = skin;
        skeleton.Initialize(true);
        skeleton.AnimationState.SetAnimation(0, "Idle", true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CarPolice"))
        {
            StartCoroutine(StartBeHitted());
        }

        if (collision.gameObject.CompareTag("LimitScene"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator StartBeHitted()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        float eslapsed = 0;
        float seconds = timeBeHitted/5;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            float newValue = 1 - eslapsed / seconds;
            newValue = newValue < 0 ? 0 : newValue;
            skeleton.Skeleton.A = newValue;
            yield return new WaitForEndOfFrame();
        }
        skeleton.Skeleton.A = 0;

        eslapsed = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            float newValue = eslapsed / seconds;
            newValue = newValue > 1 ? 1 : newValue;
            skeleton.Skeleton.A = newValue;
            yield return new WaitForEndOfFrame();
        }
        skeleton.Skeleton.A = 1;

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            float newValue = 1 - eslapsed / seconds;
            newValue = newValue < 0 ? 0 : newValue;
            skeleton.Skeleton.A = newValue;
            yield return new WaitForEndOfFrame();
        }
        skeleton.Skeleton.A = 0;

        eslapsed = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            float newValue = eslapsed / seconds;
            newValue = newValue > 1 ? 1 : newValue;
            skeleton.Skeleton.A = newValue;
            yield return new WaitForEndOfFrame();
        }
        skeleton.Skeleton.A = 1;

        eslapsed = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            float newValue = 1 - eslapsed / seconds;
            newValue = newValue < 0 ? 0 : newValue;
            skeleton.Skeleton.A = newValue;
            yield return new WaitForEndOfFrame();
        }
        skeleton.Skeleton.A = 0;
        Destroy(gameObject);
    }

    protected void EndGame()
    {
        rigid.velocity = Vector2.zero;
        if (transform.position.x >= Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect + 2f)
        {
            Destroy(gameObject);
        }
    }
}
