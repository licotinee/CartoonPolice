using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speedShot;
    [SerializeField] GameObject bulletBroken;
    List<GameObject> ListBulletGoThrough = new List<GameObject>();
    public bool isOfPolice;
    public void ShotToGoal(Vector3 goalPosition)
    {
        StartCoroutine(StartMoveToGoalPosition(goalPosition));
    }

    IEnumerator StartMoveToGoalPosition(Vector3 goalPosition)
    {
        Vector3 end = new Vector3(goalPosition.x, goalPosition.y, transform.position.z);
        while (Vector2.Distance(transform.position, end) >= 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, end, speedShot * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        CheckToDestroyCriminal();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Criminal"))
        {
            ListBulletGoThrough.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Criminal"))
        {
            ListBulletGoThrough.Remove(collision.gameObject);
        }
    }

    private void CheckToDestroyCriminal()
    {
        int index = 0;
        if (isOfPolice)
        {
            if (ListBulletGoThrough.Count != 0)
            {
                ListBulletGoThrough[index].GetComponent<Criminal_SceneBank>().BeShooted();
                GameScene24Manager.ins.UpdatePoint();
            }
        }
        Instantiate(bulletBroken, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
