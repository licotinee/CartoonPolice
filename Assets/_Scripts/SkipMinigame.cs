using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkipMinigame : Singleton<SkipMinigame>
{
    private void Awake()
    {
        base.Awake();
        
    }

    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            string curMinigame = PlayerPrefs.GetString("curMinigame");
            int curScene = PlayerPrefs.GetInt("curScene") + 1;
            PlayerPrefs.SetInt("curScene", curScene);
            ScenesManager.ins.LoadScene(curMinigame + "." + curScene.ToString());
        });
        
    }
}
