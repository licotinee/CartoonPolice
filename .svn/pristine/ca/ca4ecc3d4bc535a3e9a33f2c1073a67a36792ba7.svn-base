using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class Wolfoo_Scene5_1 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    [SerializeField] List<Transform> posMove;
    bool isBeHitted;
    void Awake()
    {
        transform.position = new Vector3(Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - 2f, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        Move();
    }

    public void RunAgain()
    {
        isBeHitted = false;
        skeleton.AnimationState.SetAnimation(0, "Run_Ninja2", true);
    }

    public void MoveToStartScene(float seconds)
    {
        StartCoroutine(StartMoveToPosStartScene(seconds));
    }

    IEnumerator StartMoveToPosStartScene(float seconds)
    {
        Vector3 start = transform.position;
        Vector3 end = new Vector3(Camera.main.transform.position.x - 4f/5 * Camera.main.orthographicSize * Camera.main.aspect, transform.position.y, transform.position.z);

        float eslapsed = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed/seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        skeleton.AnimationState.SetAnimation(0, "Run_Ninja", true);

    }

    float directY;
    float startMouse;
    float endMouse;
    int cntDirectionMove;
    bool isMoving;
    float newY;
    private void Move()
    {
        if (GameScene15Manager.ins.isStartGame && !isBeHitted && !GameScene15Manager.ins.isEndGame)
        {
            if (Input.GetMouseButton(0) && !isMoving)
            {
                endMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
                directY = (startMouse != 0 ? endMouse - startMouse : 0);
                startMouse = endMouse;
                if (directY != 0)
                {
                    if ((directY < 0) && !isMoving && cntDirectionMove > -1)
                    {
                        cntDirectionMove -= 1;
                    }

                    if ((directY > 0) && !isMoving && cntDirectionMove < 1)
                    {
                        cntDirectionMove += 1;
                    }
                    newY = posMove[cntDirectionMove + 1].position.y;
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

        isMoving = true;
        while (eslapsed <= seconds) 
        {
            eslapsed += Time.deltaTime;
            posY = start + (end - start) * eslapsed/seconds;
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);
            yield return new WaitForEndOfFrame();
        }
        transform.position = new Vector3(transform.position.x, end, transform.position.z);
        yield return new WaitForSeconds(0.1f);
        isMoving = false;
        startMouse = endMouse = 0;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obsacle"))
        {
            BeHitted();
        }
    }

    private void BeHitted()
    {
        isBeHitted = true;
        skeleton.AnimationState.SetAnimation(0, "Crying", true);
        GameScene15Manager.ins.WolfooBeHitted();
    }

    public void EndGame(float seconds)
    {
        StartCoroutine(StartEndGame(seconds));
    }

    IEnumerator StartEndGame(float seconds)
    {
        skeleton.AnimationState.SetAnimation(0, "Run_Ninja2", true);

        float eslasped = 0;
        Vector3 start = transform.position;
        Vector3 end = new Vector3(Camera.main.transform.position.x - 2f, posMove[1].position.y, transform.position.z);
        while (eslasped <= seconds)
        {
            eslasped += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslasped/seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        skeleton.AnimationState.SetAnimation(0, "Cheer", true);

    }
}
