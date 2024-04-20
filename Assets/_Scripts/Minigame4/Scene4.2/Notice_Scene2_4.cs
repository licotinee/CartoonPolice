using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notice_Scene2_4 : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite normalNotice;
    [SerializeField] Sprite fastNotice;
    [SerializeField] Sprite bossNotice;
    [SerializeField] float timeNotice;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        CarEnemy_Scene2_4.carEnemyShooted += Notice;
        BossCarEnemy.eBossCarShooted += NoticeTheBoss;

    }
    private void OnDestroy()
    {
        CarEnemy_Scene2_4.carEnemyShooted -= Notice;
        BossCarEnemy.eBossCarShooted -= NoticeTheBoss;


    }
    private void Notice(bool isMoveFast)
    {
        StopCoroutine(nameof(StartNotice)); 
        StartCoroutine(nameof(StartNotice), isMoveFast); 
    }
    IEnumerator StartNotice(bool isMoveFast)
    {
        SoundTag tagNotice = isMoveFast ? SoundTag.Eff_fail_01 : SoundTag.Eff_success_02;
        SoundManager.Instance.PlaySFXOneShot(tagNotice);
        spriteRenderer.sprite = (isMoveFast ? fastNotice : normalNotice);
        animator.Play("FreeNotice");
        animator.Play("StartNotice");
        yield return new WaitForSeconds(timeNotice);
        animator.Play("StopNotice");
    }

    private void NoticeTheBoss()
    {
        StopCoroutine(nameof(StartNotice));
        StartCoroutine(StartNoticeTheBoss());
    }

    IEnumerator StartNoticeTheBoss()
    {
        spriteRenderer.sprite = bossNotice;
        SoundManager.Instance.PlaySFXOneShot(SoundTag.Eff_fail_01);
        animator.Play("FreeNotice");
        animator.Play("StartNotice");
        yield return new WaitForSeconds(timeNotice);
        animator.Play("StopNotice");
    }
}
