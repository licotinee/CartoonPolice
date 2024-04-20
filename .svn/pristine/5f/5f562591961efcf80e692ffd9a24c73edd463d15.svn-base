using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBox : MonoBehaviour
{
    [SerializeField] List<GameObject> woods;
    int cnt_hit;
    [SerializeField] float forceFly;
    [SerializeField] float speedRotate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            cnt_hit++;
            if (cnt_hit == 1)
            {
                beHitted();
            }

        }
    }

    private void beHitted()
    {
        for (int i = 0; i < woods.Count; ++i)
        {
            StartCoroutine(StartBeHitted(woods[i]));
            StartCoroutine(StartRotate(woods[i]));
        }
    }

    IEnumerator StartBeHitted(GameObject wood)
    {
        wood.GetComponent<Rigidbody2D>().isKinematic = false;
        float directionX = Random.Range(0.4f, 0.7f);
        wood.GetComponent<Rigidbody2D>().AddForce(new Vector2(directionX, 1) * forceFly);
        yield return new WaitForSeconds(2f);
        Destroy(wood);
    }

    IEnumerator StartRotate(GameObject wood)
    {
        while (wood)
        {
            wood.transform.eulerAngles += new Vector3(0, 0, speedRotate * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    

}
