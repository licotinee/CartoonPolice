using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    Button button;
    Image image;
    public int indexRow;
    public int indexCol;


    public delegate void HintTheCellCanMove();
    public static HintTheCellCanMove hintCell;

    private void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        button.onClick.AddListener(OnClick);
    }

    private void OnEnable()
    {
        hintCell += Hint;
        PoliceCar.carWait += StopHint;
        GameScene32Manager.end += StopHint;
    }

    private void OnDestroy()
    {
        hintCell -= Hint;
        PoliceCar.carWait -= StopHint;
        GameScene32Manager.end -= StopHint;
    }

    private void OnClick()
    {
        if (!GameScene32Manager.ins.isMovingCam && !GameScene32Manager.ins.isEndgame)
        {
            SoundManager.Instance.PlaySFX(SoundTag.Eff_report_phone); // soudn move
            Map.ins.car.Move(indexRow, indexCol, transform.position);
        }
    }

    private void Hint()
    {
        StopHint();
        if (Mathf.Abs(indexRow - Map.ins.cellOnCar.indexRow) + Mathf.Abs(indexCol - Map.ins.cellOnCar.indexCol) == 1 && !GameScene32Manager.ins.isEndgame)
        {
            if (Map.ins.CanMove[indexRow, indexCol] == 1)
            {
                image.color = new Color(0, 0, 0, 0.25f);
                StartCoroutine(ActiveTutorial(this.gameObject.transform.GetChild(0).gameObject));
            }
        }
    }

    IEnumerator ActiveTutorial(GameObject go)
    {
        yield return new WaitForSeconds(1.5f);
        go.SetActive(true);
    }

    private void StopHint()
    {
        image.color = new Color(0, 0, 0, 0f);
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
