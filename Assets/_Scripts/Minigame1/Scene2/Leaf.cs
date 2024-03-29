using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    [SerializeField] List<GameObject> Leafs;
    int cnt_hit;
    [SerializeField] float forceFly;
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
        for (int i = 0; i < Leafs.Count; ++i)
        {
            StartCoroutine(StartBeHitted(Leafs[i]));
        }
    }

    IEnumerator StartBeHitted(GameObject leaf)
    {
        leaf.GetComponent<Rigidbody2D>().isKinematic = false;
        float directionX = Random.Range(0.4f, 0.7f);
        leaf.GetComponent<Rigidbody2D>().AddForce(new Vector2(directionX, 1) * forceFly);
        yield return new WaitForSeconds(2f);
        Destroy(leaf);
    }

}
