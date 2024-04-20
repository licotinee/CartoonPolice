using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BridgeAnimControl : MonoBehaviour
{
    public Material m;
    public Color c;
    Material material;
    public bool IsRight;
    private void Start()
    {
        material = new Material(m);
        gameObject.GetComponent<Image>().material = material;
    }

    private void Update()
    {
        material.SetColor("_Color",c);
    }
    public void Anim(float value)
    {
        material.SetFloat("_Move", value);
        if (IsRight)
        {
            material.SetFloat("_IsRight", 123);
        }
        else
        {
            material.SetFloat("_IsRight", 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(nameof(StartOpen));

        Map.ins.SetFalseCellBridge();
        int curRow = Map.ins.cellOnCar.indexRow;
        int curCol = Map.ins.cellOnCar.indexCol;

        if (curRow == 2)
        {
            if (curCol == 5 || curCol == 6 || curCol == 7 || curCol == 8)
            {
                Map.ins.car.MoveBackBridge();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(nameof(StartClose));
    }

    IEnumerator StartOpen()
    {
        if (!Map.ins.car.isMoving)
        {
            Cell.hintCell?.Invoke();
        }
        float eslapsed = 0;
        float seconds = 1f;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            Anim(eslapsed/seconds * 150);
            yield return new WaitForEndOfFrame();
        }
        Anim(150);
    }

    IEnumerator StartClose()
    {
        float eslapsed = 0;
        float seconds = 1f;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            Anim((1 - eslapsed / seconds) * 150);
            yield return new WaitForEndOfFrame();
        }
        Anim(0);
        Map.ins.SetTrueCellBridge();
        if (!Map.ins.car.isMoving)
        {
            Cell.hintCell?.Invoke();
        }

    }


}
