using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriminalGun_SceneBank : Criminal_SceneBank
{
    [SerializeField] GameObject bullet;
    [SerializeField] float timeShooting;
    [SerializeField] Transform posGun;
    bool isShooting;
    float limitX;
    Vector3 goalOfBullet;
    private void Start()
    {
        limitX = GameScene24Manager.ins.police.limitPosXCanShot.position.x;
        goalOfBullet = GameScene24Manager.ins.police.posHeadPolice.position;
        skeleton.AnimationState.SetAnimation(0, "Walk_CarryGun", true);
    }

    private void OnEnable()
    {
        Police_SceneBank.canBeShooted += CheckToShoot;
        GameScene24Manager.ins.endScene += EndScene;
    }

    private void OnDestroy()
    {
        Police_SceneBank.canBeShooted -= CheckToShoot;
        GameScene24Manager.ins.endScene += EndScene;
    }

    private void CheckToShoot()
    {
        if (!isBeShooted)
        {
            if (transform.position.x > limitX && transform.position.x < Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect)
            {
                Shooting();
            }
        }
    }

    private void Shooting()
    {
        StartCoroutine(StartShooting());
    }

    IEnumerator StartShooting()
    {
        isShooting = true;
        transform.eulerAngles = new Vector3(0, 0 , 0);
        skeleton.AnimationState.SetAnimation(0, "Attack", true);
        GameObject bulletShoot = Instantiate(bullet, posGun.position, Quaternion.identity);
        bulletShoot.GetComponent<Bullet>().ShotToGoal(goalOfBullet);
        yield return new WaitForSeconds(timeShooting);
        isShooting = false;
        transform.eulerAngles = new Vector3(0, (directX == 0) ? 0 : 180);
        skeleton.AnimationState.SetAnimation(0, "Walk_CarryGun", true);

    }


    protected override void SetAnimGetHurt()
    {
        skeleton.AnimationState.SetAnimation(0, "Sit_GethurGun", true);

    }

    protected override void Move()
    {
        if (!isShooting && !isBeShooted)
        {
            transform.position += new Vector3(directX * speedMove * Time.deltaTime, 0, 0);
            transform.eulerAngles = new Vector3(0, (directX == -1) ? 0 : 180);
        }

    }

}
