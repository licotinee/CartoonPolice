using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene43Manager : MonoBehaviour
{

    [SerializeField] float timeMaxPlay;
    [SerializeField] ShadeBg startShade;
    [SerializeField] ShadeBg endShade;
    public static GameScene43Manager ins;

    public GameObject carBoss;
    public bool isStartGame;
    public bool isEndGame;
    public delegate void EEndGame();
    public static event EEndGame eEndGame;
    public static event EEndGame ePrepareEndGame;
    
    private void Awake()
    {
        ins = this;
        startShade.gameObject.SetActive(true); 
        StartCoroutine(StartCountTimePlay());
    }

    public void EndGame()
    {
        StartCoroutine(StartEndGame());
    }
    IEnumerator StartCountTimePlay()
    {
        float eslased = 0;
        while (eslased <= timeMaxPlay)
        {
            eslased += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        ePrepareEndGame?.Invoke();
    }
    IEnumerator StartEndGame()
    {
        isEndGame = true;
        eEndGame?.Invoke();
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
