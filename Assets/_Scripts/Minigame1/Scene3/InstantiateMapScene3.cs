using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateMapScene3 : MonoBehaviour
{
    [SerializeField] List<Image> ListMap;
    private int numOfMap;
    void Start()
    {
        numOfMap = ListMap.Count;
        LoadMap();
    }

    public void LoadMap()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int curLevel = LevelManager.ins.GetLevel(curMinigame);
        Image mapCur = Instantiate(ListMap[curLevel % numOfMap], transform.position, Quaternion.identity);
        mapCur.transform.SetParent(transform, false);
    }
}
