using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Criminal_Scene5_2 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    Vector3 startPos;
    Vector3 endPos;
    private float eslapsed = 0;
    [SerializeField] float timeMove;
    [SerializeField] float startScale;
    [SerializeField] float endScale;
    [SerializeField] Transform end;
    [SerializeField] float rateAttack;
    [SerializeField] bool isAttacking;
    [SerializeField] float minDistBeAttacked;
    [SerializeField] float timeBeAttacked;
    [SerializeField] float timeDecreaseWhenBeAttacked;
    [SerializeField] private int madBullet;
    [SerializeField] BgAttack_Scene5_2 bgAttack;
    [SerializeField] float timeAttack;
    [SerializeField] public Transform headPos;
    [SerializeField] List<int> markChangeSkins;
    [SerializeField] SkeletonAnimation boostMad;
    private int curSkin;
    private int cntBullet;
    private int curBullet;
    public delegate void CriminalAttack();
    public static event CriminalAttack criminalAttack;
    GameObject bulletCheck = null;
    private bool isGetMad;

    private void Awake()
    {
        startPos = transform.position;
        endPos = end.position;
        transform.localScale = new Vector3(startScale, startScale, startScale);

        // Start Game
        StartCoroutine(StartNewTurn(0.5f));

    }

    private void OnEnable()
    {
        GameScene25Manager.startTurn += NewTurn;
        Gun_Scene5_2.stopShoot += Surrender;
        Bullet_Scene5_2.bulletBroken += CheckBeShooted;
    }

    IEnumerator StartScaleUp()
    {
        float seconds = timeMove;
        Vector3 start = transform.position;
        Vector3 end = endPos;
        skeleton.AnimationState.SetAnimation(0, "Walk_Angry", true);
        float rate = eslapsed/seconds;
        do
        {
            transform.position = Vector3.Lerp(start, end, rate);
            SetScale(rate);
            eslapsed += Time.deltaTime;
            rate = eslapsed / seconds;
            // sap tan cong
            if (rate >= rateAttack && !isAttacking)
            {
                isAttacking = true;
                criminalAttack?.Invoke();
            }
            yield return new WaitForEndOfFrame();
        } while (eslapsed <= seconds);
        transform.position = end;
        SetScale(1);
        Attack();
        //
    }

    private void SetScale(float rate)
    {
        transform.localScale = new Vector3(startScale + (endScale - startScale) * rate, startScale + (endScale - startScale) * rate, startScale + (endScale - startScale) * rate);
    }

    IEnumerator StartAttack()
    {
        curBullet = 0;
        BgAttack_Scene5_2 newAttack = Instantiate(bgAttack, Vector3.zero, Quaternion.identity);
        newAttack.Enable(timeAttack);
        skeleton.AnimationState.SetAnimation(0, "Attack", false);
        yield return new WaitForSeconds(timeAttack);
        GameScene25Manager.ins.StartNewTurn();

    }
    private void Attack()
    {
        StartCoroutine(StartAttack());

    }

    private void NewTurn(float timeStartTurn)
    {
        StartCoroutine(nameof(StartNewTurn), timeStartTurn);
    }
    IEnumerator StartNewTurn(float timeStartTurn)
    {
        boostMad.gameObject.SetActive(false);

        isAttacking = false;
        eslapsed = 0;
        transform.position = startPos;
        SetScale(0);
        skeleton.AnimationState.SetAnimation(0, "Walk_Angry", true);
        yield return new WaitForSeconds(timeStartTurn);
        isGetMad = false;
        StartCoroutine(nameof(StartScaleUp));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            bulletCheck = collision.gameObject;
        }
        // when bullet broken
/*        if (collision.gameObject.CompareTag("Bullet") && !isGetMad && !GameScene25Manager.ins.isEndGame)
        {   
            BeAttacked();
        }*/

/*        if (GameScene25Manager.ins.isEndGame)
        {
            BeAttackedWhenEndGame();
        }*/
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        bulletCheck = null;

    }
    private void CheckBeShooted(GameObject bullet)
    {
        if (bulletCheck != null)
        {
            if (bulletCheck == bullet)
            {
                if (!isGetMad && !GameScene25Manager.ins.isEndGame)
                {
                    BeAttacked();
                }
                if (GameScene25Manager.ins.isEndGame)
                {
                    BeAttackedWhenEndGame();
                }
            }
        }
    }



    private void BeAttackedWhenEndGame()
    {
        StopAllCoroutines();
        skeleton.AnimationState.SetAnimation(0, "Hit", true);

    }


    private void BeAttacked()
    {
        StopCoroutine(nameof(StartScaleUp));
        StopCoroutine(nameof(StartBeAttacked));
        StartCoroutine(nameof(StartBeAttacked));
    }

    IEnumerator StartBeAttacked()
    {
        StopCoroutine(nameof(StartScaleUp));
        GameScene25Manager.ins.UpdatePoint();
        curBullet++;
        cntBullet++;
        CheckChangeSkin();
        skeleton.AnimationState.SetAnimation(0, "Hit", false);
        if (curBullet == madBullet)
        {
            GetMad();
        }
        eslapsed -= timeDecreaseWhenBeAttacked;
        if (eslapsed <= 0)
        {
            eslapsed = 0;
        }
        transform.position = Vector3.Lerp(startPos, endPos, eslapsed / timeMove);
        SetScale(eslapsed / timeMove);

        yield return new WaitForSeconds(timeBeAttacked);
        StartCoroutine(nameof(StartScaleUp));
    }

    public void GetMad()
    {
        boostMad.gameObject.SetActive(true);
        curBullet = 0;
        StopCoroutine(nameof(StartBeAttacked));
        isGetMad = true;
        StartCoroutine(nameof(StartScaleUp));
    }

    private void Surrender()
    {
        skeleton.AnimationState.SetAnimation(0, "Kneel", true);
    }

    private void CheckChangeSkin()
    {
        if (curSkin < markChangeSkins.Count)
        {
            if (markChangeSkins[curSkin] == cntBullet)
            {
                skeleton.initialSkinName = "Dirty" + curSkin.ToString();
                skeleton.Initialize(true);
                curSkin++;
            }
        }
    }
}
