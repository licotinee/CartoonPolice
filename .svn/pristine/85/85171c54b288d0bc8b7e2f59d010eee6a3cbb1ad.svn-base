using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene84Manager : MonoBehaviour
{
    public static GameScene84Manager ins;
    private void Awake()
    {
        ins = this;
    }

    public void LoadNewScene()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        ScenesManager.ins.LoadScene(curMinigame + ".6");
    }
}
