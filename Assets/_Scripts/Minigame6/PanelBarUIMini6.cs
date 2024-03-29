using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBarUIMini6 : MonoBehaviour
{
    public static PanelBarUIMini6 ins;
    [SerializeField] Image barFill;
    [SerializeField] Image WolfIcon;
    [SerializeField] Image RihinoIcon;
    Animator animator;
    Vector3 startPosWolfIcon;

    private float lengthMove;
    [SerializeField] float lengthBar;
    private void Start()
    {
        ins = this;
        animator = GetComponent<Animator>();
        startPosWolfIcon = WolfIcon.rectTransform.anchoredPosition;
        lengthMove = GameScene62Manager.ins.endPos.position.x - (Camera.main.orthographicSize * Camera.main.aspect * 2 / 3);

    }

    private void Update()
    {
        if (GameScene62Manager.ins.isStartGame && !GameScene62Manager.ins.isEndGame)
        {
            float tmp = GameScene62Manager.ins.wolfoo.transform.position.x - -(Camera.main.orthographicSize * Camera.main.aspect * 2 / 3);
            UpdateBar(tmp / lengthMove);
        }
    }


    public void UpdateBar(float rate)
    {
        if (rate >= 0)
        {
            WolfIcon.rectTransform.anchoredPosition = new Vector3(startPosWolfIcon.x + rate * lengthBar, barFill.rectTransform.anchoredPosition.y);
            barFill.fillAmount = rate;
        }

    }

    public void StartGame()
    {
        animator.Play("StartGame");
    }

    public void EndGame()
    {
        animator.Play("EndGame");
    }
}
