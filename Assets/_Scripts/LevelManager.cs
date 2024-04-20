using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager ins;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        ins = this;
    }

    public void UpdateLevel(string Minigame)
    {
        int curLevel = PlayerPrefs.GetInt("Level" + Minigame, 0);
        string curMiniGame = PlayerPrefs.GetString("curMinigame");
        if (curLevel <= 2)
        {
            PlayerPrefs.SetInt("Level" + Minigame, curLevel + 1);
        }
        else
        {
            PlayerPrefs.SetInt("Level" + Minigame, 3);
        }
        //PlayerPrefs.SetInt("Minigame_Star_" + curMiniGame, PlayerPrefs.GetInt("Minigame_Star_" + curMiniGame) + 1);
        //Debug.Log(curMiniGame + " " + PlayerPrefs.GetInt("Minigame_Star_" + curMiniGame));
    }

    public int GetLevel(string Minigame)
    {
        int curLevel = PlayerPrefs.GetInt("Level" + Minigame, 0);
        return curLevel;
    }
}
