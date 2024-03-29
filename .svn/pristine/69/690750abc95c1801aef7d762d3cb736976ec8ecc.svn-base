using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene86Manager : MonoBehaviour
{
    public static GameScene86Manager ins;
    [SerializeField] public Criminal_Scene6_8 criminal;
    public bool isEndGame;
    public bool isStartGame;
    private void Awake()
    {
        ins = this;
    }

    public void EndGame()
    {
        StartCoroutine(StartEndGame());
    }

    IEnumerator StartEndGame()
    {
        isEndGame = true;
        yield return new WaitForSeconds(2f);
        CompleteMinigame8();
    }

    private void CompleteMinigame8()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        LevelManager.ins.UpdateLevel(curMinigame);
        ScenesManager.ins.LoadScene("SceneMenu");
    }
}
