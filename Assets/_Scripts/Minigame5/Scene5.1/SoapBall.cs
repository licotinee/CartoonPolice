using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapBall : MonoBehaviour
{
    Animator animator;
    private SpriteRenderer spriteSoap;
    private bool isClean;
    private void Awake()
    {
        spriteSoap = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float minDist = 2f;
        if (collision.gameObject.CompareTag("Bubble"))
        {
            if (!isClean && Vector2.Distance(transform.position, collision.gameObject.transform.position) <= minDist)
            {
                isClean = true;
                spriteSoap.enabled = true;
                animator.Play("SoapBall");
                SoapBallManager.eEnableSoapBall?.Invoke();
            }
        }
    }
}
