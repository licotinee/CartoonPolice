using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    [SerializeField] List<GameObject> ListMap;
    private int numOfMap;
    public static MapManager ins;
    private void Start()
    {
        ins = this;
        numOfMap = ListMap.Count;
        LoadMap();
    }

    private void LoadMap()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int curLevel = LevelManager.ins.GetLevel(curMinigame);
        if (CanvasInstance.ins)
        {
            Instantiate(ListMap[curLevel % numOfMap], transform.position, Quaternion.identity, CanvasInstance.ins.transform);
        }
        else
        {
            Instantiate(ListMap[curLevel % numOfMap], transform.position, Quaternion.identity);
        }
    }
}
