using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnClickManager : MonoBehaviour
{
    
    [SerializeField] List<ClickIllegal> ListBanned;
    int cntTrueClick;
    [SerializeField] float timeDelayHint;
    [SerializeField] Image barBanned;
    [SerializeField] Image suitcase;

    private void OnEnable()
    {
        StartCoroutine(nameof(StartEnable));
        StartCoroutine(nameof(RandomHint));
    }

    IEnumerator StartEnable()
    {
        // Move Bar Banned
        Vector3 end = barBanned.transform.position;
        Vector3 start = end - new Vector3(Camera.main.orthographicSize * Camera.main.aspect, 0, 0);
        barBanned.transform.position = start;

        float maxDist = end.x - start.x;
        float curDist;

        //Enlarge suitcase
        float endScale = suitcase.transform.localScale.x;
        suitcase.transform.localScale = Vector3.zero;

        float eslasped = 0;
        float seconds = 0.4f;
        while (eslasped <= seconds)
        {
            eslasped += Time.deltaTime;
            barBanned.transform.position = Vector3.Lerp(start, end, eslasped / seconds);

            curDist = end.x - barBanned.transform.position.x;
            suitcase.transform.localScale = new Vector3 ((1 - curDist / maxDist) * endScale, (1 - curDist / maxDist) * endScale, (1 - curDist / maxDist) * endScale);
            yield return new WaitForEndOfFrame();
        }
        barBanned.transform.position = end;
        suitcase.transform.localEulerAngles = new Vector3(endScale, endScale, endScale);
    }

    IEnumerator RandomHint()
    {
        while (ListBanned.Count != 0)
        {
            yield return new WaitForSeconds(timeDelayHint);
            int ran = Random.Range(0, ListBanned.Count);
            float startScale = ListBanned[ran].normalScale;
            float maxScale = startScale * 1.2f;

            float speed = 0.7f;
            // first
            while (ListBanned[ran].transform.localScale.x <= maxScale)
            {
                ListBanned[ran].transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            ListBanned[ran].transform.localScale = new Vector3(maxScale, maxScale, maxScale);

            while (ListBanned[ran].transform.localScale.x >= startScale)
            {
                ListBanned[ran].transform.localScale -= new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            ListBanned[ran].transform.localScale = new Vector3(startScale, startScale, startScale);

            // second
            while (ListBanned[ran].transform.localScale.x <= maxScale)
            {
                ListBanned[ran].transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            ListBanned[ran].transform.localScale = new Vector3(maxScale, maxScale, maxScale);

            while (ListBanned[ran].transform.localScale.x >= startScale)
            {
                ListBanned[ran].transform.localScale -= new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            ListBanned[ran].transform.localScale = new Vector3(startScale, startScale, startScale);
        }

    }

    private void RemoveBanned(ClickIllegal beClicked)
    {
        StopCoroutine(nameof(RandomHint));
        ListBanned.Remove(beClicked);
        StartCoroutine(nameof(RandomHint));
    }

    public void UpdateTrueClick(ClickIllegal beClicked)
    {
        RemoveBanned(beClicked);
        cntTrueClick++;
        if (cntTrueClick == 3)
        {
            StartCoroutine(nameof(StartDisable));
        }
    }

    IEnumerator StartDisable()
    {
        yield return new WaitForSeconds(0.3f);

        // Move Bar Banned
        Vector3 start = barBanned.transform.position;
        Vector3 end = start - new Vector3(Camera.main.orthographicSize * Camera.main.aspect, 0, 0);

        float maxDist = start.x - end.x;
        float curDist;

        //Enlarge suitcase

        float eslasped = 0;
        float seconds = 0.4f;
        while (eslasped <= seconds)
        {
            eslasped += Time.deltaTime;
            barBanned.transform.position = Vector3.Lerp(start, end, eslasped / seconds);

            curDist = barBanned.transform.position.x - end.x;
            suitcase.transform.localScale = new Vector3 (curDist/ maxDist, curDist / maxDist, curDist / maxDist);
            yield return new WaitForEndOfFrame();
        }
        barBanned.transform.position = end;
        suitcase.transform.localEulerAngles = Vector3.zero;

        //Update Turn
        cntTrueClick = 0;
        GameScene71Manager.ins.UpdateTurn();
    }

} 
