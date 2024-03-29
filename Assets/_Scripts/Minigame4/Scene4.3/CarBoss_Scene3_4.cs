using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarBoss_Scene3_4 : CarEnemy_Scene3_4
{
    [SerializeField] List<Transform> posCar;
    [SerializeField] float timeDelayRandomMove;
    [SerializeField] Radar radar;
    [SerializeField] float speedTired;
    Animator animator;
    private new void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        transform.position = new Vector3(-Camera.main.orthographicSize * Camera.main.aspect - 2.5f, transform.position.y, transform.position.z);
        StartCoroutine(StartMoveToStartPos());
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        GameScene43Manager.ePrepareEndGame += PrepareEndGame;

    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        GameScene43Manager.ePrepareEndGame -= PrepareEndGame;
    }

    IEnumerator StartMoveToStartPos()
    {
        float eslapsed = 0;
        float seconds = 2f;
        Vector3 start = transform.position;
        Vector3 end = new Vector3(3f / 5 * Camera.main.orthographicSize * Camera.main.aspect, transform.position.y, transform.position.z);
        skeleton.AnimationState.SetAnimation(0, "Idle", true);

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }

        transform.position = end;
        RanDomMove();
    }

    private void RanDomMove()
    {
        StartCoroutine(nameof(StartRanDomMove));
    }

    IEnumerator StartRanDomMove()
    {
        List<Transform> posCantMove = new List<Transform>();
        List<Transform> posCanMove = new List<Transform>();
        int ranMoveY;
        while (true)
        {
            yield return new WaitForSeconds(timeDelayRandomMove);
            posCantMove = radar.GetCarsInRadar();
            for (int i = 0; i < posCar.Count; ++i)
            {
                int cnt = 0;
                for (int j = 0; j < posCantMove.Count; ++j)
                {
                    if (posCar[i].position.y != posCantMove[j].position.y)
                    {
                        cnt++;
                    }
                }
                if (cnt == posCantMove.Count)
                {
                    posCanMove.Add(posCar[i]);
                }
            }
            if (posCanMove.Count != 0)
            {
                ranMoveY = Random.Range(0, posCanMove.Count);
                float newY = posCanMove[ranMoveY].position.y;
                StartCoroutine(StartMove(newY));
                posCanMove.Clear();
            }
        }

        IEnumerator StartMove(float newY)
        {
            float eslapsed = 0;
            float seconds = 0.25f;
            float start = transform.position.y;
            float end = newY;
            float posY;

            if (newY > start)
            {
                animator.Play("CarMoveYUp");
            }
            else if(newY < start)
            {
                animator.Play("CarMoveYDown");
            }

            while (eslapsed <= seconds)
            {
                eslapsed += Time.deltaTime;
                posY = start + (end - start) * eslapsed / seconds;
                transform.position = new Vector3(transform.position.x, posY, transform.position.z);
                yield return new WaitForEndOfFrame();
            }
            transform.position = new Vector3(transform.position.x, end, transform.position.z);
            animator.Rebind();
            animator.Update(0f);
        } 

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CarPolice"))
        {
            StopAllCoroutines();
            StartCoroutine(StartEndGame());
        }
    }

    IEnumerator StartEndGame()
    {
        animator.Rebind();
        animator.Update(0f);
        animator.enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        float eslapsed = 0;
        float seconds = 2f;
        float maxDist = 4f;
        float maxRotate = 60;
        Vector3 start = transform.position;
        Vector3 end = start + new Vector3(maxDist, 0, 0);

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed/seconds);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, eslapsed/seconds * maxRotate);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, maxRotate);

    }

    private void PrepareEndGame()
    {
        StartCoroutine(StartPrepareEndGame());
    }

    IEnumerator StartPrepareEndGame()
    {
        yield return new WaitForSeconds(12f);
        speed = speedTired;
        StopCoroutine(nameof(StartRanDomMove));
    }
}
