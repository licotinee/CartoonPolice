using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene42Manager : MonoBehaviour
{
    public static GameScene42Manager ins;
    [SerializeField] GameObject limitScene;
    [SerializeField] private int maxPoint;

    [SerializeField] ShadeBg startShade;
    [SerializeField] ShadeBg endShade;
    private int curPoint;

    public delegate void EEndGame();
    public static event EEndGame eEndGame;
    public static event EEndGame eChangeScene;

    private void Awake()
    {
        ins = this;
        limitScene.transform.position = new Vector3(Camera.main.orthographicSize * Camera.main.aspect + 10f, 0, 0);
        startShade.gameObject.SetActive(true);
    }

    public void UpdatePoint()
    {
        curPoint++;
        PanelBar_Scene2_4.eUpdateBar?.Invoke(1.0f * curPoint / maxPoint);
        if (curPoint == maxPoint)
        {
            StartCoroutine(StartEndGame());
        }
    }

    IEnumerator StartEndGame()
    {
        eEndGame?.Invoke();
        yield return new WaitForSeconds(3f);
        eChangeScene?.Invoke();
        yield return new WaitForSeconds(3f);
        endShade.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        LoadNewScene();
    }

    private void LoadNewScene()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int curScene = PlayerPrefs.GetInt("curScene") + 1;
        PlayerPrefs.SetInt("curScene", curScene);
        ScenesManager.ins.LoadScene(curMinigame + "." + curScene.ToString());
    }


}
