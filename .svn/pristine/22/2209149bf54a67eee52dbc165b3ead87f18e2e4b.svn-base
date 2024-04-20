using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointPanel_Scene5_1 : MonoBehaviour
{
    [SerializeField] Text pointText;
    [SerializeField] Image stolenBox;
    [SerializeField] Sprite compeleStar;
    [SerializeField] List<Image> ListStars;
    [SerializeField] List<Sprite> ListBoxSprites;
    [SerializeField] Police_Scene5_1 police;
    private void Awake()
    {
        SetImageBox();
    }

    private void OnEnable()
    {
        SetPointText();
        SetStar();
        police.MoveUp();
    }

    private void SetPointText()
    {
        int point = GameScene15Manager.ins.curPoint;
        pointText.text = point.ToString();
    }

    private void SetStar()
    {
        for (int i = 0; i < UIManager_Scene5_1.ins.barPanel.cntCompleteStar; ++i)
        {
            ListStars[i].sprite = compeleStar;
        }
    }

    private void SetImageBox()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int level = LevelManager.ins.GetLevel(curMinigame);
        stolenBox.sprite = ListBoxSprites[level % (ListBoxSprites.Count)];
    }


}
