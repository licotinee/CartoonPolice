using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust_SessionFinger_8 : MonoBehaviour
{
    [SerializeField] float maxScale;
    [SerializeField] float minScale;
    [SerializeField] float minDist;
    [SerializeField] float maxDist;
    [SerializeField] float timeExist;
    private void Awake()
    {
        float ranScale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(ranScale, ranScale, ranScale);
    }

    public void SetPos(int direct)
    {
        float ranX = Random.Range(minDist, maxDist);
        float ranY = Random.Range(minDist, maxDist);

        transform.position += new Vector3(ranX, ranY, 0) * direct;
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(timeExist);
        Destroy(gameObject);
    }
}
