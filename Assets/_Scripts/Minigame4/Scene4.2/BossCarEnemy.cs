using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossCarEnemy : CarEnemy_Scene2_4
{
    [SerializeField] float speedBoss;
    public delegate void EBossCarShooted();
    public static event EBossCarShooted eBossCarShooted;
    private void OnEnable()
    {
        rigid.velocity = new Vector2(speedBoss, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BossShoot"))
        {
            SpeedGun_Scene2_4.gunShootRay?.Invoke(posCenter.transform);
            eBossCarShooted?.Invoke();
        }
    }
}
