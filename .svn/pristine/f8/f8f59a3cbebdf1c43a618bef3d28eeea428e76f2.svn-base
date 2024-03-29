using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene32Manager: MonoBehaviour
{
    public static GameScene32Manager ins;
    public bool isMovingCam;
    [SerializeField] ShadeBg startShade;
    [SerializeField] ShadeBg endShade;
    public bool isEndgame;
    public delegate void End();
    public static event End end;

    private void Awake()
    {
        ins = this;
        startShade.gameObject.SetActive(true);
    }

    public void EndGame()
    {
        StartCoroutine(StartEndGame());
    }

    IEnumerator StartEndGame()
    {
        isEndgame = true;
        end?.Invoke();
        yield return new WaitForSeconds(2f);
        endShade.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int curScene = PlayerPrefs.GetInt("curScene") + 1;
        PlayerPrefs.SetInt("curScene", curScene);
        ScenesManager.ins.LoadScene(curMinigame + "." + curScene.ToString());
    }

}
