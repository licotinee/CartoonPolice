using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorPrison_Scene26 : Singleton<DoorPrison_Scene26>
{
    private Vector3 start;
    private Vector3 end;
    [SerializeField] Transform endPos;
    private bool isCloseDoor;

    [SerializeField] float timeDelayHint;
    [SerializeField] GameObject rattle;
    private bool isCanClick;



    public void Play()
    {
        isCanClick = true;
        StartCoroutine(nameof(StartHint));
    }

    private void OnMouseDrag()
    {
        if (isCanClick)
        {
            end = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (start != Vector3.zero)
            {
                if (end.x - start.x < 0)
                {
                    if (!isCloseDoor)
                    {

                        StartCoroutine(StartCloseDoor());
                    }
                }
            }
            start = end;
        }


    }



    private void OnMouseUp()
    {
        start = Vector3.zero;
    }

    IEnumerator StartCloseDoor()
    {
        StopCoroutine(nameof(StartHint));
        isCloseDoor = true;
        SoundManager.Instance.PlaySFX(SoundTag.Eff_close_door);
        float eslapsed = 0;
        float seconds = 0.5f;
        Vector3 start = transform.position;
        Vector3 end = endPos.position;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        rattle.gameObject.SetActive(true);
        //SoundManager.Instance.PlaySFXOneShot(SoundTag.Eff_witch_jail);
        yield return new WaitForSeconds(0.5f);

        GameScenePrisionManager.ins.ActiveEndScene();
    }

    IEnumerator StartHint()
    {

        while (true)
        {
            yield return new WaitForSeconds(timeDelayHint);
            SoundManager.Instance.PlaySfxLoop(SoundTag.Eff_jail_guild);
            Vector3 start = this.transform.position;
            Vector3 end = new Vector3(this.transform.position.x-1f, this.transform.position.y, this.transform.position.z);
            this.transform.DOMove(end, 0.5f).OnComplete(() =>
            {
                this.transform.DOMove(start, 0.5f);
            });

        }

    }
}
