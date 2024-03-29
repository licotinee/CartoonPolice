using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Criminal_Scene5_1 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    [SerializeField] List<Transform> posMove;
    [SerializeField] float timeRandomMove;
    [SerializeField] SpawnStolen spawnStolen;
    [SerializeField] Transform posSpawn;
    [SerializeField] Transform posOnRoad;
    Vector3 posObsacle;
    Vector3 curPos;
    public bool isSmiling;

    private void Awake()
    {
        transform.position = new Vector3(Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - 2f, transform.position.y, transform.position.z);
        posObsacle = Vector3.zero;
        GameScene15Manager.ins.criminal = this;
    }

    public void MoveToPosStartSpawn(float seconds)
    {
        StartCoroutine(StartMoveToPosStartSpawn(seconds));
    }
    IEnumerator StartMoveToPosStartSpawn(float seconds)
    {
        skeleton.AnimationState.SetAnimation(0, "Run_c", true);
        Vector3 start = transform.position;
        Vector3 end = new Vector3(Camera.main.transform.position.x, transform.position.y, transform.position.z);

        float eslapsed = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed/seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        Move();
    }

    public void Move()
    {
        StartCoroutine(nameof(StartRandomMove));
    }

    int cntDirectionMove;
    float directY;
    public float newY;  
    IEnumerator StartRandomMove()
    {
        skeleton.AnimationState.SetAnimation(0, "Run_c", true);
        transform.eulerAngles = new Vector3(0, 0, 0);

        while (!GameScene15Manager.ins.isEndGame)
        {
            if (posObsacle == Vector3.zero) // No obsalce new criminal
            {
                directY = Random.Range(0, 2);
                if ((directY == 0) && cntDirectionMove > -1)
                {
                    cntDirectionMove -= 1;

                }

                if ((directY == 1) && cntDirectionMove < 1)
                {
                    cntDirectionMove += 1;
                }
                newY = posMove[cntDirectionMove + 1].position.y;
            }
            else
            {
                int tmp = 0;
                if (Mathf.Abs(posObsacle.y - posMove[tmp].position.y) >= 0.05f &&  tmp != (cntDirectionMove + 1))
                {
                    newY = posMove[tmp].position.y;
                    cntDirectionMove = tmp - 1;
                }
            }

            float eslapsed = 0;
            float seconds = 0.25f;
            float start = transform.position.y;
            float end = newY;
            float posY;
            while (eslapsed <= seconds)
            {
                if (!isSmiling)
                {
                    eslapsed += Time.deltaTime;
                }
                posY = start + (end - start) * eslapsed / seconds;
                transform.position = new Vector3(transform.position.x, posY, transform.position.z);

                yield return new WaitForEndOfFrame();
            }
            transform.position = new Vector3(transform.position.x, end, transform.position.z);

            if (!GameScene15Manager.ins.isStopSpawn)
            {
                FallStolen();
            }

            // delay
            yield return new WaitForSeconds(timeRandomMove);
        }
        
    }

    public void RunAgain()
    {
        isSmiling = false;
        skeleton.AnimationState.SetAnimation(0, "Run_c", true);
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obsacle"))
        {
            posObsacle = collision.transform.position;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obsacle"))
        {
            posObsacle = Vector3.zero;
        }
    }

    public void MoveToStartScene(float seconds)
    {
        StartCoroutine(StartMoveToStartScene(seconds));
    }

    IEnumerator StartMoveToStartScene(float seconds)
    {
        float start = transform.position.x;
        float end = Camera.main.transform.position.x + 3f / 5 * Camera.main.orthographicSize * Camera.main.aspect;

        float eslapsed = 0;
        float posX;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            posX = start + (end - start) * eslapsed / seconds;
            transform.position = new Vector3(posX, transform.position.y, transform.position.z);
            yield return new WaitForEndOfFrame();
        }
        transform.position = new Vector3(end, transform.position.y, transform.position.z);

    }
    
    private void FallStolen()
    {
        StartCoroutine(nameof(StartFallStolen));
    }

    IEnumerator StartFallStolen()
    {
        yield return new WaitForSeconds(0.1f);
        Vector3 start = posSpawn.position;
        Vector3 end = posOnRoad.position;
        spawnStolen.Spawn(start, end);
    }

    public void Smiling()
    {
        isSmiling = true;
        transform.eulerAngles = new Vector3(0, 180, 0);
        skeleton.AnimationState.SetAnimation(0, "Laugn", true);
        
    }

    public void EndGame(float seconds)
    {
        StartCoroutine(StartEndGame(seconds));
    }

    IEnumerator StartEndGame(float seconds)
    {
        skeleton.AnimationState.SetAnimation(0, "Walk_Prisoner", true);

        float eslasped = 0;
        Vector3 start = transform.position;
        Vector3 end = new Vector3(Camera.main.transform.position.x, posMove[1].position.y, transform.position.z);
        while (eslasped <= seconds)
        {
            eslasped += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslasped / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        skeleton.AnimationState.SetAnimation(0, "Scare", true);

    }
}
