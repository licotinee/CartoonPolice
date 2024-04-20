using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalseTick : MonoBehaviour
{
    Image falseTick;
    float startScale;
    private void OnEnable()
    {
        startScale = transform.localScale.x;
        falseTick = GetComponent<Image>();
    }

    public void Enable(float seconds)
    {
        StartCoroutine(StartEnable(seconds));
    }

    IEnumerator StartEnable(float seconds)
    {
        transform.localScale = Vector3.zero;
        float eslapsed = 0;
        while (eslapsed <= seconds/2)
        {
            eslapsed += Time.deltaTime;
            transform.localScale = new Vector3(eslapsed/(seconds/2) * startScale, eslapsed / (seconds/2) * startScale, eslapsed / (seconds/2) * startScale);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(startScale, startScale, startScale);
        StartCoroutine(StartShake(seconds / 2));

    }

    IEnumerator StartShake(float seconds) { 
    
        float eslapsed = 0;
        float startRotate = transform.eulerAngles.z;
        float endRotate = 20f;
        while (eslapsed <= 2f / 3 * seconds)
        {
            eslapsed += Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 0, startRotate + (eslapsed/(2 * seconds / 3)) * (endRotate - startRotate));
            yield return new WaitForEndOfFrame();
        }
        transform.eulerAngles = new Vector3(0, 0, endRotate);

        eslapsed = 0;
        startRotate = transform.eulerAngles.z;
        endRotate = endRotate/2;
        while (eslapsed <= 1f/3 * seconds)
        {
            eslapsed += Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 0, startRotate + (eslapsed / (seconds/3)) * (endRotate - startRotate));
            falseTick.color = new Color(0, 0, 0, (1 - eslapsed / (seconds/3)));
            yield return new WaitForEndOfFrame();
        }
        transform.eulerAngles = new Vector3(0, 0, endRotate);
        Destroy(gameObject);
    }


}
