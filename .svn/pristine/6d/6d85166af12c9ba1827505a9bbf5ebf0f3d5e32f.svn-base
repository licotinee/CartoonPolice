using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBarScene13 : MonoBehaviour
{
    [SerializeField] Image barFill;
    [SerializeField] List<Image> ListStars;
    [SerializeField] List<Sprite> ListcompleteSprites;
    int curStar;
    private void Start()
    {
        StartGame();
    }
    void StartGame()
    {
        StartCoroutine(MoveRight());
    }

    IEnumerator MoveRight()
    {
        Vector3 start = transform.position - new Vector3(Camera.main.orthographicSize * Camera.main.aspect, 0, 0);
        Vector3 end = transform.position;
        float eslapsed = 0f;
        float seconds = 0.5f;

        transform.position = start;
        while(eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    }

    public void UpdateBar(float rate, float seconds)
    {
        StartCoroutine(StartUpDateBar(rate, seconds));
    }

    IEnumerator StartUpDateBar(float rate, float seconds)
    {
        float eslapsed = 0f;
        float start = barFill.fillAmount;
        float end = rate;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            barFill.fillAmount = start + (end - start) * eslapsed / seconds;
            yield return new WaitForEndOfFrame();
        }
        barFill.fillAmount = end;
        StartCoroutine(UpdateStar());
    }

    IEnumerator UpdateStar()
    {
        float eslapsed = 0;
        float seconds = 0.2f;
        float startScale = ListStars[curStar].transform.localScale.x;
        float endScale = 1.2f * startScale;
        ListStars[curStar].sprite = ListcompleteSprites[curStar];
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            ListStars[curStar].transform.localScale = new Vector3(startScale + (eslapsed/seconds) * (endScale - startScale), startScale + (eslapsed / seconds) * (endScale - startScale),
                startScale + (eslapsed / seconds) * (endScale - startScale));
            yield return new WaitForEndOfFrame();
        }
        ListStars[curStar].transform.localScale = new Vector3(startScale, startScale, startScale);
        curStar++;
    }

    public void MoveLeft()
    {
        StartCoroutine(StartMoveLeft());
    }

    IEnumerator StartMoveLeft()
    {
        Vector3 start = transform.position;
        Vector3 end = transform.position - new Vector3(Camera.main.orthographicSize * Camera.main.aspect, 0, 0);
        float eslapsed = 0f;
        float seconds = 0.5f;

        transform.position = start;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    }



}
