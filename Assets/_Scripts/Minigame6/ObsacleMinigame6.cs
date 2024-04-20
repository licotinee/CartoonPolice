using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsacleMinigame6 : MonoBehaviour
{
    [SerializeField] float forceFly;
    [SerializeField] float speedRotate;
    Rigidbody2D rigid;
    private bool isFlying;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    public void Fly()
    {
        if (!isFlying)
        {
            isFlying = true;
            rigid.isKinematic = false;
            rigid.AddForce(new Vector2(2, 1) * forceFly);
        }

    }

    private void Update()
    {
        if (rigid.velocity.y > 0)
        {
            transform.eulerAngles += new Vector3(0, 0, speedRotate);
        }
        if (rigid.velocity.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
