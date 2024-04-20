using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarPolice_Scene3_4 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    [SerializeField] float speed;
    [SerializeField] float speedReduce;
    [SerializeField] float timeBeHitted;
    [SerializeField] List<Transform> posCar;
    Rigidbody2D rigid;
    Animator animator;
    private bool isBeHitted;

    Dictionary<int, string> DAnim = new Dictionary<int, string>()
    {
        {1, "Wiggle"},
        {2, "Shake"},
        {3, "Shake"}
    };
    private void Awake()
    {
        transform.position = new Vector3(- Camera.main.orthographicSize * Camera.main.aspect - 3f, transform.position.y, transform.position.z);
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        skeleton.AnimationState.SetAnimation(0, "Idle", true);
        StartCoroutine(StartMoveToStartPos());
    }

    private void OnEnable()
    {
        GameScene43Manager.eEndGame += EndGame;
    }

    private void OnDestroy()
    {
        GameScene43Manager.eEndGame -= EndGame;
    }
    IEnumerator StartMoveToStartPos()
    {
        float eslapsed = 0;
        float seconds = 2f;
        Vector3 start = transform.position;
        Vector3 end = new Vector3(-3f/5 * Camera.main.orthographicSize * Camera.main.aspect, transform.position.y, transform.position.z);

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed/seconds);
            yield return new WaitForEndOfFrame();
        }

        transform.position = end;
        GameScene43Manager.ins.isStartGame = true;
    }

    private void FixedUpdate()
    {
        MoveX();
        MoveY();
    }


    private void MoveX()
    {
        if (GameScene43Manager.ins.isStartGame && !GameScene43Manager.ins.isEndGame)
        {
            if (!isBeHitted)
            {
                rigid.velocity = new Vector2(speed * Time.deltaTime, 0);                    
            }
            else
            {
                rigid.velocity = new Vector2(speedReduce * Time.deltaTime, 0);
            }
        }
    }

    float directY;
    float startMouse;
    float endMouse;
    int cntDirectionMove;
    bool isMoving;
    float newY;
    private void MoveY()
    {
        if (GameScene43Manager.ins.isStartGame && !GameScene43Manager.ins.isEndGame)
        {
            if (Input.GetMouseButton(0) && !isMoving && !isBeHitted)
            {
                endMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
                directY = (startMouse != 0 ? endMouse - startMouse : 0);
                startMouse = endMouse;
                if (directY != 0)
                {
                    if ((directY < 0) && cntDirectionMove > -1)
                    {
                        cntDirectionMove -= 1;
                    }

                    if ((directY > 0) && cntDirectionMove < 1)
                    {
                        cntDirectionMove += 1;
                    }
                    newY = posCar[cntDirectionMove + 1].position.y;
                    StartCoroutine(nameof(StartMove));
                }

            }
            if (Input.GetMouseButtonUp(0))
            {
                startMouse = endMouse = 0;
            }
        }
        
    }

    IEnumerator StartMove()
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
        else
        {
            animator.Play("CarMoveYDown");
        }
        isMoving = true;
        while (eslapsed <= seconds) 
        {
            eslapsed += Time.deltaTime;
            posY = start + (end - start) * eslapsed/seconds;
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);
            yield return new WaitForEndOfFrame();
        }
        transform.position = new Vector3(transform.position.x, end, transform.position.z);
        animator.Rebind();
        animator.Update(0f);
        yield return new WaitForSeconds(0.1f);
        isMoving = false;
        startMouse = endMouse = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            StartCoroutine(StartBeHittedCar());
        }

        if (collision.gameObject.CompareTag("Obsacle"))
        {
            int idObsacle = collision.gameObject.GetComponent<Obsacle_Scene3_4>().GetId();
            StartCoroutine(StartBeHittedObsacle(idObsacle));
        }

        if (collision.gameObject.CompareTag("CarBoss"))
        {
            GameScene43Manager.ins.EndGame();
        }


        if (collision.gameObject.CompareTag("LimitCarBoss"))
        {
            Destroy(collision.gameObject);
            StopAllCoroutines();
            StartCoroutine(StartHitTheCarBoss());
        }
    }

    IEnumerator StartBeHittedCar()
    {
        isBeHitted = true;
        yield return new WaitForSeconds(timeBeHitted);
        isBeHitted = false;
    }

    IEnumerator StartBeHittedObsacle(int idObsacle)
    {
        isBeHitted = true;
        skeleton.AnimationState.SetAnimation(0, DAnim[idObsacle], true);
        yield return new WaitForSeconds(timeBeHitted);
        skeleton.AnimationState.SetAnimation(0, "Idle", true);
        isBeHitted = false;

    }

    IEnumerator StartHitTheCarBoss()
    {
        float eslaped = 0;
        float seconds = 0.5f;
 
        Vector3 end = GameScene43Manager.ins.carBoss.transform.position;
        if (end.y > transform.position.y)
        {
            animator.Play("CarMoveYUp");
        }
        else
        {
            animator.Play("CarMoveYDown");
        }
        while (eslaped <= seconds)
        {
            eslaped += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, end, eslaped/seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        GameScene43Manager.ins.EndGame();

    }
    private void EndGame()
    {
        rigid.velocity = Vector2.zero;
    }

    
}
