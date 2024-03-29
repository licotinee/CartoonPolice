using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Dynamic;

public class Map : MonoBehaviour
{
    public static Map ins;
    GridLayoutGroup gridLayout;
    [SerializeField] int column;
    [SerializeField] int row;
    [SerializeField] Cell cell;
    [SerializeField] public PoliceCar car;
    [SerializeField] CermentTruck truck;
    public Cell cellOnCar;
    public Cell[,] MatrixCells;
    [SerializeField] public CameraSet cam;
    [SerializeField] Sprite fixedHoleSprite;
    [SerializeField] Image hole;
    [SerializeField] Image phone;
    
    public int[,] CanMove =
    {
        { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 0, 0},
        { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1},
        { 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0},
        { 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1},
        { 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1}
    };

    private int[,] CanMove1 =
    {
        { 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 1, 0, 0},
        { 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1},
        { 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1},
        { 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1},
        { 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1}
    };

    private int[,] CanMove2 =
    {
        { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 0, 0},
        { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1},
        { 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0},
        { 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1},
        { 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
    };

    public int rowHole = 4;
    public int colHole = 28;

    int rowPhone = 1;
    int colPhone = 27;

    public int rowTrain = 3;
    public int colTrain = 18;

    public int rowPoliceStation = 1;
    public int colPoliceStation = 0;

    public int rowEnd;
    public int colEnd;


    private void Awake()
    {
        ins = this;
        InstanceMap();
        gridLayout = GetComponent<GridLayoutGroup>();
        MatrixCells = new Cell[row, column];
        InstantiateCell();
        gridLayout.constraintCount = column;
        cellOnCar = MatrixCells[rowPoliceStation, colPoliceStation];
    }

    private void InstanceMap()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int curLevel = LevelManager.ins.GetLevel(curMinigame);
        if (curLevel % 2 == 0)
        {
            CanMove = CanMove1;
        }
        else
        {
            CanMove = CanMove2;
        }
    }

    private void InstantiateCell()
    {
        for(int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                MatrixCells[i, j] = Instantiate(cell, transform.position, Quaternion.identity, transform);
                MatrixCells[i, j].indexRow = i;
                MatrixCells[i, j].indexCol = j;
            }
        }


    }

    public void UpdatePositionCar(int newRow, int newCol)
    {
        cellOnCar = MatrixCells[newRow, newCol];
        if (cellOnCar.indexCol == colPhone && cellOnCar.indexRow == rowPhone)
        {
            if (phone.gameObject)
            {
                Destroy(phone.gameObject);
            }
            if (truck) truck.gameObject.SetActive(true);
        }

        if (cellOnCar.indexCol == colEnd && cellOnCar.indexRow == rowEnd)
        {   
            GameScene32Manager.ins.EndGame();
        }
    }

    public void FixedHole()
    {
        hole.sprite = fixedHoleSprite;
        CanMove[rowHole, colHole] = 1;
    }

    public void SetTrueCellBridge()
    {
        CanMove[2, 5] = 1;
        CanMove[2, 6] = 1;
        CanMove[2, 7] = 1;
        CanMove[2, 8] = 1;
    }

    public void SetFalseCellBridge()
    {
        CanMove[2, 5] = 0;
        CanMove[2, 6] = 0;
        CanMove[2, 7] = 0;
        CanMove[2, 8] = 0;
    }

    public void StartGame()
    {
        car.transform.position = cellOnCar.transform.position;
        Vector3 newPos = MatrixCells[rowPoliceStation, colPoliceStation + 1].transform.position;
        car.Move(rowPoliceStation, colPoliceStation + 1, newPos);
    }

}
