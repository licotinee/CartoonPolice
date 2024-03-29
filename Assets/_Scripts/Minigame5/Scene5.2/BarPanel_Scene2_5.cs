using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarPanel_Scene2_5 : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        GameScene52Manager.eEndGame += EndGame;
    }

    private void OnDestroy()
    {
        GameScene52Manager.eEndGame -= EndGame;
    }
    private void EndGame()
    {
        animator.Play("EndGame");
    }
}
