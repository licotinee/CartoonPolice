using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene62Manager : MonoBehaviour
{
    public static GameScene62Manager ins;

    public bool isStartGame;
    public bool isEndGame;
    [SerializeField] public WolfooMinigame6 wolfoo;
    [SerializeField] GameObject limitScene;
    [SerializeField] ShadeBg startShade;
    [SerializeField] ShadeBg endShade;
    public Transform endPos;
    private void Awake()
    {
        ins = this;
        // Get Length Move
        limitScene.transform.position = new Vector3(endPos.position.x - Camera.main.orthographicSize * Camera.main.aspect, limitScene.transform.position.y, limitScene.transform.position.z);
        startShade.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        isStartGame = true;
        PanelBarUIMini6.ins.StartGame();
    }

    public void EndGame()
    {
        StartCoroutine(StartEndGame());
    }

    IEnumerator StartEndGame()
    {
        PanelBarUIMini6.ins.EndGame();
        yield return new WaitForSeconds(2f);
        endShade.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        LoadNextScene();
    }
    public void LoadNextScene()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int curScene = PlayerPrefs.GetInt("curScene") + 1;
        PlayerPrefs.SetInt("curScene", curScene);
        ScenesManager.ins.LoadScene(curMinigame + "." + curScene.ToString());
    }
}
