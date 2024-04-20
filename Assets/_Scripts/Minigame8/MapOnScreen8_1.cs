using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapOnScreen8_1 : MonoBehaviour
{
    [SerializeField] List<Sprite> listMapOnScreen = new List<Sprite>();
    [SerializeField] Image mapOnScreen;

    private void Start()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int curLevel = LevelManager.ins.GetLevel(curMinigame);
        mapOnScreen.sprite = listMapOnScreen[curLevel % listMapOnScreen.Count];

    }
}
