using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene25Manager : MonoBehaviour
{
    public static GameScene25Manager ins;
    public delegate void StartTurn(float time);
    public static event StartTurn startTurn;
    public delegate void EndGame(float time);
    public static event EndGame endGame;

    [SerializeField] float timeStartTurn;
    [SerializeField] float timeEndGame;
    [SerializeField] int maxPoint;
    int curPoint;
    [SerializeField] public Criminal_Scene5_2 criminal;
    [SerializeField] ShadeBg startShade;
    [SerializeField] ShadeBg endShade;

    public bool isEndGame;
    private void Awake()
    {
        ins = this;
        startShade.gameObject.SetActive(true);
    }

    public void StartNewTurn()
    {
        startTurn?.Invoke(timeStartTurn);
    }

    public void UpdatePoint()
    {
        curPoint++;
        BarPanel_Scene5_2.ins.UpdateBar(1.0f * curPoint/maxPoint);
        if (curPoint == maxPoint)
        {
            StartCoroutine(StartEndGame());     
        }
    }

    IEnumerator StartEndGame()
    {
        BarPanel_Scene5_2.ins.EndGame();
        yield return new WaitForSeconds(0.25f);
        isEndGame = true;
        endGame?.Invoke(timeEndGame);
        yield return new WaitForSeconds(timeEndGame + 2f);
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
