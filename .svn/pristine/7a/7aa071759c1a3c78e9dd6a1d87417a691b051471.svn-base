using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virrus : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    [SerializeField] float timeDie;
    private int index;
    public delegate void EVirrusDie(Vector3 oldPos, int index);
    public static EVirrusDie eVirrusDie;
    private bool isDie;
    private void Awake()
    {
        StartCoroutine(nameof(StartScaleUp));
    }

    public void SetIndex(int indexVirrus)
    {
        index = indexVirrus;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0) && !isDie)
        {
            StartCoroutine(StartDie());
        }
    }

    IEnumerator StartScaleUp()
    {
        skeleton.AnimationState.SetAnimation(0, "Cuoi", true);
        float eslapsed = 0;
        float seconds = 0.5f;
        float end = transform.localScale.x;

        transform.localScale = Vector3.zero;

        while (eslapsed <= seconds && gameObject)
        {
            eslapsed += Time.deltaTime;
            transform.localScale = new Vector3(end * eslapsed/seconds, end * eslapsed / seconds, end * eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(end, end, end);
    }

    IEnumerator StartDie()
    {
        isDie = true;
        skeleton.AnimationState.SetAnimation(0, "Buon", true);
        float eslapsed = 0;
        float seconds = timeDie;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            float newA = 1 - eslapsed / seconds;
            newA = newA <= 0 ? 0 : newA;
            skeleton.Skeleton.A = newA;
            yield return new WaitForEndOfFrame();
        }
        eVirrusDie?.Invoke(transform.position, index);
        Destroy(gameObject);
    }
}
