using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickIllegal : MonoBehaviour
{
    Button button;
    [SerializeField] Image posInBarBanned;
    bool isClicked;
    public float normalScale;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(BeClicked);
        normalScale = transform.localScale.x;
    }

    void BeClicked()
    {
        if (!isClicked)
        {
            if (gameObject.CompareTag("Banned"))
            {
                StartCoroutine(nameof(MoveToBarBanned));
            }
            else
            {
                StartCoroutine(nameof(Shaking));
            }
        }
    }
    IEnumerator Shaking()
    {
        float startX = transform.position.x;
        isClicked = true;
        transform.position = new Vector3(startX, transform.position.y, transform.position.z);
        float timeShake = 0.3f;
        float eslapsed = 0;
        float speed = 50f;
        float amount = 0.25f;
        while (eslapsed <= timeShake)
        {
            eslapsed += Time.deltaTime;
            transform.position = new Vector3(startX + Mathf.Sin(Time.time * speed) * amount, transform.position.y, transform.position.z);
            yield return new WaitForEndOfFrame();
        }
        transform.position = new Vector3(startX, transform.position.y, transform.position.z);
        isClicked = false;
    }

    IEnumerator MoveToBarBanned()
    {
        transform.SetAsLastSibling();
        isClicked = true;
        Vector3 start = transform.position;
        Vector3 end = posInBarBanned.transform.position;

        float startScale = normalScale * 1.2f;
        transform.localScale = new Vector3(startScale, startScale, startScale);
        float endScale = posInBarBanned.GetComponent<RectTransform>().sizeDelta.x / GetComponent<RectTransform>().sizeDelta.x;

        float curDist;
        float maxDist = Vector2.Distance(start, end);

        float startRotation = transform.eulerAngles.z;
        float endRotation = posInBarBanned.transform.eulerAngles.z;

        float eslapsed = 0;
        float seconds = 0.35f;


        while(eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;

            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            curDist = Vector2.Distance(transform.position, end);

            float curScale = startScale + (endScale - startScale) * (1 - curDist / maxDist);
            transform.localScale = new Vector3(curScale, curScale, curScale);

            float curRotation = startRotation + (endRotation - startRotation) * (1 - curDist / maxDist);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, curRotation);

            yield return new WaitForEndOfFrame();
        }

        transform.position = end;
        transform.localScale = new Vector3(endScale, endScale, endScale);
        transform.eulerAngles = new Vector3(endRotation, endRotation, endRotation);
        transform.SetParent(posInBarBanned.transform.parent);
        transform.SetAsLastSibling();

        TrueTickMinigame7 tick = Instantiate(GameScene71Manager.ins.trueTick, transform.position, Quaternion.identity, posInBarBanned.transform.parent);
        tick.transform.SetAsLastSibling();

        // Update true Click
        GameScene71Manager.ins.curTurnClick.UpdateTrueClick(this);
    }
}
