using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using System;

public class WolfooMinigame6 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;

    Rigidbody2D rigid;
    private float speed;
    [SerializeField] private float speedNormal;
    [SerializeField] private float forceJump;
    bool isOnGround;

    //System check falling down pit
    private float hightYonGround;
    public bool isFallingDown;
    bool isJumpingUp;

    // system check on ground
    RaycastHit2D rayLeft;
    RaycastHit2D rayRight;
    RaycastHit2D rayHorizontal;


    // BeHitted
    private bool isHitted;
    [SerializeField] private float timeBeHitted;

    [SerializeField] Transform PosRayLeft;
    [SerializeField] Transform PosRayRight;
    [SerializeField] private LayerMask layer;
    private float lengthRay = 0.2f;

    //boost
    public bool isBoosting;
    [SerializeField] private float speedBoost;
    [SerializeField] private float timeBoost;

    //end
    public Vector3 startPos;
    public Vector3 endPos;

    public delegate void ECatchUpWith();
    public static event ECatchUpWith eCatchUpWith;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        hightYonGround = transform.position.y;
        startPos = new Vector3(Camera.main.transform.position.x - 2f/3 * Camera.main.orthographicSize * Camera.main.aspect, transform.position.y, transform.position.z);
        endPos = new Vector3(GameScene62Manager.ins.endPos.position.x - 2f, transform.position.y, transform.position.z);
        StartCoroutine(StartMoveToStartGame());
    }

    private void Update()
    {
        Move();
        Jump();
        CheckFallOnPit();
    }
    IEnumerator StartMoveToStartGame()
    {
        rigid.velocity = Vector2.zero;
        transform.position = new Vector3(Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - 7f, transform.position.y, transform.position.z);
        skeleton.AnimationState.SetAnimation(0, "Run_Pointing", true);

        float eslapsed = 0;
        float seconds = 2.5f;
        Vector3 start = transform.position;
        Vector3 end = startPos;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed/seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        skeleton.AnimationState.SetAnimation(0, "Run_Ninja", true);

        GameScene62Manager.ins.StartGame();
    }
    bool CheckOnGround()
    {
        rayLeft = Physics2D.Raycast(PosRayLeft.position, Vector2.down, lengthRay, layer);
        rayRight = Physics2D.Raycast(PosRayRight.position, Vector2.down, lengthRay, layer);
        if (rayLeft || rayRight) return true;
        return false;
    }

    bool CheckNearOb()
    {
        rayHorizontal = Physics2D.Raycast(PosRayRight.position, Vector2.right, lengthRay, layer);
        if (rayHorizontal) return true;
        return false;
    }

    private void Jump()
    {
        if (Input.GetMouseButtonDown(0) && !isHitted && GameScene62Manager.ins.isStartGame && !GameScene62Manager.ins.isEndGame &&!isJumpingUp)
        {
            if (CheckOnGround())
            {
                rigid.AddForce(Vector2.up * forceJump);
                skeleton.AnimationState.SetAnimation(0, "Jump_Hight", false);
            }
        }
    }

    private void Move()
    {
        if (GameScene62Manager.ins.isStartGame)
        {
            if (!isHitted && !isFallingDown && !isJumpingUp)
            {
                if (!isBoosting)
                {
                    speed = speedNormal;
                }
                if (isBoosting)
                {
                    speed = speedBoost;
                    if (transform.position.y <= hightYonGround)
                    {
                        transform.position = new Vector3(transform.position.x, hightYonGround + 0.05f, transform.position.z);
                        rigid.velocity = new Vector2(speed, 0);
                    }
                }
            }
            else
            {
                speed = 0;
            }
            if (!CheckNearOb() && !GameScene62Manager.ins.isEndGame) rigid.velocity = new Vector2(speed, rigid.velocity.y);
            SetAnimRun();
        }
        
    }

    private void SetAnimRun()
    {
        if (transform.position.y - hightYonGround >= 0.1f && rigid.velocity.y < 0 && !isHitted && !GameScene62Manager.ins.isEndGame)
        {
            skeleton.AnimationState.SetAnimation(0, "Run_Ninja", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obsacle"))
        {
            RaycastHit2D rayCheck = Physics2D.Raycast(PosRayRight.position, Vector2.right, lengthRay, layer);
            if (rayCheck)
            {
                if (!isBoosting)
                {
                    collision.gameObject.GetComponent<Collider2D>().enabled = false;
                    Hitted();
                }
            }
        }

        if (collision.gameObject.CompareTag("Pit"))
        {
            //transform.position = new Vector3(collision.transform.position.x, transform.position.y, transform.position.z);
            float sizePit = collision.collider.bounds.size.x / 2;
            JumpBack(sizePit);
        }

        if (collision.gameObject.CompareTag("Buff"))
        {
            StartCoroutine(nameof(StartBoost));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LimitScene"))
        {
            if (!GameScene62Manager.ins.isEndGame)
            {
                GameScene62Manager.ins.isEndGame = true;
                StartCoroutine(nameof(StartMoveToRihino));
            }
        }
    }

    IEnumerator StartBoost()
    {
        isBoosting = true;
        float eslapsed = 0;
        float seconds = timeBoost;
        float lengthCheckBoost = 0.5f;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            RaycastHit2D rayCheck = Physics2D.Raycast(PosRayRight.position, Vector2.right, lengthCheckBoost, layer);
            if (rayCheck)
            {
                if (rayCheck.collider.gameObject.CompareTag("Obsacle"))
                {
                    rayCheck.collider.gameObject.GetComponent<ObsacleMinigame6>().Fly();
                }
            }

            yield return new WaitForEndOfFrame();
        }
        isBoosting = false;
    }

    private void JumpBack(float sizePit)
    {
        StartCoroutine(nameof(StartJumpBack), sizePit);
    }

    IEnumerator StartJumpBack(float sizePit)
    {
        yield return new WaitForSeconds(1.5f);
        Vector2 oldPos = transform.position;
        Vector2 newPos = new Vector3(transform.position.x + sizePit, hightYonGround + 0.5f, 0);
        float eslapsed = 0;
        float seconds = 0.75f;
        isFallingDown = false;
        isJumpingUp = true;
        skeleton.AnimationState.SetAnimation(0, "Jump_Hight", false);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector2.Lerp(oldPos, newPos, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = newPos;
        isJumpingUp = false;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    private void Hitted()
    {
        StartCoroutine(nameof(StartBeHitted));
    }

    IEnumerator StartBeHitted()
    {
        isHitted = true;
        skeleton.AnimationState.SetAnimation(0, "Surprise_Idle", true);
        yield return new WaitForSeconds(timeBeHitted);
        skeleton.AnimationState.SetAnimation(0, "Run_Ninja", true);
        isHitted = false;
    }

    private void CheckFallOnPit()
    {
        if ((transform.position.y <= hightYonGround - 1f) && !isFallingDown && !isJumpingUp)
        {
            isFallingDown = true;
        }
    }
    IEnumerator StartMoveToRihino()
    {
        rigid.velocity = Vector2.zero;
        Vector3 end = endPos;
        
        while (Vector2.Distance(transform.position, end) > 0.2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, end, speedNormal * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        skeleton.AnimationState.SetAnimation(0, "Cheer", true);
        eCatchUpWith?.Invoke();
        GameScene62Manager.ins.EndGame();
    }
}
