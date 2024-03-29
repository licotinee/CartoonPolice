using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Scene5_2 : MonoBehaviour
{
    [SerializeField] Transform headGun;
    [SerializeField] float timeShooting;
    [SerializeField] float maxRotateShooting;
    [SerializeField] RayGun_Scene5_2 rayGun;
    [SerializeField] float timeDelayEndGame;
    public bool isRightGun;
    bool isShooting;
    [SerializeField] Bullet_Scene5_2 bullet;
    Vector3 posMouse;
    Vector3 abovePos;
    Vector3 underPos;
    bool isBeAttacked;
    bool isReady;

    public delegate void StopShoot();
    public static event StopShoot stopShoot;

    private void Awake()
    {
        abovePos = transform.position;
        underPos = abovePos - new Vector3(0, Camera.main.orthographicSize, 0);

        // Start Game
        StartCoroutine(StartNewTurn(0.5f));
    }

    private void OnEnable()
    {
        Criminal_Scene5_2.criminalAttack += BeAttacked;
        GameScene25Manager.startTurn += NewTurn;
        GameScene25Manager.endGame += EndGame;

    }
    private void Update()
    {
        CheckShoot();
    }

    private void CheckShoot()
    {
        if (Input.GetMouseButtonDown(0) && !isBeAttacked && isReady)
        {
            posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (((posMouse.x >= 0 && !isRightGun) || (posMouse.x < 0 && isRightGun)) && !isShooting)
            {
                Shooting(posMouse);
            }
        }
    }

    private void Shooting(Vector3 goalPos)
    {
        StartCoroutine(StartShooting((isRightGun ? 1 : -1), goalPos));
    }

    IEnumerator StartShooting(int isRight, Vector3 goalPos)
    {
        Quaternion rayQuater = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, 0);
        RayGun_Scene5_2 newRay = Instantiate(rayGun, headGun.position, rayQuater, transform);
        newRay.Fade(timeShooting);

        Bullet_Scene5_2 newBullet = Instantiate(bullet, headGun.position, Quaternion.identity);
        newBullet.ShootIntoGoalPos(timeShooting, goalPos, isRight);

        isShooting = true;
        float eslapsed = 0;
        float seconds = timeShooting/2;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, maxRotateShooting * eslapsed/seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, maxRotateShooting);

        eslapsed = 0;

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, maxRotateShooting *(1- eslapsed / seconds));
            yield return new WaitForEndOfFrame();
        }
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        isShooting = false;
    }

    public void BeAttacked()
    {
        StopAllCoroutines();
        StartCoroutine(nameof(StartMoveDown));
    }

    IEnumerator StartMoveDown()
    {
        isBeAttacked = true;
        float eslapsed = 0;
        float seconds = 0.5f;
        Vector3 start = abovePos;
        Vector3 end = underPos;
        transform.position = start;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed/seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    }

    private void NewTurn(float timeStartTurn)
    {
        StartCoroutine(nameof(StartNewTurn), timeStartTurn);
    }
    IEnumerator StartNewTurn(float timeStartTurn)
    {
        isBeAttacked = false;
        isReady = false;
        isShooting = false;
        float eslapsed = 0;
        float seconds = timeStartTurn;
        Vector3 start = underPos;
        Vector3 end = abovePos;
        transform.position = start;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        isReady = true;
    }

    private void EndGame(float timeEndGame)
    {
        StartCoroutine (nameof(StartEndGame), timeEndGame);  
    }

    IEnumerator StartEndGame(float timeEndGame)
    {
        float eslapsed = 0;
        if (isRightGun)
        {
            yield return new WaitForSeconds(timeShooting/2);
        }
        while (eslapsed <= timeEndGame)
        {
            Shooting(GameScene25Manager.ins.criminal.headPos.position);
            yield return new WaitForSeconds(timeShooting);
            eslapsed += timeShooting;
        }
        if (isRightGun)
        {
            stopShoot?.Invoke();
        }
    }
}
