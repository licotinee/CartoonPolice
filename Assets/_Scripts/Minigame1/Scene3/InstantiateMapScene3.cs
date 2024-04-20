using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateMapScene3 : MonoBehaviour // scene tim trộm
{
    [SerializeField] List<Image> ListMap;
    private int numOfMap;
    void Start()
    {
        SoundManager.Instance.PlayBGM(SoundTag.Bgm_theif_find);
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
