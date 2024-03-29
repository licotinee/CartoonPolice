using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PoliceCar : MonoBehaviour
{
    public bool isMoving;
    [SerializeField] float timeMove;
    IEnumerator co;
    [SerializeField] Image imgCar;
    public bool isCanMove;
    [SerializeField] Image smoke1;
    [SerializeField] Image smoke2;
    public delegate void CarWait();
    public static event CarWait carWait;

    private void Start()
    {
        isCanMove = true;
    }
    public void Move(int newRow, int newCol, Vector3 newPos)
    {
        if (isCanMove && !isMoving)
        {
            co = MoveToNewPosition(newRow, newCol, newPos);
            StartCoroutine(co);
        }
    }

    IEnumerator MoveToNewPosition(int newRow, int newCol, Vector3 newPos)
    {
        bool canMove = Map.ins.CanMove[newRow, newCol] == 1 ? true : false;
        int oldRow = Map.ins.cellOnCar.indexRow;
        int oldCol = Map.ins.cellOnCar.indexCol;

        if (Mathf.Abs(newRow - oldRow) + Mathf.Abs(newCol - oldCol) == 1 && !isMoving)
        {
            if (canMove)
            {
                StartCoroutine(StartInstanceSmoke());
                carWait?.Invoke();
                Map.ins.UpdatePositionCar(newRow, newCol);
                int newRotation = (newCol - oldCol) * 90 + (newRow - oldRow == -1 ? 180 : 0);
                transform.eulerAngles = new Vector3(0, 0, newRotation);
                isMoving = true;
                float elapsedTime = 0;
                Vector3 startingPos = transform.position;
                while (elapsedTime < timeMove)
                {
                    transform.position = Vector3.Lerp(startingPos, newPos, (elapsedTime / timeMove));
                    elapsedTime += Time.deltaTime;
                    yield return new WaitForEndOfFrame();
                }
                transform.position = newPos;
                isMoving = false;
                Map.ins.cam.UpdateCameraPos(newCol);
                Cell.hintCell?.Invoke();
            }
            else
            {
                HookTheCell(newRow - oldRow);

            }
        }
    }

    public void MoveBackBridge()
    {
        StopCoroutine(co);
        StartCoroutine(Flicker());
        transform.position = Map.ins.MatrixCells[2, 4].transform.position;
        Map.ins.cellOnCar = Map.ins.MatrixCells[2, 4];
        isMoving = false;
    }

    public void MoveBackRailway()
    {
        StopCoroutine(co);
        StartCoroutine(Flicker());
        transform.position = Map.ins.MatrixCells[3, 17].transform.position;
        Map.ins.cellOnCar = Map.ins.MatrixCells[3, 17];
        isMoving = false;
    }

    IEnumerator Flicker()
    {
        carWait?.Invoke();
        isCanMove = false;
        float eslapsed = 0;
        float timeFlick = 2f;
        float speedFlick = 1f;
        while (eslapsed < timeFlick)
        {
            imgCar.color -= new Color(0, 0, 0, speedFlick * Time.deltaTime);
            if (imgCar.color.a <= 0)
            {
                imgCar.color = new Color(imgCar.color.r, imgCar.color.g, imgCar.color.b, 1);
            }
            eslapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        imgCar.color = new Color(imgCar.color.r, imgCar.color.g, imgCar.color.b, 1);
        isCanMove = true;
        Cell.hintCell?.Invoke();
    }

    private void HookTheCell(int directRow)
    {
        StartCoroutine(StartHookTheCell(directRow));
    }

    IEnumerator StartHookTheCell(int directRow)
    {
        float eslapsed = 0;
        Vector3 startPos = transform.position;
        var speed = 50f; //how fast it shakes
        var amount = 0.05f; //how much it shakes
        isCanMove = false;
        int X = directRow != 0 ? 0 : 1;
        int Y = directRow != 0 ? 1 : 0;
        while (eslapsed <= timeMove)
        {
            eslapsed += Time.deltaTime;
            transform.position = startPos + new Vector3(Mathf.Sin(Time.time * speed) * amount * X, Mathf.Sin(Time.time * speed) * amount * Y, 0);
            yield return new WaitForEndOfFrame();
        }
        transform.position = startPos;
        isCanMove = true;
    }

    IEnumerator StartInstanceSmoke()
    {
        
        float timeDelay = 0.2f;
        Image newSmoke1 = Instantiate(smoke1, transform.position, Quaternion.identity, transform.parent);
        newSmoke1.transform.SetSiblingIndex(4);
        //gameObject.transform.SetAsLastSibling();
        yield return new WaitForSeconds(timeDelay);
        Image newSmoke2 = Instantiate(smoke2, transform.position, Quaternion.identity, transform.parent);
        newSmoke2.transform.SetSiblingIndex(4);

        //gameObject.transform.SetAsLastSibling();
    }
}