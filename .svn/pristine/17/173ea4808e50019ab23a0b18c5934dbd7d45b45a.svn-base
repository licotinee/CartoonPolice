using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Police_SceneBank : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] SkeletonAnimation skeleton;
    [SerializeField] public Transform limitPosXCanShot;
    public bool isShooting;
    public bool isBeShooted;
    [SerializeField] float timeDelay;
    [SerializeField] float timeShooting;
    [SerializeField] float timeBeShooted;
    [SerializeField] Transform posGun;
    [SerializeField] public Transform posHeadPolice;
    public delegate void CanBeShooted();
    public static event CanBeShooted canBeShooted;
    private bool isEndGame;
    private void Start()
    {
        skeleton.AnimationState.SetAnimation(0, "Sit_Hide", true);
        GameScene24Manager.ins.endScene += EndScene;
    }

    private void Update()
    {
        CheckShot();
    }

    private void CheckShot()
    {
        if (Input.GetMouseButtonDown(0) && !isShooting && !isBeShooted && !isEndGame)
        {
            Vector3 goalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(goalPosition.x > limitPosXCanShot.position.x && goalPosition.y > transform.position.y)
            { 
                Shooting(goalPosition);
            }
        }
    }

    private void Shooting(Vector3 goalPosition)
    {
        StartCoroutine(StartShooting(goalPosition));
    }

    IEnumerator StartShooting(Vector3 goalPosition)
    {
        GameObject bulletShoot = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletShoot.GetComponent<Bullet>().ShotToGoal(goalPosition);
        bulletShoot.GetComponent<Bullet>().isOfPolice = true;
        isShooting = true;
        skeleton.AnimationState.SetAnimation(0, "Shooting2", false).Complete += Police_SceneBank_Complete;
        yield return new WaitForSeconds(timeDelay);
        canBeShooted?.Invoke();     
    }

    private void Police_SceneBank_Complete(Spine.TrackEntry trackEntry)
    {
        if (!isBeShooted)
        {
            skeleton.AnimationState.SetAnimation(0, "Sit_Hide", true);
        }
        isShooting = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (!collision.gameObject.GetComponent<Bullet>().isOfPolice)
            {
                beShooted();
            }
        }
    }

    private void beShooted()
    {
        StopCoroutine(nameof(InTimeBeShooted));
        StartCoroutine(nameof(InTimeBeShooted));
    }

    IEnumerator InTimeBeShooted()
    {
        isBeShooted = true;
        skeleton.AnimationState.SetAnimation(0, "Hit", false);
        yield return new WaitForSeconds(timeBeShooted);
        isBeShooted = false;
        isShooting = false; // co the ko chay xong ham complete shooting => reset
        
        
        skeleton.AnimationState.SetAnimation(0, "Sit_Hide", true);

    }

    private void EndScene()
    {
        isEndGame = true;
        StopAllCoroutines();
        skeleton.AnimationState.SetAnimation(0, "Jump_Win", true);
    }
}
